using Microsoft.AspNetCore.Mvc;
using TechnoKala.Areas.Panel.Model.BlogCategory;
using TechnoKala.CoreLayer.Servises.Blogs_Categories;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogs_CategoryService _blogs_CategoryService;

        public BlogCategoryController(IBlogs_CategoryService blogs_CategoryService)
        {
            _blogs_CategoryService = blogs_CategoryService;
        }


        public IActionResult Index()
        {
            var allCategories = _blogs_CategoryService.GetAllCategories();



            return View(allCategories);
        }
        public IActionResult Add()
        {
            var child = _blogs_CategoryService.GetAllCategories();
            ViewBag.child = child;
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogCategoryViewModel categoryViewModel)
        {
            var resault = _blogs_CategoryService.CreateCategory(categoryViewModel.MapToDto());
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var blog_category = _blogs_CategoryService.GetCategoryBy(id);
            var getAllCategory = _blogs_CategoryService.GetAllCategories();
            ViewBag.getAllCategory = getAllCategory;
            if (blog_category == null)
            {
                return RedirectToAction("Index");
            }
            var model = new EditCategoryViewModel()
            {
                name = blog_category.name,
                parent_id = blog_category.parent_id,
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditCategoryViewModel editmodel)
        {
            if (editmodel == null)
            {
                ModelState.AddModelError("", "مدل ارسال شده نال است.");
                return View();
            }
            var resault = _blogs_CategoryService.EditCategory(new CoreLayer.Dtos.EditCategoryDtos()
            {
                name = editmodel.name,
                id = id,
                parent_id = editmodel.parent_id,
            });

            if (resault.Status != CoreLayer.OperationResultStatus.Success)
            {

                ModelState.AddModelError(nameof(editmodel.name), resault.Message);
                return View(editmodel);
            }

            return RedirectToAction("Index");
        }


    }
}
