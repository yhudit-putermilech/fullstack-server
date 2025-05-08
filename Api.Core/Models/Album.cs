//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Api.Core.Models
//{
//    public class Album
//    {
//        public int Id { get; set; }
//        public int UserId { get; set; }

//        public string Name { get; set; }
//        public string Description { get; set; }
//        public DateTime CreatedAt { get; set; }

//        // קשרים
//        // public virtual User User { get; set; }
//       // public virtual List<Images> AlbumFiles { get; set; }
//        //public virtual User User { get; set; } // זה ייצור את הקשר 

//    }
//}
//--------------------------------------------------------



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Core.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "מזהה משתמש הוא חובה")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "שם האלבום הוא חובה")]
        [StringLength(100, ErrorMessage = "שם האלבום חייב להיות באורך מקסימלי של 100 תווים")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "תיאור האלבום חייב להיות באורך מקסימלי של 500 תווים")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // מאפייני ניווט
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<AlbumFile> AlbumFiles { get; set; }
    }
}