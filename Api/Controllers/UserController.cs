using Api.Core.DTOs;
using Api.Core.Models;
using Api.Core.Services;
using Api.Serveice;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPostModel>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users); // תיקון כאן
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserPostModel>> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound("משתמש לא נמצא");
            var userDto = _mapper.Map<UserDTO>(user); // תיקון כאן
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserPostModel user)
        {
            var userToAdd = _mapper.Map<User>(user);
            userToAdd.PasswordHash = HashPassword(user.PasswordHash); // הנח שיש מאפיין סיסמה ב-UserPostModel
            await _userService.AddValueAsync(userToAdd);
            return CreatedAtAction(nameof(GetUserById), new { id = userToAdd.Id }, userToAdd); // החזרת תשובה מתאימה
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserModel userDto)
        {
            var existingUser = await _userService.GetByIdAsync(id);
            if (existingUser == null) return NotFound("משתמש לא נמצא");
            existingUser.Email = userDto.Email;
            existingUser.FirstName = userDto.FirstName;
            await _userService.PutValueAsync(existingUser);
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound("משתמש לא נמצא");

            await _userService.DeleteAsync(user);
            return NoContent();
        }

        private string HashPassword(string password) // מתודה להאשת סיסמה
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var hashBytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
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