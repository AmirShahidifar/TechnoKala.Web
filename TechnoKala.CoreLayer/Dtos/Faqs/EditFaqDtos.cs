using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos.Faqs
{
   public class EditFaqDtos
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }
    }
}
