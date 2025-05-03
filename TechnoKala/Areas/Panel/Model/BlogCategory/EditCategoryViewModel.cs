using System.ComponentModel.DataAnnotations;

namespace TechnoKala.Areas.Panel.Model.BlogCategory
{
    public class EditCategoryViewModel
    {

        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string name { get; set; }
        public int? parent_id { get; set; }
    }
}
