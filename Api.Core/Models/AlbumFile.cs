using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Core.Models
{
    public class AlbumFile
    {
        public int AlbumId { get; set; }
        public int ImageId { get; set; }

        // קשרים
        public virtual Album Album { get; set; }
        public virtual Images Image { get; set; }
    }
}
