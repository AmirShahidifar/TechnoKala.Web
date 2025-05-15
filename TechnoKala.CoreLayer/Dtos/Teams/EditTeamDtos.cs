using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoKala.CoreLayer.Dtos.Teams
{
    public class EditTeamDtos
    {
        public int id { get; set; }
        public string title { get; set; }
        public string fullname { get; set; }
        public IFormFile? ImageFile { get; set; } // عکس جدید (اختیاری)
        public string? CurrentImagePath { get; set; } // مسیر عکس فعلی
    }
}
