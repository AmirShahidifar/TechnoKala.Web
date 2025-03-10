using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.DaytaLayer.Entities
{
   public class Blog
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int category_id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public string description { get; set; }
        public string? slug { get; set; }

        public DateTime created_at { get; set; }

        [ForeignKey("category_id")]

        public Blog_Category blog_Category { get; set; }
    }
}
