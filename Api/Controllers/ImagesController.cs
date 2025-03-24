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
            var imagesDto=_mapper.Map<IEnumerable<ImagePostModel>>(images);
            return Ok(imagesDto);
        }
        
     

        // פעולה לקבלת תמונה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var image = await _imageService.GetByIdAsync(id);
            var imageDto=_mapper.Map<ImagePostModel>(image);
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
