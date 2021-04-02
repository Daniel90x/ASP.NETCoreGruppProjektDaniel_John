using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreGruppProjektDaniel_John.Models
{
    public class Event
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public string Place { get; set; }
        public DateTime Date { get; set; }

        public int SpotsAvailable { get; set; }

        
        public MyUser Organizer { get; set; }

        
        public List<MyUser> Attendees { get; set; }


    }
}
