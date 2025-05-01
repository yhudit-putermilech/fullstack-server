//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Api.Core.Models
//{
//    public class Images
//    {
//        public int Id { get; set; }
//        public int UserId { get; set; }
//       // public int? AlbumId { get; set; }
//        public string FileUrl { get; set; }
//        public string FileType { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public string Tags { get; set; }

//        // קשרים
//      // public virtual User User { get; set; }
//       // public virtual Album Album { get; set; }
//    }
//}
//---------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Core.Models
{
    public class Images
    {
        public DateTime UploadDate { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "מזהה משתמש הוא חובה")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "כתובת הקובץ היא חובה")]
        [StringLength(255, ErrorMessage = "כתובת הקובץ חייבת להיות באורך מקסימלי של 255 תווים")]
        public string FileUrl { get; set; }

        [Required(ErrorMessage = "סוג הקובץ הוא חובה")]
        [StringLength(20, ErrorMessage = "סוג הקובץ חייב להיות באורך מקסימלי של 20 תווים")]
        public string FileType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(255, ErrorMessage = "התגיות חייבות להיות באורך מקסימלי של 255 תווים")]
        public string Tags { get; set; }

        // מאפייני ניווט
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<AlbumFile> AlbumFiles { get; set; }
    }
}