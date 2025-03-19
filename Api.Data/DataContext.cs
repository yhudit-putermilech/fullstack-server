/*using System;*/
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

    }
}
