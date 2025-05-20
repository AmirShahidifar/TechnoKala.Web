using System.ComponentModel.DataAnnotations;
using TechnoKala.CoreLayer.Dtos.Faqs;

namespace TechnoKala.Areas.Panel.Model.Faq
{
    public class FaqViewModel
    {

        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string title { get; set; }

        public string description { get; set; }
        public CreateFaqDtos Map()
        {
            return new CreateFaqDtos()
            {
                title = title,
                description = description,

            };
        }
    }
}

