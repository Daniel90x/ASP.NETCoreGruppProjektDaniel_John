using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ASP.NETCoreGruppProjektDaniel_John.Pages;
using Microsoft.Extensions.Logging;

namespace ASP.NETCoreGruppProjektDaniel_John.Data
{
    public class EventDbContext : IdentityDbContext<MyUser>
    {

        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }


        /*private readonly ILogger<EventDbContext> _logger;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public EventDbContext(
            ILogger<EventDbContext> logger,
            UserManager<MyUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }*/


        public DbSet<Event> Events { get; set; }


        /*public void seed()
        {
            this.Database.EnsureCreated();

            Events.AddRange(new List<Event>()
            {
                new Event(){Title = "Hejsan", Adress = "Här", Place = "Ny Place"}
            });

            this.SaveChanges();
        } */

        public async Task SeedAsync(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager, bool reset)
        {
            //await this.Database.EnsureDeletedAsync();
            //await this.Database.EnsureCreatedAsync();
            if (reset)
            {
                await this.Database.EnsureDeletedAsync();
            }
            bool isCreated = await this.Database.EnsureCreatedAsync();
            if (!isCreated)
            {
                return;
            }
            Events.AddRange(new List<Event>()
            {
                new Event(){Title = "Hejsan", Adress = "Här", Place = "Ny Place", SpotsAvailable = 66},
                new Event(){Title = "Hejsan1", Adress = "Här2", Place = "Ny Place3", SpotsAvailable = 17},
                new Event(){Title = "Henrys hörna", Adress = "Strandgatan 7", Place = "True Heaven", SpotsAvailable = 183}
            });

            MyUser user = new MyUser()
            {
                UserName = "admin",
                Email = "admin@hotmail.com",
            };

            MyUser user1 = new MyUser()
            {
                UserName = "org",
                Email = "organizer@hotmail.com",
                
            };

            MyUser user2 = new MyUser()
            {
                UserName = "Dude",
                Email = "dude@hotmail.com",
                
            };


            
            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("organizer"));
            await roleManager.CreateAsync(new IdentityRole("user"));


            await userManager.CreateAsync(user, "Admin_1");
            await userManager.CreateAsync(user1, "Organ_1");
            await userManager.CreateAsync(user2, "Dudeman_1");

            var userRole = await Users.Where(u => u.UserName == "admin").FirstOrDefaultAsync();
            var userRole1 = await Users.Where(u => u.UserName == "org").FirstOrDefaultAsync();

            await userManager.AddToRoleAsync(userRole, "admin");
            await userManager.AddToRoleAsync(userRole1, "organizer");


            await SaveChangesAsync();
        }
    }
}
