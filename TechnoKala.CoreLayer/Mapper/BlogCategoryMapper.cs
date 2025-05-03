using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.CoreLayer.Mapper
{
   public class BlogCategoryMapper
    {
        public static BlogsCategoryDtos Map(Blog_Category blog_Category)
        {
            return new BlogsCategoryDtos()
            {
                name = blog_Category.name,
                parent_id = blog_Category.parent_id,
            };
        }
    }
}
