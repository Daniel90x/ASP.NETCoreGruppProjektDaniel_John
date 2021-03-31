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
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NETCoreGruppProjektDaniel_John.Pages // userManager fungerar ej som det ska...
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public IndexModel(
              ILogger<IndexModel> logger,
              EventDbContext context,
              UserManager<MyUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task OnGetAsync(bool? resetDb)
        {
            if (resetDb ?? false)
            {
                await _context.SeedAsync(_userManager);
            }
        }
    }
}
