using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    public class Images
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       // public int? AlbumId { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Tags { get; set; }

        // קשרים
      // public virtual User User { get; set; }
       // public virtual Album Album { get; set; }
    }
}
