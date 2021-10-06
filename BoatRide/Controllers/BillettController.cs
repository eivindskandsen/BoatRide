using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoatRide.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace BoatRide.Controllers
{
    [Route("[controller]/[action]")]
    public class BillettController : ControllerBase
    {
        private readonly BoatContext _db;

        private ILogger<KundeController> _log;


        public BillettController(BoatContext db, ILogger<KundeController> log)
        {
            _db = db;
            _log = log;

        }

        public async Task<bool> LagreBillett([FromBody]Billett billett, [FromBody]Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kunde = await _db.Kunder.Where(x => x.KId == innKunde.KId).FirstOrDefaultAsync();

                    if(kunde == null)
                    {
                        kunde = new Kunde()
                        {
                            forNavn = innKunde.forNavn,
                            etterNavn = innKunde.etterNavn,
                            Billetter = new List<Billett>(),
                            epost = innKunde.epost
                        };
                        _db.Kunder.Add(kunde);
                    }

                    kunde.Billetter.Add(billett);

                    //_db.Billetter.Add(billett);
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

        public async Task<List<Billett>> HentAlleBilletter()
        {
            try
            {
                var Billettene = await _db.Billetter.ToListAsync();
                return Billettene;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> SlettEnBillett(int bid)
        {
            try
            {
                var billett = await _db.Billetter.FindAsync(bid);
                _db.Billetter.Remove(billett);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Billett>> HentKundesBilletter(int kid)
        {
            try
            {
                var kunde = await _db.Kunder.FindAsync(kid);
                return kunde.Billetter;
            }
            catch 
            {
                return null;
            }
        }

    }

}
