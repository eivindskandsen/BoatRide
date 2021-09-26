using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.Models
{
    public class Kunde
    {

        public int Id { get; set; }
        public string forNavn { get; set; }
        public string etterNavn { get; set; }

        public string email { get; set; }
        
    }

    public class Bilett
    {
        public int Id { get; set; }

        public int kundeId { get; set; }

        public string fra { get; set; }

        public string til { get; set; }

        public int antall { get; set; }

        public int dag { get; set; }
        
        public int måned { get; set; }

        public int år { get; set; }

        //pris
    }
}
