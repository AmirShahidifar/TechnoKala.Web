using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DaytaLayer.Entities
{
    public class Team : BaseEntiti
    {
        [Required]
        public string fullname { get; set; }
        [Required]

        public string image { get; set; }
        [Required]
        public string title { get; set; }

    }
}
