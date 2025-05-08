/*using Api.Core.DTOs;
using Api.Core.Models;
using Api.Core.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService ,IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var albums = await _albumService.GetAllAsync();
            var albumsDto=_mapper.Map<IEnumerable<Album>>(albums);
            return Ok(albums);
        }

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var album = await _albumService.GetByIdAsync(id);
            var albumDto = _mapper.Map<AlbumDTO>(album);
            return Ok(albumDto);
        }

        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task<IActionResult> Add(int id,[FromBody] AlbumPostModel  album)
        {
            var existingAlbum = await _albumService.GetByIdAsync(id);
            if (existingAlbum != null)
            {
                existingAlbum.Description = album.Description;
                existingAlbum.Name = album.Name;

                await _albumService.PutValueAsync(existingAlbum);  // כאן אנחנו פשוט מעדכנים
                return Ok(existingAlbum);
            }

            return NoContent();  // 204 No Content
        }

        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AlbumPostModel album)
        {
            var existingAlbum = await _albumService.GetByIdAsync(id);
            if (existingAlbum != null)
            {
                existingAlbum.Description = album.Description;
                existingAlbum.Name = album.Name;

                await _albumService.PutValueAsync(existingAlbum);  // כאן אנחנו פשוט מעדכנים
                return Ok(existingAlbum);
            }

            return NoContent();  // 204 No Content
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
*/
//גירסה אחת אחרונה
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
//    public class AlbumController : ControllerBase
//    {
//        private readonly IAlbumService _albumService;
//        private readonly IMapper _mapper;

//        public AlbumController(IAlbumService albumService, IMapper mapper)
//        {
//            _albumService = albumService;
//            _mapper = mapper;
//        }

//        // פעולה לקבלת כל התמונות
//        [HttpGet]
//        public async Task<ActionResult> GetAll()
//        {
//            var albums = await _albumService.GetAllAsync();
//            var albumsDto = _mapper.Map<IEnumerable<AlbumPostModel>>(albums);
//            return Ok(albumsDto);
//        }

//        // פעולה לקבלת תמונה לפי מזהה
//        [HttpGet("{id}")]
//        public async Task<ActionResult> GetById(int id)
//        {
//            var album = await _albumService.GetByIdAsync(id);
//            if (album == null)
//            {
//                return NotFound();
//            }
//            var albumDto = _mapper.Map<AlbumPostModel>(album);
//            return Ok(albumDto);
//        }

//        // פעולה להוספת תמונה חדשה
//        [HttpPost]
//        public async Task Add([FromBody] AlbumPostModel album)
//        {
//            var existingAlbum = _mapper.Map<Album>(album);
//            await _albumService.AddValueAsync(existingAlbum);
//        }
//        // פעולה לעדכון תמונה קיימת
//        [HttpPut("{id}")]
//        public async Task<ActionResult> Update(int id, [FromBody] UpdateAlbumModel album)
//        {
//            if (album == null)
//            {
//                return BadRequest("Invalid album data.");
//            }

//            var existingAlbum = await _albumService.GetByIdAsync(id);
//            if (existingAlbum == null)
//            {
//                return NotFound();
//            }

//            existingAlbum.Description = album.Description;
//            existingAlbum.Name = album.Name;

//            await _albumService.PutValueAsync(existingAlbum);
//            var albumDto = _mapper.Map<AlbumDTO>(existingAlbum);
//            return Ok(albumDto);
//        }

//        // פעולה למחיקת תמונה
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var album = await _albumService.GetByIdAsync(id);
//            if (album == null)
//            {
//                return NotFound();
//            }
//            await _albumService.DeleteAsync(album);
//            return NoContent();
//        }
//    }
//}

using Api.Core.DTOs;
using Api.Core.Models;
using Api.Core.Services;
using Api.Serveice;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var albums = await _albumService.GetAllAsync();
            var albumsDto = _mapper.Map<IEnumerable<AlbumPostModel>>(albums);
            return Ok(albumsDto);
        }

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            var albumDto = _mapper.Map<AlbumPostModel>(album);
            return Ok(albumDto);
        }

        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task Add([FromBody] AlbumPostModel album)
        {
            var existingAlbum = _mapper.Map<Album>(album);
            await _albumService.AddValueAsync(existingAlbum);
        }
        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateAlbumModel album)
        {
            if (album == null)
            {
                return BadRequest("Invalid album data.");
            }

            var existingAlbum = await _albumService.GetByIdAsync(id);
            if (existingAlbum == null)
            {
                return NotFound();
            }

            existingAlbum.Description = album.Description;
            existingAlbum.Name = album.Name;

            await _albumService.PutValueAsync(existingAlbum);
            var albumDto = _mapper.Map<AlbumDTO>(existingAlbum);
            return Ok(albumDto);
        }

        // פעולה למחיקת תמונה
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
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



