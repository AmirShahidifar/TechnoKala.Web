using TechnoKala.CoreLayer.Dtos.Faqs;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.CoreLayer.Mapper
{
    public class FaqMapper
    {

        public static Faq Map(CreateFaqDtos createFaqDtos) => new Faq()
        {
            title = createFaqDtos.title,
            description = createFaqDtos.description,


        };
    }
}
