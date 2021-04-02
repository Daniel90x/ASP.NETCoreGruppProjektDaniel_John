using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreGruppProjektDaniel_John.Models
{
    public class MyUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("Organizer")]
        public List<Event> HostedEvents { get; set; }

        [InverseProperty("Attendees")]
        public List<Event> MyEvents { get; set; }
    }
}
