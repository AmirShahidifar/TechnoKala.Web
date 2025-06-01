using Microsoft.EntityFrameworkCore;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.CoreLayer.Servises.Permissions;
using TechnoKala.DataLayer.Entities;
using TechnoKala.DaytaLayer.Contex;

public class PermissionService : IPermissionService
{
    private readonly AppDbContex _context;

    public PermissionService(AppDbContex context)
    {
        _context = context;
    }

    public async Task<List<PermissionDto>> GetAllAsync()
    {
        return await _context.Permissions
            .Select(p => new PermissionDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
    }

    public async Task<PermissionDto?> GetByIdAsync(Guid id)
    {
        var permission = await _context.Permissions.FindAsync(id);
        if (permission == null) return null;

        return new PermissionDto
        {
            Id = permission.Id,
            Name = permission.Name
        };
    }

    public async Task<bool> CreatePermissionAsync(CreatePermissionDto dto)
    {
        var permission = new Permission
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        };

        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePermissionAsync(UpdatePermissionDto dto)
    {
        var permission = await _context.Permissions.FindAsync(dto.Id);
        if (permission == null) return false;

        permission.Name = dto.Name;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePermissionAsync(Guid id)
    {
        var permission = await _context.Permissions.FindAsync(id);
        if (permission == null) return false;

        _context.Permissions.Remove(permission);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AssignPermissionsToRoleAsync(AssignPermissionDto dto)
    {
        var existing = await _context.RolePermissions
            .Where(rp => rp.RoleId == dto.RoleId)
            .ToListAsync();

        _context.RolePermissions.RemoveRange(existing);

        foreach (var pid in dto.PermissionIds)
        {
            _context.RolePermissions.Add(new RolePermission
            {
                RoleId = dto.RoleId,
                PermissionId = pid
            });
        }

        await _context.SaveChangesAsync();
        return true;
    }
}
