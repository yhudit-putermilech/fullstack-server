//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

//namespace Api.Core.Models
//{
//    public class AlbumFile
//    {
//        public int Id { get; set; }
//        public int ImageId { get; set; }

//        // קשרים
//       // public virtual Album Album { get; set; }
//        //public virtual Images Image { get; set; }
//    }
//}
//--------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Core.Models
{
    public class AlbumFile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "מזהה אלבום הוא חובה")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "מזהה תמונה הוא חובה")]
        public int ImageId { get; set; }

        // מאפייני ניווט
        public virtual Album Album { get; set; }

        public virtual Images Image { get; set; }
    }
}