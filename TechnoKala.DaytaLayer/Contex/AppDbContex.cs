using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TechnoKala.DaytaLayer.Entities;
using TechnoKala.DataLayer.Entities;

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

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            builder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            // 📌 SEED ROLES
            var adminRoleId = Guid.NewGuid();
            var editorRoleId = Guid.NewGuid();

            builder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, Title = "مدیر کل" },
                new Role { Id = editorRoleId, Title = "ویرایشگر محتوا" }
            );

            // 📌 SEED PERMISSIONS
            var blogCreate = Guid.NewGuid();
            var blogEdit = Guid.NewGuid();
            var blogDelete = Guid.NewGuid();

            builder.Entity<Permission>().HasData(
                new Permission { Id = blogCreate, Name = "Blog.Create" },
                new Permission { Id = blogEdit, Name = "Blog.Edit" },
                new Permission { Id = blogDelete, Name = "Blog.Delete" }
            );

            // 📌 SEED ROLE-PERMISSIONS برای مدیر کل
            builder.Entity<RolePermission>().HasData(
                new RolePermission { RoleId = adminRoleId, PermissionId = blogCreate },
                new RolePermission { RoleId = adminRoleId, PermissionId = blogEdit },
                new RolePermission { RoleId = adminRoleId, PermissionId = blogDelete }
            );

            // 📌 SEED ROLE-PERMISSIONS برای ویرایشگر
            builder.Entity<RolePermission>().HasData(
                new RolePermission { RoleId = editorRoleId, PermissionId = blogEdit }
            );
        }



    }
}
