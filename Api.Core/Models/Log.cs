//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Api.Core.Models
//{
//    public class Log
//    {
//        public int Id { get; set; }
//        public int UserId { get; set; }
//        public string Action { get; set; }
//        public string Description { get; set; }
//        public DateTime CreatedAt { get; set; }

//        // קשרים
//       // public virtual User User { get; set; }
//    }
//}
//-------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Core.Models
{
    public class Log
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "מזהה משתמש הוא חובה")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "סוג הפעולה הוא חובה")]
        [StringLength(100, ErrorMessage = "סוג הפעולה חייב להיות באורך מקסימלי של 100 תווים")]
        public string Action { get; set; }

        [StringLength(500, ErrorMessage = "תיאור הפעולה חייב להיות באורך מקסימלי של 500 תווים")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // מאפייני ניווט
        public virtual User User { get; set; }
    }
}