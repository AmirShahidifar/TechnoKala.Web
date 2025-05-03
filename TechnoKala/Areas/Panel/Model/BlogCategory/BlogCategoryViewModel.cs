using System.ComponentModel.DataAnnotations;
using TechnoKala.CoreLayer.Dtos;

namespace TechnoKala.Areas.Panel.Model.BlogCategory
{
    public class BlogCategoryViewModel
    {

        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string name { get; set; }
        public int? parent_id { get; set; }
        public List<BlogsCategoryDtos> BlogsCategories { get; set; }
        public CreateCategoryDtos MapToDto()
        {
            return new CreateCategoryDtos()
            {
                name = name,
                parent_id = parent_id,
              
            };
        }
    }

  
}
