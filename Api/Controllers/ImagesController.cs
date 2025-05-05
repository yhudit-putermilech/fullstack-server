//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        // GET: api/<ImagesController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<ImagesController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ImagesController>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<ImagesController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<ImagesController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}



//------------------------------------------------------------------------------------------------------
//גירסה אחרונה 
//using Api.Core.DTOs;
//using Api.Core.Models;
//using Api.Core.Services;
//using Api.Serveice;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Api.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IImageService _imageService;
//        private readonly IMapper _mapper;

//        public ImagesController(IImageService imageService, IMapper mapper)
//        {
//            _imageService = imageService;
//            _mapper = mapper;
//        }

//        // פעולה לקבלת כל התמונות
//        [HttpGet]
//        public async Task<ActionResult> GetAll()
//        {
//            var images = await _imageService.GetAllAsync();
//            var imagesDto = _mapper.Map<IEnumerable<ImagePostModel>>(images);
//            return Ok(imagesDto);
//        }



//        // פעולה לקבלת תמונה לפי מזהה
//        [HttpGet("{id}")]
//        public async Task<ActionResult> GetById(int id)
//        {
//            var image = await _imageService.GetByIdAsync(id);
//            var imageDto = _mapper.Map<ImagePostModel>(image);
//            return Ok(imageDto);
//        }

//        // פעולה להוספת תמונה חדשה
//        [HttpPost]
//        public async Task Add([FromBody] ImagePostModel image)
//        {
//            var photoMetadataToAdd = _mapper.Map<Images>(image);
//            await _imageService.AddValueAsync(photoMetadataToAdd);
//        }

//        // פעולה לעדכון תמונה קיימת
//        [HttpPut("{id}")]
//        public async Task<ActionResult> Update(int id, [FromBody] UpdateImagesModel photoMetadataModel)
//        {
//            var existingPhotoMetadataModel = await _imageService.GetByIdAsync(id);
//            if (existingPhotoMetadataModel != null)
//            {
//                existingPhotoMetadataModel.FileUrl = photoMetadataModel.FileUrl;
//                existingPhotoMetadataModel.FileType = photoMetadataModel.FileType;

//                await _imageService.PutValueAsync(existingPhotoMetadataModel);  // כאן אנחנו פשוט מעדכנים
//                return Ok(existingPhotoMetadataModel);
////            }

//            return NoContent();
//        }

//        // פעולה למחיקת תמונה
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var image = await _imageService.GetByIdAsync(id);
//            if (image == null)
//            {
//                return NotFound();
//            }
//            await _imageService.DeleteAsync(image);
//            return NoContent();
//        }
//    }
//}

////using Api.Core.DTOs;
////using Api.Core.Models;
////using Api.Core.Services;
////using Api.Serveice;
////using AutoMapper;
////using Microsoft.AspNetCore.Mvc;
////using System.Collections.Generic;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Http;
////using System;

////namespace Api.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class ImagesController : ControllerBase
////    {
////        private readonly IImageService _imageService;
////        private readonly IMapper _mapper;
////        private readonly IS3Service _s3Service; // הוספת שירות S3

////        public ImagesController(IImageService imageService, IMapper mapper, IS3Service s3Service)
////        {
////            _imageService = imageService;
////            _mapper = mapper;
////            _s3Service = s3Service;
////        }

////        // פעולה לקבלת כל התמונות
////        [HttpGet]
////        public async Task<ActionResult> GetAll()
////        {
////            var images = await _imageService.GetAllAsync();
////            var imagesDto = _mapper.Map<IEnumerable<ImagePostModel>>(images);
////            return Ok(imagesDto);
////        }

////        // פעולה לקבלת תמונה לפי מזהה
////        [HttpGet("{id}")]
////        public async Task<ActionResult> GetById(int id)
////        {
////            var image = await _imageService.GetByIdAsync(id);
////            if (image == null)
////            {
////                return NotFound($"תמונה עם מזהה {id} לא נמצאה");
////            }
////            var imageDto = _mapper.Map<ImagePostModel>(image);
////            return Ok(imageDto);
////        }

////        // פעולה להוספת תמונה חדשה
////        [HttpPost]
////        public async Task<ActionResult> Add([FromBody] ImagePostModel image)
////        {
////            if (image == null)
////            {
////                return BadRequest("הנתונים שהתקבלו אינם תקינים");
////            }

