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

namespace ASP.NETCoreGruppProjektDaniel_John.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext _context;

        public DeleteModel(ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
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
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FindAsync(id);

            var user = await _context.Users
                .Where(u => u.UserName == User.Identity.Name)
                .Include(u => u.MyEvents)
                .FirstOrDefaultAsync();

            if (Event != null)
            {
                Event.SpotsAvailable = Event.SpotsAvailable + 1;
                user.MyEvents.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/NormalUsers/MyEvents");
        }
    }
}
