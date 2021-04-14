using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class NuclearModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public NuclearModel(
            EventDbContext context,
            UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task OnPostAsync()
        {
            await _context.SeedAsync(_userManager, _roleManager, true);
        }
    }
}
