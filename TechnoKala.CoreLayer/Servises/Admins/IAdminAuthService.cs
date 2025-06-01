using TechnoKala.CoreLayer.Dtos.Admins;
using TechnoKala.DataLayer.Entities;

namespace TechnoKala.CoreLayer.Servises.Admins
{
    public interface IAdminAuthService
    {
        Task<Admin?> LoginAsync(LoginAdminDto dto);
    }
}
