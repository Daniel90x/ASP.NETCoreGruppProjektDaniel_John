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
    public class EventDbContext : IdentityDbContext<IdentityUser>
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public void seed()
        {
            this.Database.EnsureCreated();
            if (this.Events.Any())
            {
                return;
            }
            Events.AddRange(new List<Event>()
            {
                new Event(){Title = "Hejsan", Adress = "Här"}
            });

            this.SaveChanges();
        }

        public async Task SeedAsync(UserManager<MyUser> userManager)
        {
            await Database.EnsureCreatedAsync();

            MyUser user = new MyUser()
            {
                UserName = "test_user",
                Email = "test@hotmail.com",
            };
            await userManager.CreateAsync(user, "Passw0rd!");
            await SaveChangesAsync();
        }
    }
}
