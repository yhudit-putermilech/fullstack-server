using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Api.Core.Services;
using global::Api.Core.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IS3Service _s3Service;

        public UploadController(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        // העלאת קובץ תמונה
        [HttpPost("image")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("לא הועלה קובץ.");
            }

            try
            {
                var fileUrl = await _s3Service.UploadFileAsync(file, "images");
                return Ok(new { Url = fileUrl });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // מחיקת קובץ מ-S3
        [HttpDelete("image")]
        public async Task<IActionResult> DeleteImage([FromQuery] string fileUrl)
        {
            try
            {
                await _s3Service.DeleteFileAsync(fileUrl);
                return Ok("הקובץ נמחק בהצלחה");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

