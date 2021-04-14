using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;

        public RegisterModel(UserManager<MyUser> userManager)
        {
            _userManager = userManager;


        }
        [BindProperty]
        public NewUserForm NewUser { get; set; }
        public class NewUserForm
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string FirstName { get;  set; }
            public string LastName { get;  set; }
        }



        public async Task<IActionResult> Onpost()
        {
                MyUser newUser = new MyUser()
                {
                    UserName = NewUser.UserName,
                    FirstName = NewUser.FirstName,
                    LastName = NewUser.LastName
                };

                

                try 
                {
                var result = await _userManager.CreateAsync(newUser, NewUser.Password);
                await _userManager.AddToRoleAsync(newUser, "user");

                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else 
                    {

                        return Page();
                    }

                }
                catch
                {

                    return Page();


                }

                
        }
    }
}