////            var photoMetadataToAdd = _mapper.Map<Images>(image);
////            await _imageService.AddValueAsync(photoMetadataToAdd);

////            return CreatedAtAction(nameof(GetById), new { id = photoMetadataToAdd.Id },
////                _mapper.Map<ImagePostModel>(photoMetadataToAdd));
////        }

////        // פעולה לעדכון תמונה קיימת
////        [HttpPut("{id}")]
////        public async Task<ActionResult> Update(int id, [FromBody] UpdateImagesModel photoMetadataModel)
////        {
////            if (photoMetadataModel == null)
////            {
////                return BadRequest("הנתונים שהתקבלו אינם תקינים");
////            }

////            var existingPhotoMetadataModel = await _imageService.GetByIdAsync(id);
////            if (existingPhotoMetadataModel == null)
////            {
////                return NotFound($"תמונה עם מזהה {id} לא נמצאה");
////            }

////            existingPhotoMetadataModel.FileUrl = photoMetadataModel.FileUrl;
////            existingPhotoMetadataModel.FileType = photoMetadataModel.FileType;
////            await _imageService.PutValueAsync(existingPhotoMetadataModel);

////            return Ok(_mapper.Map<ImagePostModel>(existingPhotoMetadataModel));
////        }

////        // פעולה למחיקת תמונה
////        [HttpDelete("{id}")]
////        public async Task<ActionResult> Delete(int id)
////        {
////            var image = await _imageService.GetByIdAsync(id);
////            if (image == null)
////            {
////                return NotFound($"תמונה עם מזהה {id} לא נמצאה");
////            }

////            await _imageService.DeleteAsync(image);
////            return NoContent();
////        }

////        // ====== נקודות קצה חדשות לעבודה עם S3 ======

////        // העלאת תמונה ל-S3 ושמירת המטא-דאטה במסד הנתונים
////        [HttpPost("upload-to-s3")]
////        public async Task<IActionResult> UploadToS3(IFormFile file)
////        {
////            if (file == null || file.Length == 0)
////                return BadRequest("לא נשלח קובץ");

////            try
////            {
////                // בדיקת גודל קובץ מקסימלי (לדוגמה 10MB)
////                var maxFileSize = 10 * 1024 * 1024;
////                if (file.Length > maxFileSize)
////                    return BadRequest($"גודל הקובץ חורג מהמגבלה המותרת של {maxFileSize / (1024 * 1024)}MB");

////                // העלאה ל-S3 וקבלת ה-URL
////                var fileUrl = await _s3Service.UploadFileAsync(file, "images/");

////                // יצירת רשומת מטא-דאטה חדשה
////                var newImage = new Images
////                {
////                    FileUrl = fileUrl,
////                    FileType = file.ContentType,
////                    UploadDate = DateTime.UtcNow
////                    // כאן תוכל להוסיף עוד שדות כפי שנדרש
////                };

////                // שמירת המטא-דאטה במסד הנתונים
////                await _imageService.AddValueAsync(newImage);

////                // החזרת ה-URL וה-ID של התמונה
////                return Ok(new {
////                    url = fileUrl,
////                    id = newImage.Id,
////                    type = newImage.FileType,
////                    uploadDate = newImage.UploadDate
////                });
////            }
////            catch (ArgumentException ex)
////            {
////                return BadRequest(ex.Message);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, $"שגיאה בהעלאת הקובץ: {ex.Message}");
////            }
////        }

////        // קבלת מידע על תמונה מ-S3
////        [HttpGet("s3-info")]
////        public async Task<IActionResult> GetS3FileInfo([FromQuery] string fileUrl)
////        {
////            if (string.IsNullOrEmpty(fileUrl))
////                return BadRequest("לא סופקה כתובת URL");

////            try
////            {
////                var exists = await _s3Service.FileExistsAsync(fileUrl);
////                if (!exists)
////                    return NotFound("הקובץ לא נמצא");

////                var metadata = await _s3Service.GetFileMetadataAsync(fileUrl);
////                return Ok(metadata);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, $"שגיאה בקבלת מידע על הקובץ: {ex.Message}");
////            }
////        }

