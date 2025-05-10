using Microsoft.AspNetCore.Mvc;
using TechnoKala.Areas.Panel.Model.Blog;
using TechnoKala.Areas.Panel.Model.Faq;
using TechnoKala.CoreLayer.Servises.Faqs;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class FaqController : Controller
    {
     

        private readonly IFaqService _faqService;


        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 2; // تعداد آیتم‌ها در هر صفحه
            int pageNumber = (page ?? 1); // شماره صفحه، اگر null باشد، صفحه اول

            var result = _faqService.FaqDtos(pageNumber, pageSize);
          
            return View(result);
        }
        public IActionResult Add()
        {
          
            return View();

        }

        [HttpPost]
        public IActionResult Add(FaqViewModel faqViewModel)
        {

            var resault = _faqService.CreateFaq(faqViewModel.Map());
            return RedirectToAction("Index");
        }
    }
}
