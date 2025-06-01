using System.ComponentModel.DataAnnotations;
using TechnoKala.CoreLayer.Dtos.Blogs;

namespace TechnoKala.Areas.Panel.Model.Blog
{
    public class BlogViewModel
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string title { get; set; }
        [Required(ErrorMessage = "توضیحات را وارد کنید")]
        public string description { get; set; }
        public string blog_text { get; set; }
        public string slug { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile imageFile { get; set; }
        public string image { get; set; }
        public int category_id { get; set; }

        public CreateBlogsDtos MapToDto()
        {
            return new CreateBlogsDtos()
            {
                title = title,
                description = description,
                slug = title,
                blog_text = blog_text,
                image = image,
                category_id = category_id,

            };
        }
    }
}
