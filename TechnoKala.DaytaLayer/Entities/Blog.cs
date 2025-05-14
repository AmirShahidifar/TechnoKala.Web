using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.DaytaLayer.Entities
{
   public class Blog : BaseEntiti
    {
    
        [Required]
        public int category_id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
  
        public string image { get; set; }
        [Required]
        [MaxLength(30)]
        public string description { get; set; }
        [Required]
        public string blog_text { get; set; }
        public string? slug { get; set; }
      

        [ForeignKey("category_id")]

        public Blog_Category blog_Category { get; set; }
    }
}
