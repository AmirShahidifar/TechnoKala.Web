using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoKala.Areas.Panel.Model.Faq;
using TechnoKala.CoreLayer.Servises.Faqs;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(AuthenticationSchemes = "AdminAuth")]
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

        public IActionResult Edit(int id)
        {
            var faq = _faqService.GetFaqBy(id);

            var model = new Areas.Panel.Model.Faq.EditViewModel()
            {
                id = faq.id,
                title = faq.title,
                description = faq.description,
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, Areas.Panel.Model.Faq.EditViewModel editmodel)
        {
            if (editmodel == null)
            {
                ModelState.AddModelError("", "مدل ارسال شده نال است.");
                return View();
            }
            var resault = _faqService.EditFaq(new CoreLayer.Dtos.Faqs.EditFaqDtos()
            {
                title = editmodel.title,
                id = id,
                description = editmodel.description,
            });

            if (resault.Status != CoreLayer.OperationResultStatus.Success)
            {

                ModelState.AddModelError(nameof(editmodel.title), resault.Message);
                return View(editmodel);
            }

            return RedirectToAction("Index");
        }


    }
}
