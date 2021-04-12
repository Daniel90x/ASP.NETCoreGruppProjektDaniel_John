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

namespace ASP.NETCoreGruppProjektDaniel_John.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;
        
        

        public JoinEventModel(
            EventDbContext context,
            UserManager<MyUser> userManager
            )
        {
            _context = context;
            _userManager = userManager;

        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return Page();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            var user = await _context.Users.Where(u => u.UserName == User.Identity.Name).Include(u => u.MyEvents).FirstOrDefaultAsync();
            
                if (user == null)
                {
                    return RedirectToPage("/User/Login");
                }

                if (!user.MyEvents.Contains(Event))
                {
                    Event.SpotsAvailable = Event.SpotsAvailable - 1;
                    user.MyEvents.Add(Event);
                    await _context.SaveChangesAsync();
                }
            return Page();
        }
    }
}


// var attendee = await _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefaultAsync();


/*var Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            var attendee = await _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefaultAsync();

            if(!attendee.MyEvents.Contains(Event))
            {
                attendee.MyEvents.Add(Event);
                await _context.SaveChangesAsync();




            }*/