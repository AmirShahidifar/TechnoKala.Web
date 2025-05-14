using System.ComponentModel.DataAnnotations;

namespace TechnoKala.Areas.Panel.Model.Team
{
    public class EditViewModel
    {

        public int id { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "مسئولیت را وارد کنید")]
        public string title { get; set; }


    
    }
}
