﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicStory.CORE.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AlbumId { get; set; }
        public string FileUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // קשרים
        public User User { get; set; }
        public Album Album { get; set; }
        public List<Tag> Tags { get; set; }
        public PhotoMetadata PhotoMetadata { get; set; }
    }
}

