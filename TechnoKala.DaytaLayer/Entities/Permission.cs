using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DataLayer.Entities;

public class Permission
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; }
}
