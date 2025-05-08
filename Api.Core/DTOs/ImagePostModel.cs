using Api.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class ImagePostModel
    {
        public int? AlbumId { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string Tags { get; set; }

        //[Required]
        //public int UserId { get; set; }

        //public string Tags { get; set; }

        //[Required]
        //public IFormFile File { get; set; }


    }
}
