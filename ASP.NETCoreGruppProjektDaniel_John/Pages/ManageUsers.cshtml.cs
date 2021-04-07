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
    public class ManageUsersModel : PageModel
    {
        private readonly ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public ManageUsersModel(ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IList<Event> Event { get; set; }

        public IList<MyUser> MyUser { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
            MyUser = await _context.Users.ToListAsync();
        }

        public void Test()
        {
            Console.WriteLine("hej");
        }
        public async Task<IActionResult>OnPostAddAsync(string UserName)
        {
            var User = await _context.Users.Where(u => u.UserName == UserName).FirstOrDefaultAsync();
            await _userManager.AddToRoleAsync(User, "organizer");  // UserName är null...
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
