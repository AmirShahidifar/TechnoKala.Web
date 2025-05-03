using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos
{
  public  class BlogsCategoryDtos : CreateCategoryDtos
    {
        public int id { get; set; }

    }
    public class CreateCategoryDtos
    {
        public string name { get; set; }
        public int? parent_id { get; set; }
        public string parent_name { get; set; }

    }
    public class EditCategoryDtos 
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? parent_id { get; set; }
        public string parent_name { get; set; }
    }
    public class GetChildBlogCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? parent_id { get; set; }
        public string parent_name { get; set; }
    }

    public class DleteCategoryDtos
    {
        public int id { get; set; }
        public bool is_dleated { get; set; }

    }


}
