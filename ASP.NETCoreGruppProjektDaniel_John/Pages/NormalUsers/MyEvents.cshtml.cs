using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public MyEventsModel(
            EventDbContext context,
            UserManager<MyUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _context.Users
                .Where(u => u.UserName == User.Identity.Name)
                .Include(u => u.MyEvents)
                .FirstOrDefaultAsync();

            Event = user.MyEvents;

            
        }
    }
}
