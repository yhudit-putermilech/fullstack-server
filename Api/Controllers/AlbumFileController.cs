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
    public class AlbumFileController : ControllerBase
    {
        private readonly IAlbumFileService _albumFileService;
        private readonly IMapper _mapper;
        public AlbumFileController(IAlbumFileService albumFileService, IMapper mapper)
        {
            _albumFileService = albumFileService;
            _mapper = mapper;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<AlbumFilePostModel>>> GetAll()
        //{
        //    var albumFiles = await _albumFileService.GetAllAsync();
        //    var albumFilesDto=_mapper.Map<AlbumFileDTO>(albumFiles);
        //    return Ok(albumFilesDto);
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumFileDTO>>> GetAll()
        {
            var albumFiles = await _albumFileService.GetAllAsync();
            var albumFilesDto = _mapper.Map<IEnumerable<AlbumFileDTO>>(albumFiles);
            return Ok(albumFilesDto);
        }

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var albumFile = await _albumFileService.GetByIdAsync(id);
            var albumFileDto=_mapper.Map<AlbumFileDTO>(albumFile);
            return Ok(albumFileDto);
        }
          
        
         
        
        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task Add([FromBody] AlbumFilePostModel albumFile)
        {
            var existingAlbum = _mapper.Map<AlbumFile>(albumFile);
            await _albumFileService.AddValueAsync(existingAlbum);
        }

        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateAlbumFileModel albumFile)
        {
            var existingAlbum = await _albumFileService.GetByIdAsync(id);
            if (existingAlbum != null)
            {
                existingAlbum.ImageId = albumFile.ImageId;
                await _albumFileService.PutValueAsync(existingAlbum);  // כאן אנחנו פשוט מעדכנים
                return Ok(existingAlbum);
            }

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
