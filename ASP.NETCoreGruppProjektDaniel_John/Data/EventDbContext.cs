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

        public DbSet<Event> Events { get; set; }


        public async Task SeedAsync(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager, bool reset)
        {

            if (reset)
            {
                await this.Database.EnsureDeletedAsync();
            }
            bool isCreated = await this.Database.EnsureCreatedAsync();
            if (!isCreated)
            {
                return;
            }
           

            MyUser user = new MyUser()
            {
                UserName = "admin",
                Email = "admin@hotmail.com",
                FirstName = "Admin",
            };

            MyUser user1 = new MyUser()
            {
                UserName = "org",
                Email = "organizer@hotmail.com",
                FirstName = "Organizer",
            };

            MyUser user2 = new MyUser()
            {
                UserName = "Dude",
                Email = "dude@hotmail.com",
                FirstName = "Dude",
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



            Events.AddRange(new List<Event>()
            {
                new Event(){Title = "Hejsan", Adress = "Här", Place = "Ny Place", SpotsAvailable = 66, Organizer = userRole1},
                new Event(){Title = "Hejsan1", Adress = "Här2", Place = "Ny Place3", SpotsAvailable = 17, Organizer = userRole1},
                new Event(){Title = "Henrys hörna", Adress = "Strandgatan 7", Place = "True Heaven", SpotsAvailable = 183, Organizer = userRole1}
            });



            await SaveChangesAsync();
        }
    }
}
