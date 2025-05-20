using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DaytaLayer.Entities
{
    public class Users : BaseEntiti
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }




    }
}
