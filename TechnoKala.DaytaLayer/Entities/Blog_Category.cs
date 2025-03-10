using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.DaytaLayer.Entities
{
    public class Blog_Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int name { get; set; }
        [Required]
        public int? parent_id { get; set; }




    }
}
