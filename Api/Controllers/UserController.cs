//גירסה עובדת
//using Api.Core.DTOs;
//using Api.Core.Models;
//using Api.Core.Services;
//using Api.Serveice;
//using AutoMapper;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly IMapper _mapper;

//        public UserController(IUserService userService, IMapper mapper)
//        {
//            _userService = userService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserPostModel>>> GetAllUsers()
//        {
//            var users = await _userService.GetAllAsync();
//            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users); // תיקון כאן
//            return Ok(usersDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserPostModel>> GetUserById(int id)
//        {
//            var user = await _userService.GetByIdAsync(id);
//            if (user == null) return NotFound("משתמש לא נמצא");
//            var userDto = _mapper.Map<UserDTO>(user); // תיקון כאן
//            return Ok(userDto);
//        }

//        [HttpPost]
//        public async Task<ActionResult> CreateUser([FromBody] UserPostModel user)
//        {
//            var userToAdd = _mapper.Map<User>(user);
//            userToAdd.PasswordHash = HashPassword(user.PasswordHash); // הנח שיש מאפיין סיסמה ב-UserPostModel
//            await _userService.AddValueAsync(userToAdd);
//            return CreatedAtAction(nameof(GetUserById), new { id = userToAdd.Id }, userToAdd); // החזרת תשובה מתאימה
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserModel userDto)
//        {
//            var existingUser = await _userService.GetByIdAsync(id);
//            if (existingUser == null) return NotFound("משתמש לא נמצא");
//            existingUser.Email = userDto.Email;
//            existingUser.FirstName = userDto.FirstName;
//            await _userService.PutValueAsync(existingUser);
//            return Ok(existingUser);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteUser(int id)
//        {
//            var user = await _userService.GetByIdAsync(id);
//            if (user == null) return NotFound("משתמש לא נמצא");

//            await _userService.DeleteAsync(user);
//            return NoContent();
//        }

//        //[HttpPost("login")]
//        //public IActionResult Login([FromBody] LoginUser loginRequest)
//        //{
//        //    try
//        //    {
//        //        var result = _userService.Login(loginRequest);

//        //        if (result != null)
//        //        {
//        //            return Ok(new { userLogin = result });
//        //        }

//        //        return Unauthorized(new { Message = "Invalid username or password" });
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
//        //    }
//        //}

//        private string HashPassword(string password) // מתודה להאשת סיסמה
//        {
//            using (var hmac = new System.Security.Cryptography.HMACSHA512())
//            {
//                var hashBytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                return Convert.ToBase64String(hashBytes);
//            }
//        }
//    }
//}
using Api.Core.DTOs;
using Api.Core.Models;
using Api.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PicStory_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserService userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        // GET: api/<AlbumController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _userServices.GetAllAsync();
            var listDto = _mapper.Map<IEnumerable<User>>(list);
            return Ok(listDto);
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userServices.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(user);
        }

        // POST api/<AlbumController>
        [HttpPost]
        public async Task Post([FromBody] UserPostModel user)
        {
            var userToAdd = _mapper.Map<User>(user);
            await _userServices.AddValueAsync(userToAdd);
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUserModel userModel)
        {
            var existingUserModel = await _userServices.GetByIdAsync(id);
            if (existingUserModel != null)
            {
                existingUserModel.FirstName = userModel.FirstName;
                existingUserModel.Email = userModel.Email;

                await _userServices.PutValueAsync(existingUserModel);  // כאן אנחנו פשוט מעדכנים
                return Ok(existingUserModel);
            }

            return NoContent();  // 204 No Content

        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var album = await _userServices.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            await _userServices.DeleteAsync(album);
            return NoContent();
        }
    }
}

















































































































//----------------------------------------------------------------------------------------------------------------------
//using Api.Core.DTOs;
//using Api.Core.Models;
//using Api.Core.Services;
//using Api.Serveice;
//using AutoMapper;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly IMapper _mapper;

//        public UserController(IUserService userService, IMapper mapper)
//        {
//            _userService = userService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
//        {
//            var users = await _userService.GetAllAsync();
//            var usersDto = _mapper.Map<User>(users);
//            return Ok(usersDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDTO>> GetUserById(int id)
//        {
//            var user = await _userService.GetByIdAsync(id);
//            if (user == null) return NotFound("משתמש לא נמצא");
//            var userDto = _mapper.Map<User>(user);
//            return Ok(userDto);
//        }

//        [HttpPost]

//        public async Task CreateUser([FromBody] UserPostModel user)
//        {
//            var userToAdd = _mapper.Map<User>(user);
//            await _userService.AddValueAsync(userToAdd);
//        }
//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
//        {

//            var existingUser = await _userService.GetByIdAsync(id);
//            if (existingUser == null) return NotFound("משתמש לא נמצא");
//            existingUser.Email = userDto.Email;
//            existingUser.FirstName = userDto.FirstName;
//            await _userService.PutValueAsync(existingUser);
//            return Ok(existingUser);
//        }


//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteUser(int id)
//        {

//            var user = await _userService.GetByIdAsync(id);
//            if (user == null) return NotFound("משתמש לא נמצא");

//            await _userService.DeleteAsync(user);
//            return NoContent();


//        }
//    }
//}
//----------------------------

//-----------------------------



