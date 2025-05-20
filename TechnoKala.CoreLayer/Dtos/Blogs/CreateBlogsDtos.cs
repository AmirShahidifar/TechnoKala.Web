using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TechnoKala.CoreLayer.Dtos.Blogs
{
    public class CreateBlogsDtos
    {
        public int category_id { get; set; }

        [Required]
        public string title { get; set; }

        public string image { get; set; }

        public string description { get; set; }

        [AllowHtml] // اگر از اعتبارسنجی XSS نگران هستید
        public string blog_text { get; set; }

        public string? slug { get; set; }
    }
}
