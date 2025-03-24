using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class ImagePostModel
    {
       // public int? AlbumId { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string Tags { get; set; }
    }
}
