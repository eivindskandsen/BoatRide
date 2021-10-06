using BoatRide.Controllers;
using BoatRide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRide.DAL
{
    public class BillettRepository : IBillettRepository
    {
        private readonly BoatContext _db;

        public BillettRepository(BoatContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<bool> LagreBillett([FromBody] LagreBillettRequest request)
        {
            try
            {
                var kunde = await _db.Kunder.Where(x => x.forNavn == request.forNavn && x.etterNavn == request.etterNavn).FirstOrDefaultAsync();

                if (kunde == null)
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

                kunde.Billetter.Add(new Billett()
                {
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
