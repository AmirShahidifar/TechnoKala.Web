using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.DaytaLayer.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace TechnoKala.DaytaLayer.Contex
{
   public class AppDbContex : DbContext
    {
        public AppDbContex (DbContextOptions<AppDbContex> options) : base(options) { }

        public DbSet<Blog> blogs { get; set; }
        public DbSet<Blog_Category> blog_Categories { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<Faq> faqs { get; set; }


    }
}
