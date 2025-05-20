using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoKala.DaytaLayer.Entities
{

    public class Admin
    {
        [Required(ErrorMessage = "نام کامل الزامی است")]
        [MaxLength(100, ErrorMessage = "نام کامل نمی‌تواند بیش از 100 کاراکتر باشد")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [MaxLength(50, ErrorMessage = "نام کاربری نمی‌تواند بیش از 50 کاراکتر باشد")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "نام کاربری فقط می‌تواند شامل حروف انگلیسی، اعداد و زیرخط باشد")]
        public string Username { get; set; }
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل نامعتبر است")]
        [MaxLength(100, ErrorMessage = "ایمیل نمی‌تواند بیش از 100 کاراکتر باشد")]
        public string Email { get; set; }
        [MaxLength(200, ErrorMessage = "آدرس تصویر نمی‌تواند بیش از 200 کاراکتر باشد")]
        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی است")]
        [ForeignKey("Role_id")]
        public Role Role_id { get; set; }




    }
}