using Microsoft.AspNetCore.Mvc;
using TechnoKala.Areas.Panel.Model.Blog;
using TechnoKala.Areas.Panel.Model.BlogCategory;
using TechnoKala.CoreLayer.Servises.Blogs;
using TechnoKala.CoreLayer.Servises.Blogs_Categories;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("panel")]
    public class BlogController : Controller
    {
        private readonly IBlogsService _blogsService;
   
    
        public BlogController(IBlogsService blogsService)
        {
            _blogsService = blogsService;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 2; // تعداد آیتم‌ها در هر صفحه
            int pageNumber = (page ?? 1); // شماره صفحه، اگر null باشد، صفحه اول

            var result = _blogsService.GetAllBlogDtos(pageNumber, pageSize);
            var categories = _blogsService.GetBlogsCategories();

            ViewBag.categories = categories;
            return View(result);
        }

        public IActionResult Add()
        {
            var category = _blogsService.GetBlogsCategories();
            ViewBag.category = category;
            return View();

        }

        [HttpPost]
        public IActionResult Add(BlogViewModel blogViewModel)
        {

            if (blogViewModel.imageFile != null && blogViewModel.imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine("wwwroot", "uploads", "blogs");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(blogViewModel.imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    blogViewModel.imageFile.CopyTo(fileStream);
                }

                blogViewModel.image = "/uploads/blogs/" + uniqueFileName;
            }

            var resault = _blogsService.CreateBlogsDtos(blogViewModel.MapToDto());
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var blogs = _blogsService.GetBlogsBy(id);
            
            var model = new EditViewModel()
            {
                id = blogs.id,
                title = blogs.title,
                description = blogs.description,
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, EditViewModel editmodel)
        {
            if (editmodel == null)
            {
                ModelState.AddModelError("", "مدل ارسال شده نال است.");
                return View();
            }
            var resault = _blogsService.EditBlogsDtos(new CoreLayer.Dtos.Blogs.EditBlogsDtos()
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
 