using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos
{
    public class AssignPermissionDto
    {
        public Guid RoleId { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }

}
