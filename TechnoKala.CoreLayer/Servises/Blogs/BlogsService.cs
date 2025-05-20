using Ganss.Xss;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.DaytaLayer.Contex;
using TechnoKala.DaytaLayer.Entities;
using X.PagedList;
using X.PagedList.Extensions;

namespace TechnoKala.CoreLayer.Servises.Blogs
{
    public class BlogsService : IBlogsService
    {
        private readonly AppDbContex _contex;

        public BlogsService(AppDbContex contex)
        {
            _contex = contex;
        }

        public OperationResult CreateBlogsDtos(CreateBlogsDtos command)
        {
            var sanitizedContent = SanitizeHtml(command.blog_text);

            var blogs = new Blog
            {
                title = command.title,
                category_id = command.category_id,
                description = command.description,
                blog_text = sanitizedContent,
                image = command.image,
                slug = command.slug,
            };


            _contex.blogs.Add(blogs);
            _contex.SaveChanges();
            return OperationResult.Success();
        }

        private string SanitizeHtml(string html)
        {
            // استفاده از کتابخانه مانند HtmlSanitizer
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(html);
        }

        public OperationResult EditBlogsDtos(EditBlogsDtos command)
        {
            var blogs = _contex.blogs.FirstOrDefault(b => b.id == command.id);

            if (blogs == null)

                OperationResult.NotFound();

            blogs.title = command.title;
            blogs.description = command.description;
            blogs.created_at = DateTime.Now;
            _contex.SaveChanges();
            return OperationResult.Success();

        }

        public IPagedList<GetAllBlogDtos> GetAllBlogDtos(int pageNumber, int pageSize)
        {
            var blogsQuery = _contex.blogs
                .Select(blog => new GetAllBlogDtos
                {
                    id = blog.id,
                    title = blog.title,
                    description = blog.description,
                    category_id = blog.category_id,
                    image = blog.image
                })
                .OrderBy(b => b.id); // مرتب‌سازی بر اساس Id یا هر فیلد دیگر

            return blogsQuery.ToPagedList(pageNumber, pageSize);
        }

        public GetAllBlogDtos GetBlogsBy(int id)
        {

            var blogs = _contex.blogs.FirstOrDefault(b => b.id == id);
            return blogs == null ? null : new GetAllBlogDtos
            {
                id = blogs.id,
                category_id = blogs.category_id,
                title = blogs.title,
                image = blogs.image,
                description = blogs.description,
                slug = blogs.slug
            };





        }

        public List<BlogsCategoryDtos> GetBlogsCategories()
        {
            return _contex.blog_Categories.Where(c => c.parent_id != null).Select(category => new BlogsCategoryDtos
            {
                name = category.name,
                id = category.id,

            }).ToList();

        }
    }
}
