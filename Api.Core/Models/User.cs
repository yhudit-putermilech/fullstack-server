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
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } //תפקיד מנהל או משתמש

        // קשרים
        // public virtual List<Images> Images { get; set; }
       // public virtual List<Album> Albums { get; set; }
        // public virtual List<Log> Logs { get; set; }
    }
}
