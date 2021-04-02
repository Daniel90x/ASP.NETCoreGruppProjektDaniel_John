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
        
        

        public JoinEventModel(ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext context)
        {
            _context = context;
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

        /*public async Task<IActionResult> OnPostAsync(int? id)
        {
            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            var testar = await _context.Events.Where(m => m.Adress == User.Identity.Name).FirstOrDefaultAsync();
            string test = User.Identity.Name;
            return Page();
        }*/
    }
}
