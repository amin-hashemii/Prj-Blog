using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prj_Blog.CoreLayer.DTOs.Users;
using Prj_Blog.CoreLayer.Services.Users;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Prj_Blog.Web.Pages.Auth
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [Required(ErrorMessage =" ??? ?????? ?? ???? ????")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "???? ???? ?? ???? ????")]
        [MinLength(6,ErrorMessage ="???? ???? ???? ????? ?? 5 ?????? ????")]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var user = _userService.LoginUser(new LoginUserDto()
            {
                UserName = UserName,
                Password = Password

            });
            if (user==null)
            {
                ModelState.AddModelError("UserName", "?????? ?? ??? ?????? ???? ???");
                return Page();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test","Test"),
                new Claim(ClaimTypes.NameIdentifier,user.User_Id.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            //var properties = new AuthenticationProperties()
            //{
            //    IsPersistent = true
            //};
            HttpContext.SignInAsync(claimPrincipal/*,properties*/);
            return RedirectToPage("../Index");
        }

    }
}
