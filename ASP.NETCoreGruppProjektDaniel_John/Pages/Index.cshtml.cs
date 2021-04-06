using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages // userManager fungerar ej som det ska...
{
    public class IndexModel : PageModel
    {
       
        private readonly ILogger<IndexModel> _logger;
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(
            ILogger<IndexModel> logger,
            EventDbContext context,
            UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync(bool? resetDb)
        {
            if (resetDb ?? false)
            {
                await _context.SeedAsync(_userManager);
            }
        }


        public async Task OnPostAsync()
        {
            var user = await _context.Users.Where(u => u.UserName == "admin").FirstOrDefaultAsync();
            var user1 = await _context.Users.Where(u => u.UserName == "org").FirstOrDefaultAsync();
            await _roleManager.CreateAsync(new IdentityRole("admin"));
            await _roleManager.CreateAsync(new IdentityRole("organizer"));
            await _roleManager.CreateAsync(new IdentityRole("user"));

            await _userManager.AddToRoleAsync(user, "admin");
            await _userManager.AddToRoleAsync(user1, "organizer");
        }
    }
}
