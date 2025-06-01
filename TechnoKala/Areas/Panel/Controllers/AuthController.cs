using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechnoKala.CoreLayer.Dtos.Admins;
using TechnoKala.CoreLayer.Servises.Admins;

namespace TechnoKala.Areas.Panel.Controllers
{
    [Area("Panel")]
    [AllowAnonymous]

    public class AuthController : Controller
    {
        private readonly IAdminAuthService _authService;

        public AuthController(IAdminAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginAdminDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var admin = await _authService.LoginAsync(dto);
            if (admin == null)
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبور نادرست است.");
                return View(dto);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.FullName),
                new Claim("Username", admin.Username),
                new Claim("Role", admin.Role.Title ?? "")
            };

            var identity = new ClaimsIdentity(claims, "AdminAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("AdminAuth", principal);

            return RedirectToAction("Index", "Home", new { area = "Panel" });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AdminAuth");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
