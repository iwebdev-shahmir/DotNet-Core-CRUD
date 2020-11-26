using Microsoft.EntityFrameworkCore;
using myBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBlog.Data
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}
