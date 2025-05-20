using TechnoKala.CoreLayer.Dtos;

namespace TechnoKala.CoreLayer.Servises.Blogs_Categories
{
    public interface IBlogs_CategoryService
    {
        OperationResult CreateCategory(CreateCategoryDtos command);
        OperationResult EditCategory(EditCategoryDtos editCategoryDtos);
        //OperationResult DleteCategory(DleteCategoryDtos dleteCategoryDtos);
        List<BlogsCategoryDtos> GetAllCategories();
        BlogsCategoryDtos GetCategoryBy(int id);
        //BcategoryDto GetBlogsCategoryByfilter(int pageid,int take,string name);
        List<BlogsCategoryDtos> GetChildBlogCategory();
    }
}
