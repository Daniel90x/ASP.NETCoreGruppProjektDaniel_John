using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages
{
    public class ManageUsersModel : PageModel
    {
        private readonly ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext _context;

        public ManageUsersModel(ASP.NETCoreGruppProjektDaniel_John.Data.EventDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; }

        public IList<MyUser> MyUser { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
            MyUser = await _context.Users.ToListAsync();
        }
    }
}
