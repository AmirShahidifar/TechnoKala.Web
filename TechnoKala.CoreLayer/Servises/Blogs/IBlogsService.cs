using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.CoreLayer.Dtos.Blogs;
using X.PagedList;

namespace TechnoKala.CoreLayer.Servises.Blogs
{
   public interface IBlogsService
    {
        OperationResult CreateBlogsDtos(CreateBlogsDtos command);
        OperationResult EditBlogsDtos(EditBlogsDtos command);
        IPagedList<GetAllBlogDtos> GetAllBlogDtos(int pageNumber, int pageSize);
        GetAllBlogDtos GetBlogsBy(int id);
        List<BlogsCategoryDtos> GetBlogsCategories();

    }
}
