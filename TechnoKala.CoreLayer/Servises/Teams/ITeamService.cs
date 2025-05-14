using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos.Teams;
using X.PagedList;

namespace TechnoKala.CoreLayer.Servises.Teams
{
   public interface ITeamService
    {
        OperationResult CreateTeamDtos(CreateTeamDtos command);
        OperationResult EditTeamDtos(EditTeamDtos command);
        IPagedList<GetAllTeamDtos> GetAllTeamDtos(int pageNumber, int pageSize);
        GetAllTeamDtos GetTeamBy(int id);
   
    }
}
