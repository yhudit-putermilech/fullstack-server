using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByNameAsync(string name);
        Task<User> CreateUserAsync(User user);
    }
}
