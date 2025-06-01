using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos.Roles
{
    public class CreateRoleDto
    {
        public string Title { get; set; }
        public List<Guid> PermissionIds { get; set; } = new();
    }

}
