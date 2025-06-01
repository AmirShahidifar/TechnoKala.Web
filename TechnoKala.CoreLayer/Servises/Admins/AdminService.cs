
using TechnoKala.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TechnoKala.CoreLayer.Dtos.Admins;
using TechnoKala.CoreLayer.Servises.Admins;
using TechnoKala.DaytaLayer.Contex;

public class AdminService : IAdminService
{
    private readonly AppDbContex _context;
    private readonly IPasswordHasher<Admin> _passwordHasher;

    public AdminService(AppDbContex context, IPasswordHasher<Admin> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> CreateAdminAsync(CreateAdminDto dto)
    {
        var admin = new Admin
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Username = dto.Username,
            Email = dto.Email,
            RoleId = dto.RoleId
        };

        admin.PasswordHash = _passwordHasher.HashPassword(admin, dto.Password);

        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Admin> GetByIdAsync(Guid id)
    {
        var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == id);

        if (admin != null)
        {
            admin.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == admin.RoleId);
        }

        return admin;
    }

    public async Task<List<Permission>> GetPermissionsByAdminIdAsync(Guid adminId)
    {
        var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminId);

        if (admin == null) return new List<Permission>();

        var rolePermissions = await _context.RolePermissions
            .Where(rp => rp.RoleId == admin.RoleId)
            .ToListAsync();

        var permissions = new List<Permission>();

        foreach (var rp in rolePermissions)
        {
            var permission = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == rp.PermissionId);
            if (permission != null)
                permissions.Add(permission);
        }

        return permissions;
    }
}
