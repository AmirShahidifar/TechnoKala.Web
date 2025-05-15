using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
