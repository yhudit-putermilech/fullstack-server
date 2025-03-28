﻿/*using System;*/
using Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumFile> AlbumFiles { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
           : base(options) { }
    }
}