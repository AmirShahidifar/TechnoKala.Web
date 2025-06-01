using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechnoKala.CoreLayer.Dtos.Admins;
using TechnoKala.CoreLayer.Servises.Admins;
using TechnoKala.DataLayer.Entities;
using TechnoKala.DaytaLayer.Contex;

public class AdminAuthService : IAdminAuthService
{
    private readonly AppDbContex _context;
    private readonly IPasswordHasher<Admin> _passwordHasher;

    public AdminAuthService(AppDbContex context, IPasswordHasher<Admin> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<Admin?> LoginAsync(LoginAdminDto dto)
    {
        var admin = await _context.Admins
            .Include(a => a.Role)
            .FirstOrDefaultAsync(a => a.Username == dto.Username);

        if (admin == null)
            return null;

        var result = _passwordHasher.VerifyHashedPassword(admin, admin.PasswordHash, dto.Password);
        return result == PasswordVerificationResult.Success ? admin : null;
    }
}
