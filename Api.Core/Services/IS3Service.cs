using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Api.Core.Services
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file, string prefix = "");
        Task DeleteFileAsync(string fileUrl);
        Task<bool> FileExistsAsync(string fileUrl);
        Task<Dictionary<string, string>> GetFileMetadataAsync(string fileUrl);
    }
}
