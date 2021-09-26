using BoatRide.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.Controllers
{

    [Route("[controller]/[action]")]
    public class KundeController : ControllerBase
    {
        private readonly KundeDB _db;

        public KundeController(KundeDB db)
        {
            _db = db;
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

        public bool lagreKunde(Kunde innKunde)
        {

            try
            {
                _db.Kunder.Add(innKunde);
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
