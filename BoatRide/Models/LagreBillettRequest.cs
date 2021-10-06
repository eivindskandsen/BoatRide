using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.Models
{
    public class LagreBillettRequest
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ\.\ \-]{2,30}$")]
        public string forNavn { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ\.\ \-]{2,40}$")]
        public string etterNavn { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")]
        public string epost { get; set; }


        [RegularExpression(@"^[a-zA-ZæøåÆØÅ\.\ \-]{2,30}$")]
        public string fra { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ\.\ \-]{2,30}$")]
        public string til { get; set; }

        [RegularExpression(@"^[0-9]{1,4}$")]
        public int antall { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$")]
        public int dag { get; set; }

        [RegularExpression(@"^[0-9]{1,2}$")]
        public int måned { get; set; }

        [RegularExpression(@"^[0-9]{1,4}$")]
        public int år  { get; set; }
    }
}
