using BoatRide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.DAL
{
    public interface IKundeRepository
    {
        Task<List<Kunde>> HentAlle();
        Task<bool> LagreKunde(Kunde kunde);
        Task<Kunde> HentEnKunde(int kid);
        Task<Kunde> HentKundePaaNavn(string fornavn, string etternavn);
    }
}
