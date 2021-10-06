using BoatRide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.Controllers
{

    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly BoatContext _db;

        private ILogger<KundeController> _log;
         
        public KundeController(BoatContext db, ILogger<KundeController> log)
        {
            _db = db;
            _log = log;
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
            if (ModelState.IsValid)
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
            _log.LogInformation("Feil i input valideringen");
            return false;
            
        }

        public async Task<Kunde> HentEn(int id)
        {
            try
            {
                Kunde enKunde = await _db.Kunder.FindAsync(id);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }

    }
}
