using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DataLayer.Entities;

public enum Gender
{
    Male = 0,
    Female = 1
}

public class Admin
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

    [MaxLength(200)]
    public string? ProfileImage { get; set; }

    public Gender Gender { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}
