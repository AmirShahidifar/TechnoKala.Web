using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.CoreLayer.Dtos.Teams;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.CoreLayer.Mapper
{
   public class TeamsMapper
    {

        public static Team Map(CreateTeamDtos createTeamDtos) => new Team()
        {
            title = createTeamDtos.title,
           fullname = createTeamDtos.fullname,
            image = createTeamDtos.image,


        };
    }
}
