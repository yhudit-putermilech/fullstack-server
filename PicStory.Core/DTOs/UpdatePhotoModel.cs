﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicStory.CORE.DTOs
{
    public class UpdatePhotoModel
    {
        public string FileUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
