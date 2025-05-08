//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Api.Core.Models
//{
//    public class User
//    {
//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string Email { get; set; }
//        public string PasswordHash { get; set; }
//        public string Role { get; set; } //תפקיד מנהל או משתמש

//        // קשרים
//        // public virtual List<Images> Images { get; set; }
//       // public virtual List<Album> Albums { get; set; }
//        // public virtual List<Log> Logs { get; set; }
//    }
//}
//-----------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Core.Models
{
    public class User
    {
        //public int Id { get; set; }

        //[Required(ErrorMessage = "שדה שם פרטי הוא חובה")]
        //[StringLength(50, ErrorMessage = "שם פרטי חייב להיות באורך מקסימלי של 50 תווים")]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "שדה אימייל הוא חובה")]
        //[EmailAddress(ErrorMessage = "נא להזין כתובת אימייל תקינה")]
        //[StringLength(100, ErrorMessage = "אימייל חייב להיות באורך מקסימלי של 100 תווים")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "שדה סיסמה הוא חובה")]
        //[StringLength(255, ErrorMessage = "סיסמה חייבת להיות באורך מקסימלי של 255 תווים")]
        //public string PasswordHash { get; set; }

        //[Required(ErrorMessage = "שדה תפקיד הוא חובה")]
        //[StringLength(20, ErrorMessage = "תפקיד חייב להיות באורך מקסימלי של 20 תווים")]
        //public string Role { get; set; } // מנהל או משתמש

        //// מאפייני ניווט
        //[JsonIgnore]
        //public virtual ICollection<Images> Images { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Album> Albums { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Log> Logs { get; set; }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string PasswordHash { get; set; }
        //public string Role { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //public List<Images> Photos { get; set; }
        // public List<Album> Albums { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}