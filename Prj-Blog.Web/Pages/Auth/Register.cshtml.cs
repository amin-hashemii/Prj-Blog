using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prj_Blog.CoreLayer.DTOs;
using Prj_Blog.CoreLayer.Services.Users;
using Prj_Blog.CoreLayer.Utities;
using System.ComponentModel.DataAnnotations;

namespace Prj_Blog.Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;


        #region propertis

        [Display(Name = "??? ??????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string UserName { get; set; }

        [Display(Name = "??? ? ??? ????????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string FullName { get; set; }

        [Display(Name = "???? ????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        [MinLength(6, ErrorMessage = "{0} ???? ????? ?? 5 ??????? ????")]
        public string Password { get; set; }


        #endregion

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var result = _userService.RegisterUsers(new UserRegisterDto()
            {
                UserName = UserName,
                Password = Password,
                FullName = FullName
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
