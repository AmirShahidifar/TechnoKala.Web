using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos.Teams
{
   public class GetAllTeamDtos
    {
        public string fullname { get; set; }

        public int id { get; set; }
        public string image { get; set; }

        public string title { get; set; }
    }
}
