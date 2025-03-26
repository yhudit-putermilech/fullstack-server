using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class AlbumDTO
    {
        public int Id { get; set; }
       public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // קשרים
        //public virtual User User { get; set; }
       // public virtual List<AlbumFile> AlbumFiles { get; set; }
    }
}
