﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreGruppProjektDaniel_John.Models
{
    public class MyUser : IdentityUser
    {
        public List<Event> MyEvents { get; set; }
    }
}