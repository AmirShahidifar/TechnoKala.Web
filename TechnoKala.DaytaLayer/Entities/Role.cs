using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DaytaLayer.Entities
{
    public class Role : BaseEntiti

    {
        [Required(ErrorMessage = "عنوان دسترسی الزامی است")]
        public string RoleName { get; set; }
    }
}
