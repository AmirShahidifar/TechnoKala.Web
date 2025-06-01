using TechnoKala.CoreLayer.Dtos;
using TechnoKala.DataLayer.Entities;

namespace TechnoKala.CoreLayer.Servises.Permissions;

public interface IPermissionService
{
    Task<List<PermissionDto>> GetAllAsync();
    Task<PermissionDto?> GetByIdAsync(Guid id);
    Task<bool> CreatePermissionAsync(CreatePermissionDto dto);
    Task<bool> UpdatePermissionAsync(UpdatePermissionDto dto);
    Task<bool> DeletePermissionAsync(Guid id);
    Task<bool> AssignPermissionsToRoleAsync(AssignPermissionDto dto);
}
