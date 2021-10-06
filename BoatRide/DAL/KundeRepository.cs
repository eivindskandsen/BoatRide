using BoatRide.Controllers;
using BoatRide.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.DAL
{
    public class KundeRepository : IKundeRepository
    {
        private readonly BoatContext _db;

        public KundeRepository(BoatContext db)
        {
            _db = db;
        }
        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = await _db.Kunder.ToListAsync(); // hent hele tabellen
                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> LagreKunde(Kunde kunde)
        {
                try
                {
                    _db.Kunder.Add(kunde);
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        public async Task<Kunde> HentEnKunde(int kid)
        {
            try
            {
                Kunde enKunde = await _db.Kunder.FindAsync(kid);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }
    }
}
