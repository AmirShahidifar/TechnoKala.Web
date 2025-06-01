using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Roles;
using TechnoKala.DataLayer.Entities;

namespace TechnoKala.CoreLayer.Servises.Roles
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(CreateRoleDto dto);
        Task<bool> UpdateRoleAsync(UpdateRoleDto dto);
        Task<bool> DeleteRoleAsync(Guid id);
        Task<Role?> GetByIdAsync(Guid id);
        Task<List<Role>> GetAllAsync();
        Task<List<Permission>> GetPermissionsByRoleIdAsync(Guid roleId);
    }

}
