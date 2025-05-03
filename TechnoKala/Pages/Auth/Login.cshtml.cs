using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TechnoKala.CoreLayer.Servises.Users;

namespace TechnoKala.Pages.Auth
{   
    
    [BindProperties]
    public class LoginModel : PageModel
    {
    
        private IUserService _userService;

        public LoginModel(IUserService userService)
        {

            _userService = userService;

        }
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        public string email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string password { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult>  OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var Result = _userService.LoginUser(new CoreLayer.Dtos.LoginDtos() { password = password, email = email });

            if(Result == null)
            {
                ModelState.AddModelError("email", "مشخصات وارد شده وجود ندارد ");
                return Page();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Result.firstname),
                new Claim(ClaimTypes.Name,Result.lastname)
            };

            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimPrincipal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(ClaimPrincipal);
            return Redirect("/Index");
        }
    }
}
