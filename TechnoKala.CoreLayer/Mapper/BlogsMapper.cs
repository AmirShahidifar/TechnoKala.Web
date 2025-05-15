using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.CoreLayer.Mapper
{
   public class BlogsMapper
    {
        public static Blog Map(CreateBlogsDtos createBlogsDtos) => new Blog()
        {
            title = createBlogsDtos.title,
            category_id = createBlogsDtos.category_id,
            description = createBlogsDtos.description,
            blog_text = createBlogsDtos.blog_text,
            image = createBlogsDtos.image,
            slug = createBlogsDtos.slug,

        };

        public static Blog MapEdit(EditBlogsDtos editBlogsDtos) => new Blog()
        {
            title = editBlogsDtos.title,
            description = editBlogsDtos.description,
      

        };


    }
}
