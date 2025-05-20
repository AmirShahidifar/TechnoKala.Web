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
