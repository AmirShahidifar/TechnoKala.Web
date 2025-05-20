using System.ComponentModel.DataAnnotations;

namespace TechnoKala.DaytaLayer.Entities
{
    public class Blog_Category : BaseEntiti
    {

        [Required]
        public string name { get; set; }

        public int? parent_id { get; set; }


    }
}
