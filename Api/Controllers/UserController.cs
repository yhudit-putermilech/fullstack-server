//using Api.Core.DTOs;
//using Api.Core.Models;
//using Api.Core.Services;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
//        {
//            var users = await _userService.GetAllAsync();//מקבל מהשרת את כל הרשימה של המשתמשים
//          //usersDto משתנה שמכיל את הפרטים של המשמש
//            var usersDto = users.Select(user => new UserDTO
//            {
//                Id = user.Id,
//                Name = $"{user.FirstName} {user.LastName}",
//                Email = user.Email,
//                //האופציה של החזרת הסיסמא נירא לי רק למנהלים ולא לכולם יכול להיות שכדאי לעשות את הפונקציה הזו רק למנהלים
//                Password = user.PasswordHash
//            });
//            return Ok(usersDto);// מחזיר עם הבקשה הצליחה רשימת ממשתמשים וסטטוס הצלחה
//        }
//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserDTO>> GetUserById(int id)
//        {
//            var user = await _userService.GetByIdAsync(id);//ID חיפוש לפי 
//            if (user == null) return NotFound("Sorry 🙏,but there is no such client");//אם א מצא אומר אין  כזה לקוח
//            return Ok(new UserDTO
//            {
//                Id = user.Id,
//                Name = $"{user.FirstName} {user.LastName}",
//                Email = user.Email,
//                Password = user.PasswordHash
//            });
//        }
//        [HttpPost]
//        public async Task<ActionResult> CreateUser([FromBody] UserPostModel userModel)
//        {
//            if (userModel == null) return BadRequest("Invalid user data");//לא  הכניס ערך

//            var newUser = new User
//            {
//                FirstName = userModel.Name.Split(' ')[0], // מפריד שם פרטי ושם משפחה
//                LastName = userModel.Name.Contains(" ") ? userModel.Name.Split(' ')[1] : "",
//                Email = userModel.Email,
//                PasswordHash = userModel.Password,
//                Role = "user" // ברירת מחדל
//            };

//            await _userService.AddValueAsync(newUser);//תחכה עד שהוא מוסיף
//            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);//תיצור משתמש חדש
//        }
//        // עדכון משתמש
//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
//        {
//            var existingUser = await _userService.GetByIdAsync(id);
//            if (existingUser == null) return NotFound("User not found");

//            existingUser.FirstName = userDto.Name.Split(' ')[0];
//            existingUser.LastName = userDto.Name.Contains(" ") ? userDto.Name.Split(' ')[1] : "";
//            existingUser.Email = userDto.Email;
//            existingUser.PasswordHash = userDto.Password;

//            await _userService.PutValueAsync(existingUser);
//            return NoContent();
//        }
//        // מחיקת משתמש
//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteUser(int id)
//        {
//            var user = await _userService.GetByIdAsync(id);
//            if (user == null) return NotFound("User not found");

//            await _userService.DeleteAsync(user);
//            return NoContent();
//        }
//    }

//}
//-------------------------------------------------------------------------------------------------
using Api.Core.DTOs;
using Api.Core.Models;
using Api.Core.Services;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                var usersDto = users.Select(user => new UserDTO
                {
                    Id = user.Id,
                    Name = $"{user.FirstName} {user.LastName}",
                    Email = user.Email
                });
                return Ok(usersDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בשרת: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null) return NotFound("משתמש לא נמצא");
                return Ok(new UserDTO
                {
                    Id = user.Id,
                    Name = $"{user.FirstName} {user.LastName}",
                    Email = user.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בשרת: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserPostModel userModel)
        {
            if (userModel == null) return BadRequest("נתוני משתמש לא תקינים");

            try
            {
                var nameParts = userModel.Name.Split(' ', 2);
                var newUser = new User
                {
                    FirstName = nameParts[0],
                    LastName = nameParts.Length > 1 ? nameParts[1] : "",
                    Email = userModel.Email,
                    PasswordHash = userModel.Password,
                    Role = "user"
                };

                await _userService.AddValueAsync(newUser);
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בשרת: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            try
            {
                var existingUser = await _userService.GetByIdAsync(id);
                if (existingUser == null) return NotFound("משתמש לא נמצא");

                var nameParts = userDto.Name.Split(' ', 2);
                existingUser.FirstName = nameParts[0];
                existingUser.LastName = nameParts.Length > 1 ? nameParts[1] : "";
                existingUser.Email = userDto.Email;

                await _userService.PutValueAsync(existingUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בשרת: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null) return NotFound("משתמש לא נמצא");

                await _userService.DeleteAsync(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"שגיאה בשרת: {ex.Message}");
            }
        }
    }
}

