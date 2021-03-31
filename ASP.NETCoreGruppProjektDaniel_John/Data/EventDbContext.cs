using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ASP.NETCoreGruppProjektDaniel_John.Models;

namespace ASP.NETCoreGruppProjektDaniel_John.Data
{
    public class EventDbContext : IdentityDbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public async
    }
}
