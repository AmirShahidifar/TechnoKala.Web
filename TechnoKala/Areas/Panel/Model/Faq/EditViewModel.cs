using System.ComponentModel.DataAnnotations;

namespace TechnoKala.Areas.Panel.Model.Faq
{
    public class EditViewModel
    {

        public int id { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string title { get; set; }
        public string description { get; set; }

    }
}
