using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using TechnoKala.CoreLayer;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.CoreLayer.Servises.Users;

namespace TechnoKala.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string password { get; set; }
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string confirmpasword { get; set; }
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string email { get; set; }


        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() {
            var UserRegister = _userService.RegisterUser(new UserRegisterDtos()
            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                password = password,
                confirmpasword = confirmpasword


            });
            if(UserRegister.Status == OperationResultStatus.Error)
            {
                
                if (UserRegister.Message.Contains("نام کاربری")) 
    {
                    ModelState.AddModelError("email", UserRegister.Message);
                }

                else if (UserRegister.Message.Contains("رمز عبور")) 
    {
                    ModelState.AddModelError("password", UserRegister.Message);
                }
                return Page();
            }

            return RedirectToPage("Login");
        }


    }
}
