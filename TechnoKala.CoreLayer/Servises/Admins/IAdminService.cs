using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Admins;
using TechnoKala.DataLayer.Entities;

namespace TechnoKala.CoreLayer.Servises.Admins
{
    public interface IAdminService
    {
        Task<bool> CreateAdminAsync(CreateAdminDto dto);
        Task<Admin> GetByIdAsync(Guid id);
        Task<List<Permission>> GetPermissionsByAdminIdAsync(Guid adminId);
    }

}
