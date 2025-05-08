using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class AlbumFileDTO
    {
        public int Id { get; set; }
        public int ImageId { get; set; }

        // קשרים
      //  public virtual Album Album { get; set; }
       // public virtual Images Image { get; set; }
    }
}
