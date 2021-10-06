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

        [HttpPost]
        public async Task<bool> LagreBillett([FromBody]LagreBillettRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kunde = await _db.Kunder.Where(x => x.forNavn == request.forNavn && x.etterNavn == request.etterNavn).FirstOrDefaultAsync();

                    if(kunde == null)
                    {
                        kunde = new Kunde()
                        {
                            forNavn = request.forNavn,
                            etterNavn = request.etterNavn,
                            Billetter = new List<Billett>(),
                            epost = request.epost
                        };
                        _db.Kunder.Add(kunde);
                    }

                    kunde.Billetter.Add(new Billett() { 
                        fra = request.fra,
                        til = request.til,
                        antall = request.antall,
                        dag = request.dag,
                        måned = request.måned,
                        år = request.år
                    });

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
