using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.DaytaLayer.Entities
{
    public class Blog_Category : BaseEntiti
    {

        [Required]
        public string name { get; set; }
  
        public int? parent_id { get; set; }

    
    }
}
