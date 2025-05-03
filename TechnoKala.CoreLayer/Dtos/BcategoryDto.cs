using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos
{
   public class BcategoryDto
    {
        public int pageid { get; set; }
        public int PageCount { get; set; }
        public int take { get; set; }
      

        public string name { get; set; }
    }
}
