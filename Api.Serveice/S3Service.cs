using Amazon.S3;
using Amazon.S3.Model;
using Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Api.Serveice
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;
        private readonly string[] _allowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
        private readonly string[] _allowedImageMimeTypes = {
            "image/jpeg", "image/jpg", "image/png", "image/gif", "image/bmp", "image/webp"
        };

        public S3Service(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"];
        }

        public async Task<string> UploadFileAsync(IFormFile file, string prefix = "")
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("קובץ לא תקין");

            // בדיקת סוג הקובץ (לפי סיומת)
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedImageExtensions.Contains(fileExtension))
                throw new ArgumentException("סוג הקובץ אינו תמונה מורשית");

            // בדיקת סוג ה-MIME (מספק אבטחה טובה יותר)
            if (!_allowedImageMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
                throw new ArgumentException("סוג התוכן אינו של תמונה מורשית");

            // יצירת שם ייחודי לקובץ
            var fileName = $"{prefix}{Guid.NewGuid()}{fileExtension}";

            using (var stream = file.OpenReadStream())
            {
                var request = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key = fileName,
                    InputStream = stream,
                    ContentType = file.ContentType,
                    // הוספת מטה-דאטה לציון סוג הקובץ
                    Metadata =
                    {
                        ["x-amz-meta-originalname"] = file.FileName,
                        ["x-amz-meta-extension"] = fileExtension,
                        ["x-amz-meta-uploaddate"] = DateTime.UtcNow.ToString("o")
                    }
                };

                await _s3Client.PutObjectAsync(request);
            }

            return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
        }

        public async Task DeleteFileAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
                throw new ArgumentException("כתובת URL לא תקינה");

            // חילוץ ה-Key מתוך כתובת ה-URL
            var uri = new Uri(fileUrl);
            var key = uri.AbsolutePath.TrimStart('/');

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            await _s3Client.DeleteObjectAsync(deleteRequest);
        }

        public async Task<bool> FileExistsAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
                return false;

            try
            {
                var uri = new Uri(fileUrl);
                var key = uri.AbsolutePath.TrimStart('/');

                var request = new GetObjectMetadataRequest
                {
                    BucketName = _bucketName,
                    Key = key
                };

                await _s3Client.GetObjectMetadataAsync(request);
                return true;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Dictionary<string, string>> GetFileMetadataAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
                throw new ArgumentException("כתובת URL לא תקינה");

            var uri = new Uri(fileUrl);
            var key = uri.AbsolutePath.TrimStart('/');

            var request = new GetObjectMetadataRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            var response = await _s3Client.GetObjectMetadataAsync(request);
            var metadata = new Dictionary<string, string>();

            // מידע סטנדרטי
            metadata["ContentType"] = response.Headers.ContentType;
            metadata["ContentLength"] = response.Headers.ContentLength.ToString();
            // המרה ל-DateTime לפני השימוש ב-ToString
            DateTime lastModifiedDateTime = DateTime.Parse(response.LastModified.ToString());
            metadata["LastModified"] = lastModifiedDateTime.ToString("o");

            // מטה-דאטה מותאם אישית
            foreach (var item in response.Metadata.Keys)
            {
                metadata[item] = response.Metadata[item];
            }

            return metadata;
        }
    }
}