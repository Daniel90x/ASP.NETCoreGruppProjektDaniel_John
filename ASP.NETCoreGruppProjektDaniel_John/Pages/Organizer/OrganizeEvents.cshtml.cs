using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ASP.NETCoreGruppProjektDaniel_John.Pages
{
    [Authorize(Roles = "organizer, admin")]
    public class OrganizeEventsModel : PageModel
    {
        private readonly ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext _context;

        public OrganizeEventsModel(ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _context.Users
                .Where(u => u.UserName == User.Identity.Name)
                .Include(u => u.HostedEvents)
                .FirstOrDefaultAsync();

            Event = user.HostedEvents;

        }
    }
}
