using BoatRide.Models;
using Microsoft.AspNetCore.Mvc;
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
        public List<Kunde> HentAlle()
        {
            try
            {
                List<Kunde> alleKundene = _db.Kunder.ToList(); // hent hele tabellen
                return alleKundene;
            }
            catch
            {
                return null;
            }
        }

        public bool LagreKunde(Kunde kunde)
        {
            try
            {
                _db.Kunder.Add(kunde);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Kunde HentEn(int id)
        {
            try
            {
                Kunde enKunde = _db.Kunder.Find(id);
                return enKunde;
            }
            catch
            {
                return null;
            }
        }
    }
}
