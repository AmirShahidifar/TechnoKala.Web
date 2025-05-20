using TechnoKala.CoreLayer.Dtos;
using TechnoKala.CoreLayer.Mapper;
using TechnoKala.DaytaLayer.Contex;
using TechnoKala.DaytaLayer.Entities;
using X.PagedList.Extensions;

namespace TechnoKala.CoreLayer.Servises.Blogs_Categories
{

    public class BlogsCtegoryService : IBlogs_CategoryService
    {
        private readonly AppDbContex _context;

        public BlogsCtegoryService(AppDbContex context)
        {
            _context = context;
        }



        public OperationResult CreateCategory(CreateCategoryDtos command)
        {

            var blog_category = new Blog_Category()
            {
                name = command.name,
                parent_id = command.parent_id,
            };

            _context.blog_Categories.Add(blog_category);
            _context.SaveChanges();
            return OperationResult.Success();


        }

        //public OperationResult DleteCategory(DleteCategoryDtos dleteCategoryDtos)
        //{
        //    var blogcategory = _context.blog_Categories.FirstOrDefault(c => c.id == DleteCategoryDtos.id);
        //}

        public List<BlogsCategoryDtos> GetAllCategories()
        {
            var categories = _context.blog_Categories
                .OrderBy(c => c.id)
                .ToList();

            return categories.Select(category => new BlogsCategoryDtos
            {

                id = category.id,
                name = category.name,
                parent_id = category.parent_id,
                parent_name = category.parent_id != null
                    ? _context.blog_Categories.FirstOrDefault(c => c.id == category.parent_id)?.name ?? "دسته بندی اصلی"
                    : "دسته بندی اصلی"
            }).ToList();
        }

        //public BcategoryDto GetBlogsCategoryByfilter(int pageid, int take, string name)
        //{
        //    var result = _context.blog_Categories.OrderByDescending(c => c.name).AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(name))
        //        result = result.Where(r => r.name == name);

        //    var skip = (pageid - 1) * take;
        //    var pagecount = (int)Math.Ceiling((double)result.Count() / take); // محاسبه صحیح PageCount

        //    return new BcategoryDto()
        //    {
        //        BlogsCategories = result.Skip(skip).Take(take).Select(blogcategory => BlogCategoryMapper.Map(blogcategory)).ToList(), // اصلاح پرانتزها

        //        PageCount = pagecount,
        //        pageid = pageid,
        //        take = take
        //    };
        //}

        public BlogsCategoryDtos GetCategoryBy(int id)
        {
            var blogcategory = _context.blog_Categories.FirstOrDefault(b => b.id == id);

            if (blogcategory == null)
                return null; // اگر دسته‌بندی پیدا نشد، نال برمی‌گرداند

            return BlogCategoryMapper.Map(blogcategory);


        }

        public List<BlogsCategoryDtos> GetChildBlogCategory()
        {
            throw new NotImplementedException();
        }

        //public IPagedList<BlogsCategoryDtos> GetAllCategories(int pageNumber = 1, int pageSize = 10)
        //{
        //    var categories = _context.blog_Categories
        //        .OrderBy(c => c.id)
        //        .ToPagedList(pageNumber, pageSize);

        //    return categories.Select(category => new BlogsCategoryDtos
        //    {
        //        id = category.id,
        //        name = category.name,
        //        parent_id = category.parent_id,
        //        parent_name = category.parent_id != null
        //            ? _context.blog_Categories.FirstOrDefault(c => c.id == category.parent_id)?.name ?? "دسته بندی اصلی"
        //            : "دسته بندی اصلی"
        //    }).ToPagedList(pageNumber, pageSize);
        //}

        OperationResult IBlogs_CategoryService.EditCategory(EditCategoryDtos editCategoryDtos)
        {
            var blogcategory = _context.blog_Categories.FirstOrDefault(c => c.id == editCategoryDtos.id);
            var categories = _context.blog_Categories.ToList();

            if (blogcategory == null)
                return OperationResult.NotFound();

            blogcategory.name = editCategoryDtos.name;
            blogcategory.parent_id = editCategoryDtos.parent_id;

            _context.SaveChanges();
            return OperationResult.Success();
        }


    }
}
