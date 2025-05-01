using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class AlbumFilePostModel
    {
        public int AlbumId { get; set; }  // הוספת שדה שחסר

        public int ImageId { get; set; }
    }
}
