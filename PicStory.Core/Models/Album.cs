﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicStory.CORE.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public  string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // קשר עם משתמשים לשיתוף
        [JsonIgnore] // מונע בעיה של קשרים מעגליים
        public User User { get; set; }
        public List<Photo> Photos { get; set; }
        public List<SharedAlbum> SharedAlbums { get; set; }
    }
}

