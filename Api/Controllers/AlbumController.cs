
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AlbumController : ControllerBase
//    {
//        // GET: api/<AlbumController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<AlbumController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<AlbumController>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<AlbumController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<AlbumController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
//---------------------------------------------------------------------------
using Api.Core.Models;
using Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAll()
        {
            var albums = await _albumService.GetAllAsync();
            return Ok(albums);
        }

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetById(int id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Album  album)
        {
            if (album == null)
            {
                return BadRequest("Image data is required");
            }
            await _albumService.AddValueAsync(album);
            return CreatedAtAction(nameof(GetById), new { id = album.Id }, album);
        }

        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Album album)
        {
            if (album == null || album.Id != id)
            {
                return BadRequest("Invalid image data");
            }
            await _albumService.PutValueAsync(album);
            return NoContent();
        }

        // פעולה למחיקת תמונה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            await _albumService.DeleteAsync(album);
            return NoContent();
        }
    }
}

