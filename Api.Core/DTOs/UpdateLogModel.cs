﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class UpdateLogModel
    {
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
    }
}
