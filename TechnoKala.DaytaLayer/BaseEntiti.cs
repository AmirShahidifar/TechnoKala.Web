using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DaytaLayer
{
    public class BaseEntiti
    {
        [Key]
        public int id { get; set; }

        public bool is_dleated { get; set; }
        public DateTime dleated_at { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
    }
}