////        // מחיקת תמונה מ-S3 וממסד הנתונים
////        [HttpDelete("delete-from-s3/{id}")]
////        public async Task<IActionResult> DeleteFromS3AndDb(int id)
////        {
////            try
////            {
////                // קבלת המטא-דאטה של התמונה ממסד הנתונים
////                var image = await _imageService.GetByIdAsync(id);
////                if (image == null)
////                    return NotFound($"תמונה עם מזהה {id} לא נמצאה");

////                // קבלת ה-URL של התמונה
////                string fileUrl = image.FileUrl;

////                // בדיקה אם הקובץ קיים ב-S3
////                var exists = await _s3Service.FileExistsAsync(fileUrl);

////                // מחיקת הקובץ מ-S3 (אם הוא קיים)
////                if (exists)
////                {
////                    await _s3Service.DeleteFileAsync(fileUrl);
////                }
////                else
////                {
////                    // אם הקובץ לא קיים ב-S3, רק הודעה
////                    // אבל עדיין נמחק את הרשומה ממסד הנתונים
////                    // כדי לא להשאיר רשומות "תלויות"
////                }

////                // מחיקת המטא-דאטה ממסד הנתונים
////                await _imageService.DeleteAsync(image);

////                if (exists)
////                {
////                    return Ok(new { message = "התמונה נמחקה בהצלחה מ-S3 וממסד הנתונים" });
////                }
////                else
////                {
////                    return Ok(new { message = "התמונה נמחקה ממסד הנתונים, אך לא נמצאה ב-S3" });
////                }
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, $"שגיאה במחיקת התמונה: {ex.Message}");
////            }
////        }

////        // מחיקת תמונה רק מ-S3 (משאיר את המטא-דאטה במסד הנתונים)
////        [HttpDelete("delete-only-from-s3")]
////        public async Task<IActionResult> DeleteOnlyFromS3([FromQuery] string fileUrl)
////        {
////            if (string.IsNullOrEmpty(fileUrl))
////                return BadRequest("לא סופקה כתובת URL");

////            try
////            {
////                var exists = await _s3Service.FileExistsAsync(fileUrl);
////                if (!exists)
////                    return NotFound("הקובץ לא נמצא ב-S3");

////                await _s3Service.DeleteFileAsync(fileUrl);
////                return Ok(new { message = "הקובץ נמחק בהצלחה מ-S3" });
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, $"שגיאה במחיקת הקובץ: {ex.Message}");
////            }
////        }


////        [HttpPost("upload-to-s3")]
////        public async Task<IActionResult> UploadToS3([FromForm] ImagePos
////            tModel request)
////        {
////            if (request.File == null || request.File.Length == 0)
////                return BadRequest("לא נשלח קובץ");

////            try
////            {
////                // בדיקת גודל קובץ
////                var maxFileSize = 10 * 1024 * 1024;
////                if (request.File.Length > maxFileSize)
////                    return BadRequest($"גודל הקובץ חורג מהמגבלה של {maxFileSize / (1024 * 1024)}MB");

////                // העלאה ל־S3
////                var fileUrl = await _s3Service.UploadFileAsync(request.File, "images/");

////                // יצירת רשומת תמונה
////                var newImage = new Images
////                {
////                    FileUrl = fileUrl,
////                    FileType = request.File.ContentType,
////                    UploadDate = DateTime.UtcNow,
////                    UserId = request.UserId,
////                    Tags = request.Tags
////                };

////                // שמירה במסד נתונים
////                await _imageService.AddValueAsync(newImage);

////                return Ok(new
////                {
////                    url = fileUrl,
////                    id = newImage.Id,
////                    type = newImage.FileType,
////                    uploadDate = newImage.UploadDate
////                });
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, $"שגיאה בהעלאת הקובץ: {ex.Message}");
////            }
////        }

////    }
////}
///
//גירבה אחרונה אחרונה
//using Api.Core.DTOs;
//using Api.Core.Models;
//using Api.Core.Services;
//using Api.Serveice; // תוקן מ-Serveice ל-Service
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Api.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IImageService _imageService;
//        private readonly IMapper _mapper;

//        public ImagesController(IImageService imageService, IMapper mapper)
//        {
//            _imageService = imageService;
//            _mapper = mapper;
//        }

//        // פעולה לקבלת כל התמונות
//        [HttpGet]
//        public async Task<ActionResult> GetAll()
//        {
//            var images = await _imageService.GetAllAsync();
//            var imagesDto = _mapper.Map<IEnumerable<ImagePostModel>>(images);
//            return Ok(imagesDto);
//        }

