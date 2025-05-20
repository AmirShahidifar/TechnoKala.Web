using Microsoft.EntityFrameworkCore;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.DaytaLayer.Contex
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options) { }

        public DbSet<Blog> blogs { get; set; }
        public DbSet<Blog_Category> blog_Categories { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<Faq> faqs { get; set; }

        public DbSet<Team> teams { get; set; }


    }
}
