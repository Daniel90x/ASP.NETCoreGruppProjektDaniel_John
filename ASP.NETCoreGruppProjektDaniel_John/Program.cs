using ASP.NETCoreGruppProjektDaniel_John.Data;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreGruppProjektDaniel_John
{
    public class Program
    {

       /* private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EventDbContext _context;


        public Program(
            EventDbContext context,
            UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }*/

        public static async Task Main(string[] args)
        {

        var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<EventDbContext>();
                var userManager = services.GetRequiredService<UserManager<MyUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await context.SeedAsync(userManager, roleManager, false); // kanske
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
