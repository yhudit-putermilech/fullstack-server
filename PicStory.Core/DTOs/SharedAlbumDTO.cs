﻿using PicStory.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicStory.CORE.DTOs
{
    public class SharedAlbumDTO
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }
        public string Permissions { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //public AlbumDTO Album { get; set; }
        //public UserDTO User { get; set; }
    }
}
