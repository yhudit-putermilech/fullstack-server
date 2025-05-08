using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class UpdateImagesModel
    {
        public int? AlbumId { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
    }
}
