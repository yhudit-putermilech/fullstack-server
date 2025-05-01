using Api.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicStory.CORE.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateUserAsync(string name, string password);
        Task<string> RegisterUserAsync(UserPostModel UserDto);
    }
}
}
