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
//    public class AlbumFileController : ControllerBase
//    {
//        private readonly IAlbumFileService _albumFileService;
//        private readonly IMapper _mapper;
//        public AlbumFileController(IAlbumFileService albumFileService, IMapper mapper)
//        {
//            _albumFileService = albumFileService;
//            _mapper = mapper;
//        }

//        // פעולה לקבלת כל התמונות
//        [HttpGet]
//        //public async Task<ActionResult<IEnumerable<AlbumFilePostModel>>> GetAll()
//        //{
//        //    var albumFiles = await _albumFileService.GetAllAsync();
//        //    var albumFilesDto=_mapper.Map<AlbumFileDTO>(albumFiles);
//        //    return Ok(albumFilesDto);
//        //}
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<AlbumFileDTO>>> GetAll()
//        {
//            var albumFiles = await _albumFileService.GetAllAsync();
//            var albumFilesDto = _mapper.Map<IEnumerable<AlbumFileDTO>>(albumFiles);
//            return Ok(albumFilesDto);
//        }

//        // פעולה לקבלת תמונה לפי מזהה
//        [HttpGet("{id}")]
//        public async Task<ActionResult> GetById(int id)
//        {
//            var albumFile = await _albumFileService.GetByIdAsync(id);
//            var albumFileDto = _mapper.Map<AlbumFileDTO>(albumFile);
//            return Ok(albumFileDto);
//        }




//        // פעולה להוספת תמונה חדשה
//        [HttpPost]
//        public async Task Add([FromBody] AlbumFilePostModel albumFile)
//        {
//            var existingAlbum = _mapper.Map<AlbumFile>(albumFile);
//            await _albumFileService.AddValueAsync(existingAlbum);
//        }

//        // פעולה לעדכון תמונה קיימת
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] UpdateAlbumFileModel albumFile)
//        {
//            var existingAlbum = await _albumFileService.GetByIdAsync(id);
//            if (existingAlbum != null)
//            {
//                existingAlbum.ImageId = albumFile.ImageId;
//                await _albumFileService.PutValueAsync(existingAlbum);  // כאן אנחנו פשוט מעדכנים
//                return Ok(existingAlbum);
//            }

//            return NoContent();
//        }

//        // פעולה למחיקת תמונה
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var albumFile = await _albumFileService.GetByIdAsync(id);
//            if (albumFile == null)
//            {
//                return NotFound();
//            }
//            await _albumFileService.DeleteAsync(albumFile);
//            return NoContent();
//        }
//    }
//}
////using System;
////using System.Collections.Generic;
////using System.Threading.Tasks;
////using Api.Core.DTOs;
////using Api.Core.Models;
////using Api.Core.Services;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;

////namespace Api.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class AlbumFilesController : ControllerBase
////    {
//        private readonly IAlbumFileService _context;

//        public AlbumFilesController(IAlbumFileService context)
//        {
//            _context = context;
//        }

//        // GET: api/AlbumFiles
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<AlbumFileDTO>>> GetAlbumFiles()
//        {
//            var albumFiles = await _context.AlbumFiles.ToListAsync();
//            var result = new List<AlbumFileDTO>();

//            foreach (var file in albumFiles)
//            {
//                result.Add(new AlbumFileDTO
//                {
//                    Id = file.Id,
//                    AlbumId = file.AlbumId,
//                    ImageId = file.ImageId
//                });
//            }

//            return result;
//        }

//        // GET: api/AlbumFiles/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<AlbumFileDTO>> GetAlbumFile(int id)
//        {
//            var albumFile = await _context.AlbumFiles.FindAsync(id);

//            if (albumFile == null)
//            {
//                return NotFound();
//            }

//            return new AlbumFileDTO
//            {
//                Id = albumFile.Id,
//                AlbumId = albumFile.AlbumId,
//                ImageId = albumFile.ImageId
//            };
//        }

//        // PUT: api/AlbumFiles/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAlbumFile(int id, UpdateAlbumFileModel model)
//        {
//            // בדיקה שהמודל תקין
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            // קבלת הרשומה הקיימת
//            var albumFile = await _context.AlbumFiles.FindAsync(id);
//            if (albumFile == null)
//            {
//                return NotFound();
//            }

//            // עדכון הנתונים
//            albumFile.AlbumId = model.AlbumId;
//            albumFile.ImageId = model.ImageId;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AlbumFileExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/AlbumFiles
//        [HttpPost]
//        public async Task<ActionResult<AlbumFileDTO>> PostAlbumFile(AlbumFilePostModel model)
//        {
//            var albumFile = new AlbumFile
//            {
//                AlbumId = model.AlbumId,
//                ImageId = model.ImageId
//            };

//            _context.AlbumFiles.Add(albumFile);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(
//                nameof(GetAlbumFile),
//                new { id = albumFile.Id },
//                new AlbumFileDTO
//                {
//                    Id = albumFile.Id,
//                    AlbumId = albumFile.AlbumId,
//                    ImageId = albumFile.ImageId
//                });
//        }

//        // DELETE: api/AlbumFiles/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAlbumFile(int id)
//        {
//            var albumFile = await _context.AlbumFiles.FindAsync(id);
//            if (albumFile == null)
//            {
//                return NotFound();
//            }

//            _context.AlbumFiles.Remove(albumFile);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool AlbumFileExists(int id)
//        {
//            return _context.AlbumFiles.Any(e => e.Id == id);
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
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        // פעולה לקבלת כל התמונות
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var images = await _imageService.GetAllAsync();
            var imagesDto = _mapper.Map<IEnumerable<ImagePostModel>>(images);
            return Ok(imagesDto);
        }



        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var image = await _imageService.GetByIdAsync(id);
            var imageDto = _mapper.Map<ImagePostModel>(image);
            return Ok(imageDto);
        }

        // פעולה להוספת תמונה חדשה
        [HttpPost]
        public async Task Add([FromBody] ImagePostModel image)
        {
            var photoMetadataToAdd = _mapper.Map<Images>(image);
            await _imageService.AddValueAsync(photoMetadataToAdd);
        }

        // פעולה לעדכון תמונה קיימת
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateImagesModel photoMetadataModel)
        {
            var existingPhotoMetadataModel = await _imageService.GetByIdAsync(id);
            if (existingPhotoMetadataModel != null)
            {
                existingPhotoMetadataModel.FileUrl = photoMetadataModel.FileUrl;
                existingPhotoMetadataModel.FileType = photoMetadataModel.FileType;

                await _imageService.PutValueAsync(existingPhotoMetadataModel);  // כאן אנחנו פשוט מעדכנים
                return Ok(existingPhotoMetadataModel);
            }

            return NoContent();
        }

        // פעולה למחיקת תמונה
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
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
