using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
