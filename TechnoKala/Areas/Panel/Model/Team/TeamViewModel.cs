using System.ComponentModel.DataAnnotations;
using TechnoKala.CoreLayer.Dtos.Blogs;
using TechnoKala.CoreLayer.Dtos.Teams;

namespace TechnoKala.Areas.Panel.Model.Team
{
    public class TeamViewModel
    {
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "مسئولیت  را وارد کنید")]
        public string title { get; set; }
        [Required(ErrorMessage = "تصویر  را وارد کنید")]
        [Display(Name = "تصویر")]
        public IFormFile imageFile { get; set; }
        public string image { get; set; }
        

        public CreateTeamDtos MapToDto()
        {
            return new CreateTeamDtos()
            {
                fullname = fullname,
                title = title,
                image = image,
              

            };
        }
    }
}
