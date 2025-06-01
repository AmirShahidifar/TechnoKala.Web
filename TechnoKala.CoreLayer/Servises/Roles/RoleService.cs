using Microsoft.EntityFrameworkCore;
using TechnoKala.CoreLayer.Dtos.Roles;
using TechnoKala.CoreLayer.Services.Roles;
using TechnoKala.CoreLayer.Servises.Roles;
using TechnoKala.DataLayer.Entities;
using TechnoKala.DaytaLayer.Contex;

namespace TechnoKala.CoreLayer.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContex _context;

        public RoleService(AppDbContex context)
        {
            _context = context;
        }

        public async Task<bool> CreateRoleAsync(CreateRoleDto dto)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Title = dto.Title
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            if (dto.PermissionIds != null && dto.PermissionIds.Any())
            {
                var rolePermissions = dto.PermissionIds.Select(pid => new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = pid
                }).ToList();

                _context.RolePermissions.AddRange(rolePermissions);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> UpdateRoleAsync(UpdateRoleDto dto)
        {
            var role = await _context.Roles
                .Include(r => r.RolePermissions)
                .FirstOrDefaultAsync(r => r.Id == dto.Id);

            if (role == null)
                return false;

            role.Title = dto.Title;

            _context.RolePermissions.RemoveRange(role.RolePermissions);

            if (dto.PermissionIds != null && dto.PermissionIds.Any())
            {
                var newPermissions = dto.PermissionIds.Select(pid => new RolePermission
                {
                    RoleId = dto.Id,
                    PermissionId = pid
                });

                _context.RolePermissions.AddRange(newPermissions);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles
                .Include(r => r.RolePermissions)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (role == null) return false;

            _context.RolePermissions.RemoveRange(role.RolePermissions);
            _context.Roles.Remove(role);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _context.Roles
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .ToListAsync();
        }

        public async Task<List<Permission>> GetPermissionsByRoleIdAsync(Guid roleId)
        {
            return await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Include(rp => rp.Permission)
                .Select(rp => rp.Permission)
                .ToListAsync();
        }
    }
}
