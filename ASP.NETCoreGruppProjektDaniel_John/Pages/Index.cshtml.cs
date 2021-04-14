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

namespace ASP.NETCoreGruppProjektDaniel_John.Pages
{
    public class IndexModel : PageModel
    {
        public Event Event { get; set; }
        public MyUser MyUser { get;  set; }

        private readonly UserManager<MyUser> _userManager;
        private readonly EventDbContext _context;
        public IndexModel(
            EventDbContext context,
            UserManager<MyUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;

        }



        public async Task OnGetAsync()
        {
            var user = await _context.Users.
                Where(u => u.UserName == User.Identity.Name)
                .FirstOrDefaultAsync();
            MyUser = user;
        }
    }
}
