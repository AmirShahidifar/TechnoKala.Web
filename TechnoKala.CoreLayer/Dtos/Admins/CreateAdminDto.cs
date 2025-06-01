using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos.Admins
{
    public class CreateAdminDto
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IFormFile ProfileImage { get; set; }
        public Guid RoleId { get; set; }
    }

}
