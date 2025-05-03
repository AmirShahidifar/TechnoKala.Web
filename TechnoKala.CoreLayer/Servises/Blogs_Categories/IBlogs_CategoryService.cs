using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos;
using X.PagedList;

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
        List <BlogsCategoryDtos>GetChildBlogCategory();
    }
}
