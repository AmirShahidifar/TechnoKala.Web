using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoKala.Areas.Panel.Model.Blog;
using TechnoKala.CoreLayer.Servises.Blogs;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(AuthenticationSchemes = "AdminAuth")]
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

        [HttpPost]
        [Route("/Upload/Article")]
        public async Task<IActionResult> UploadArticle(IFormFile upload, string CKEditorFuncNum, string langCode)
        {
            try
            {
                // 1. اعتبارسنجی فایل
                if (upload == null || upload.Length == 0)
                    return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", '', 'فایلی انتخاب نشده است');</script>");

                // 2. بررسی نوع فایل
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf" };
                var extension = Path.GetExtension(upload.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
                    return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", '', 'فرمت فایل مجاز نیست');</script>");

                // 3. ایجاد پوشه مورد نظر
                var uploadsFolder = Path.Combine("wwwroot", "uploads", "ckeditor");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // 4. ایجاد نام یکتا برای فایل
                var fileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(uploadsFolder, fileName);

                // 5. ذخیره فایل
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                // 6. برگرداندن نتیجه به CKEditor
                var url = $"{Request.Scheme}://{Request.Host}/uploads/ckeditor/{fileName}";
                return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", '" + url + "', 'فایل با موفقیت آپلود شد');</script>");
            }
            catch (Exception ex)
            {
                return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", '', 'خطا در آپلود فایل: " + ex.Message + "');</script>");
            }
        }

        public IActionResult Delete(int id)
        {
            var blogs = _blogsService.DeleteBlogs(id);
            var text = "حذف با موفقیت انجام شد";
            ViewBag.text = text;
            return RedirectToAction("Index");

        }
    }




}
