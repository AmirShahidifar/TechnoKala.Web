using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.CoreLayer.Dtos.Teams;
using TechnoKala.CoreLayer.Mapper;
using TechnoKala.DaytaLayer.Contex;
using X.PagedList;
using X.PagedList.Extensions;

namespace TechnoKala.CoreLayer.Servises.Teams
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContex _contex;

        public TeamService(AppDbContex contex)
        {
            _contex = contex;
        }
        public OperationResult CreateTeamDtos(CreateTeamDtos command)
        {
            var teams = TeamsMapper.Map(command);


            _contex.teams.Add(teams);
            _contex.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditTeamDtos(EditTeamDtos command)
        {
            var teams = _contex.teams.FirstOrDefault(b => b.id == command.id);

            if (teams == null)

               return OperationResult.NotFound();

            teams.title = command.title;
            teams.fullname = command.fullname;
            teams.created_at = DateTime.Now;
            _contex.SaveChanges();
            return OperationResult.Success();
        }

        public IPagedList<GetAllTeamDtos> GetAllTeamDtos(int pageNumber, int pageSize)
        {
            var teamsquery = _contex.teams
               .Select(Teams => new GetAllTeamDtos
               {
                   fullname = Teams.fullname,
                   title = Teams.title,
                   id = Teams.id,
                   image = Teams.image,
               })
               .OrderBy(b => b.id); // مرتب‌سازی بر اساس Id یا هر فیلد دیگر

            return teamsquery.ToPagedList(pageNumber, pageSize);
        }
        public GetAllTeamDtos GetTeamBy(int id)
        {
            var teams = _contex.teams.FirstOrDefault(b => b.id == id);
            return teams == null ? null : new GetAllTeamDtos
            {
                id = teams.id,
               
                title = teams.title,
                image = teams.image,
                fullname = teams.fullname,
                
            };

        }
    }
}
