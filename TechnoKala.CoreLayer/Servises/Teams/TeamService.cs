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
            var team = _contex.teams.FirstOrDefault(b => b.id == command.id);
            if (team == null)
                return OperationResult.NotFound();

            team.title = command.title;
            team.fullname = command.fullname;
            team.created_at = DateTime.Now;

            // اگر عکس جدید ارسال شده:
            if (command.ImageFile != null && command.ImageFile.Length > 0)
            {
                // پاک کردن عکس قبلی اگر وجود دارد
                if (!string.IsNullOrEmpty(team.image))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", team.image.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                        File.Delete(oldImagePath);
                }

                // ذخیره عکس جدید
                var uploadsFolder = Path.Combine("wwwroot", "images", "teams");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + command.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    command.ImageFile.CopyTo(fileStream);
                }

                team.image = "/images/teams/" + uniqueFileName;
            }

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
