using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ASP.NETCoreGruppProjektDaniel_John.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace ASP.NETCoreGruppProjektDaniel_John.Data
{
    public class EventDbContext : IdentityDbContext<MyUser>
    {

        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }


        public DbSet<Event> Events { get; set; }


        public void seed()
        {
            this.Database.EnsureCreated();

            Events.AddRange(new List<Event>()
            {
                new Event(){Title = "Hejsan", Adress = "Här", Place = "Ny Place"}
            });

            this.SaveChanges();
        }

        public async Task SeedAsync(UserManager<MyUser> userManager)
        {
            await this.Database.EnsureDeletedAsync();
            await this.Database.EnsureCreatedAsync();

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
                RoleIsOrganizer = true
            };

            MyUser user2 = new MyUser()
            {
                UserName = "Dude",
                Email = "dude@hotmail.com",
                
            };


            await userManager.CreateAsync(user, "Admin_1");
            await userManager.CreateAsync(user1, "Organ_1");
            await userManager.CreateAsync(user2, "Dudeman_1");
            await SaveChangesAsync();
        }
    }
}
