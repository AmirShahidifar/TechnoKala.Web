using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos.Teams
{
   public class CreateTeamDtos
    {


        public string fullname { get; set; }


        public string image { get; set; }
  
        public string title { get; set; }
    }
}
