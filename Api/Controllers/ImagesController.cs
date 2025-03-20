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
using Api.Core.Models;
using Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Images>>> GetAll()
        {
            var images = await _imageService.GetAllAsync();
            return Ok(images);
        }

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<Images>> GetById(int id)
        {
            var image = await _imageService.GetByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Images image)
        {
            if (image == null)
            {
                return BadRequest("Image data is required");
            }
            await _imageService.AddValueAsync(image);
            return CreatedAtAction(nameof(GetById), new { id = image.Id }, image);
        }

        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Images image)
        {
            if (image == null || image.Id != id)
            {
                return BadRequest("Invalid image data");
            }
            await _imageService.PutValueAsync(image);
            return NoContent();
        }

        // פעולה למחיקת תמונה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _imageService.GetByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            await _imageService.DeleteAsync(image);
            return NoContent();
        }
    }
}
