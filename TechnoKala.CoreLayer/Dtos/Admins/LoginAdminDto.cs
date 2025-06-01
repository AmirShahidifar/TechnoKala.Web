using System.ComponentModel.DataAnnotations;

namespace TechnoKala.CoreLayer.Dtos.Admins
{
    public class LoginAdminDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
