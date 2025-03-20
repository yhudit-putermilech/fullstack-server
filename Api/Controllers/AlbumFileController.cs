//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AlbumFileController : ControllerBase
//    {
//        // GET: api/<AlbumFileController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<AlbumFileController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<AlbumFileController>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<AlbumFileController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<AlbumFileController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
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
    public class AlbumFileController : ControllerBase
    {
        private readonly IAlbumFileService _albumFileService;

        public AlbumFileController(IAlbumFileService albumFileService)
        {
            _albumFileService = albumFileService;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumFile>>> GetAll()
        {
            var albumFiles = await _albumFileService.GetAllAsync();
            return Ok(albumFiles);
        }

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumFile>> GetById(int id)
        {
            var albumFile = await _albumFileService.GetByIdAsync(id);
            if (albumFile == null)
            {
                return NotFound();
            }
            return Ok(albumFile);
        }

        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AlbumFile albumFile)
        {
            if (albumFile == null)
            {
                return BadRequest("Image data is required");
            }
            await _albumFileService.AddValueAsync(albumFile);
            return CreatedAtAction(nameof(GetById), new { id = albumFile.Id }, albumFile);
        }

        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AlbumFile albumFile)
        {
            if (albumFile == null)
            {
                return BadRequest("Invalid image data");
            }
            await _albumFileService.PutValueAsync(albumFile);
            return NoContent();
        }

        // פעולה למחיקת תמונה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var albumFile = await _albumFileService.GetByIdAsync(id);
            if (albumFile == null)
            {
                return NotFound();
            }
            await _albumFileService.DeleteAsync(albumFile);
            return NoContent();
        }
    }
}
