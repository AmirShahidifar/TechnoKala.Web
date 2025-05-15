using System.ComponentModel.DataAnnotations;

namespace TechnoKala.Areas.Panel.Model.Team
{
    public class EditViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string fullname { get; set; }
        public IFormFile? ImageFile { get; set; } // عکس جدید (اختیاری)
        public string? CurrentImagePath { get; set; } // مسیر عکس فعلی
    }
}
