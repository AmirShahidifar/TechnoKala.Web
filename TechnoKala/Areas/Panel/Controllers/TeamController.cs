using Microsoft.AspNetCore.Mvc;
using TechnoKala.Areas.Panel.Model.Team;
using TechnoKala.CoreLayer.Dtos.Teams;
using TechnoKala.CoreLayer.Servises.Blogs;
using TechnoKala.CoreLayer.Servises.Teams;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;


        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 2; // تعداد آیتم‌ها در هر صفحه
            int pageNumber = (page ?? 1); // شماره صفحه، اگر null باشد، صفحه اول

            var result = _teamService.GetAllTeamDtos(pageNumber, pageSize);
           

  
            return View(result);
        }

        public IActionResult Add()
        {
          
           
            return View();

        }

        [HttpPost]
        public IActionResult Add(TeamViewModel teamViewModel)
        {

            if (teamViewModel.imageFile != null && teamViewModel.imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine("wwwroot", "uploads", "teams");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(teamViewModel.imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    teamViewModel.imageFile.CopyTo(fileStream);
                }

                teamViewModel.image = "/uploads/teams/" + uniqueFileName;
            }

            var resault = _teamService.CreateTeamDtos(teamViewModel.MapToDto());
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var teams = _teamService.GetTeamBy(id);

            var model = new EditViewModel()
            {
                fullname = teams.fullname,
                id = teams.id,
                title = teams.title,
               
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(int id, EditViewModel editmodel)
        {
            if (editmodel == null)
            {
                ModelState.AddModelError("", "مدل ارسال شده نال است.");
                return View();
            }
            var resault = _teamService.EditTeamDtos(new CoreLayer.Dtos.Teams.EditTeamDtos()
            {
                title = editmodel.title,
        id=editmodel.id,
                fullname = editmodel.fullname,
            });

            if (resault.Status != CoreLayer.OperationResultStatus.Success)
            {

                ModelState.AddModelError(nameof(editmodel.title), resault.Message);
                return View(editmodel);
            }

            return RedirectToAction("Index");
        }
    }
}