//        // פעולה לקבלת תמונה לפי מזהה
//        [HttpGet("{id}")]
//        public async Task<ActionResult> GetById(int id)
//        {
//            var image = await _imageService.GetByIdAsync(id);
//            if (image == null)
//                return NotFound();

//            var imageDto = _mapper.Map<ImagePostModel>(image);
//            return Ok(imageDto);
//        }

//        // פעולה להוספת תמונה חדשה
//        [HttpPost]
//        public async Task<ActionResult> Add([FromBody] ImagePostModel image)
//        {
//            var photoMetadataToAdd = _mapper.Map<Images>(image);
//            await _imageService.AddValueAsync(photoMetadataToAdd);

//            return CreatedAtAction(nameof(GetById), new { id = photoMetadataToAdd.Id }, image);
//        }

//        // פעולה לעדכון תמונה קיימת
//        [HttpPut("{id}")]
//        public async Task<ActionResult> Update(int id, [FromBody] UpdateImagesModel photoMetadataModel)
//        {
//            var existingPhotoMetadataModel = await _imageService.GetByIdAsync(id);
//            if (existingPhotoMetadataModel == null)
//                return NotFound();

//            existingPhotoMetadataModel.FileUrl = photoMetadataModel.FileUrl;
//            existingPhotoMetadataModel.FileType = photoMetadataModel.FileType;

//            await _imageService.PutValueAsync(existingPhotoMetadataModel);
//            return Ok(existingPhotoMetadataModel);
//        }

//        // פעולה למחיקת תמונה
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var image = await _imageService.GetByIdAsync(id);
//            if (image == null)
//                return NotFound();

//            await _imageService.DeleteAsync(image);
//            return NoContent();
//        }
//    }
//}
//קוד גירסה אחרונה אחרונ האחרונה
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System.IO;
//using System.Threading.Tasks;

//namespace Api.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IWebHostEnvironment _env;

//        public ImagesController(IWebHostEnvironment env)
//        {
//            _env = env;
//        }

//        // POST: api/images/upload
//        [HttpPost("upload")]
//        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//                return BadRequest("No file uploaded.");

//            var uploadsFolder = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");

//            if (!Directory.Exists(uploadsFolder))
//                Directory.CreateDirectory(uploadsFolder);

//            var filePath = Path.Combine(uploadsFolder, file.FileName);

//            using (var stream = new FileStream(filePath, FileMode.Create))
//            {
//                await file.CopyToAsync(stream);
//            }

//            // מחזיר כתובת URL לקובץ
//            var url = $"{Request.Scheme}://{Request.Host}/uploads/{file.FileName}";
//            return Ok(new { fileUrl = url });
//        }
//    }
//}

////גירסה אחרונה אחרונה אחורנה 
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using Amazon.S3;
//using Amazon.S3.Transfer;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;
//using Amazon.S3.Model;
//namespace Api.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IAmazonS3 _s3Client;
//        private readonly string _bucketName;

//        public ImagesController(IAmazonS3 s3Client, IConfiguration configuration)
//        {
//            _s3Client = s3Client;
//            _bucketName = configuration["AWS:BucketName"];
//        }

//        [HttpPost("upload")]
//        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//                return BadRequest("No file uploaded.");

//            var fileKey = $"uploads/{file.FileName}";

//            using (var stream = file.OpenReadStream())
//            {
//                var uploadRequest = new TransferUtilityUploadRequest
//                {
//                    InputStream = stream,
//                    Key = fileKey,
//                    BucketName = _bucketName,
//                    ContentType = file.ContentType
//                };

//                var transferUtility = new TransferUtility(_s3Client);
//                await transferUtility.UploadAsync(uploadRequest);
//            }

//            var fileUrl = $"https://{_bucketName}.s3.amazonaws.com/{fileKey}";
//            return Ok(new { fileUrl });
//        }
//    }
//}

//גירסה אחרונה*4

