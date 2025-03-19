using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // user/admin

        // קשרים
        public virtual List<Image> Images { get; set; }
        public virtual List<Album> Albums { get; set; }
        public virtual List<Log> Logs { get; set; }
    }
}
