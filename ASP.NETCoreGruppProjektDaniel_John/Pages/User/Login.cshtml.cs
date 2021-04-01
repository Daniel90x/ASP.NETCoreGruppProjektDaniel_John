using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<MyUser> _signInManager;
        private readonly UserManager<MyUser> _userManager;

        public LoginModel(SignInManager<MyUser> signInManager,
            UserManager<MyUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }
        [BindProperty]
        public LoginUserForm LoginUser { get; set; }
        public class LoginUserForm
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _signInManager.PasswordSignInAsync(LoginUser.UserName, LoginUser.Password, false, false);

            if (result.Succeeded)
            {

                return RedirectToPage("/index");
            }

            return Page();
        }


    }

  
}
