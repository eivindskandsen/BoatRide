using BoatRide.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.DAL
{
    public interface IBillettRepository
    {
        Task<bool> LagreBillett([FromBody] LagreBillettRequest request);
        Task<List<Billett>> HentAlleBilletter();
        Task<bool> SlettEnBillett(int bid);
        Task<List<Billett>> HentKundesBilletter(int kid);

    }
}