//using Amazon.S3;
//using Amazon.S3.Model;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
////using Microsoft.AspNetCore.Authorization;
////using Microsoft.AspNetCore.Mvc;
//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IAmazonS3 _s3Client;
//        public ImagesController(IAmazonS3 s3Client)
//        {
//            _s3Client = s3Client;
//        }
//        [HttpGet("presigned-url")]
//        [Authorize]
//        public async Task<IActionResult> GetPresignedUrl([FromQuery] string fileName)
//        {
//            var request = new GetPreSignedUrlRequest
//            {
//                BucketName = "photo-challenge-bucket-testpnoren",
//                Key = fileName,
//                Verb = HttpVerb.PUT,
//                Expires = DateTime.UtcNow.AddMinutes(5),
//                ContentType = "image/jpeg"
//            };

//            string url = _s3Client.GetPreSignedURL(request);
//            return Ok(new { url, });
//        }

//        [HttpGet]
//        [Authorize]
//        public async Task<IActionResult> ListImages()
//        {
//            try
//            {
//                var request = new ListObjectsV2Request
//                {
//                    BucketName = "photo-challenge-bucket-testpnoren",
//                };

//                var response = await _s3Client.ListObjectsV2Async(request);
//                var imageNames = response.S3Objects.Select(obj => obj.Key).ToList();

//                return Ok(imageNames);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Error receiving list Error receiving list of images: {ex.Message}");
//            }
//        }
//    }
//}
//גירסה *5
//using Amazon.S3;
//using Amazon.S3.Model;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ImagesController : ControllerBase
//    {
//        private readonly IAmazonS3 _s3Client;
//        private readonly string _bucketName = "photo-challenge-bucket-testpnoren";

//        public ImagesController(IAmazonS3 s3Client)
//        {
//            _s3Client = s3Client;
//        }

//        [HttpPost("upload")]
//        [Authorize]
//        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//                return BadRequest("No file uploaded");

//            var key = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

//            using var stream = file.OpenReadStream();

//            var request = new PutObjectRequest
//            {
//                BucketName = _bucketName,
//                Key = key,
//                InputStream = stream,
//                ContentType = file.ContentType
//            };

//            await _s3Client.PutObjectAsync(request);

//            var fileUrl = $"https://{_bucketName}.s3.amazonaws.com/{key}";
//            return Ok(new { message = "Upload successful", url = fileUrl });
//        }

//        [HttpGet("presigned-url")]
//        [Authorize]
//        public IActionResult GetPresignedUrl([FromQuery] string fileName)
//        {
//            var request = new GetPreSignedUrlRequest
//            {
//                BucketName = _bucketName,
//                Key = fileName,
//                Verb = HttpVerb.PUT,
//                Expires = DateTime.UtcNow.AddMinutes(5),
//                ContentType = "image/jpeg"
//            };

//            string url = _s3Client.GetPreSignedURL(request);
//        return Ok(new { url });
//    }

//    [HttpGet]
//    [Authorize]
//    public async Task<IActionResult> ListImages()
//    {
//        try
//        {
//            var request = new ListObjectsV2Request
//            {
//                BucketName = _bucketName,
//            };

//            var response = await _s3Client.ListObjectsV2Async(request);
//            var imageUrls = response.S3Objects
//                .Select(obj => $"https://{_bucketName}.s3.amazonaws.com/{obj.Key}")
//                .ToList();

//            return Ok(imageUrls);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, $"Error listing images: {ex.Message}");
//        }
//    }
//}
//}

using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;

        public ImagesController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

       // [HttpPost("upload")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("לא נבחר קובץ.");

            var fileName = Path.GetFileName(file.FileName);

            var request = new PutObjectRequest
            {
                BucketName = "photo-challenge-bucket-testpnoren",
                Key = fileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
                AutoCloseStream = true
            };

            try
            {
                var response = await _s3Client.PutObjectAsync(request);
                return Ok(new { fileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בהעלאת הקובץ: {ex.Message}");
            }
        }

        [HttpGet("presigned-url")]
        [Authorize]
        public IActionResult GetPresignedUrl([FromQuery] string fileName)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = "photo-challenge-bucket-testpnoren",
                Key = fileName,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(5),
                ContentType = "image/jpeg"
            };

            string url = _s3Client.GetPreSignedURL(request);
            return Ok(new { url });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ListImages()
        {
            try
            {
                var request = new ListObjectsV2Request
                {
                    BucketName = "photo-challenge-bucket-testpnoren",
                };

                var response = await _s3Client.ListObjectsV2Async(request);
                var imageNames = response.S3Objects.Select(obj => obj.Key).ToList();

                return Ok(imageNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בקבלת רשימת התמונות: {ex.Message}");
            }
        }
    }
}

