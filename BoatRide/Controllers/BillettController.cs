using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoatRide.Models;

namespace BoatRide.Controllers
{
    [Route("[controller]/[action]")]
    public class BillettController : ControllerBase
    {
        private readonly BoatContext _db;

        public BillettController(BoatContext db)
        {
            _db = db;
        }

        public bool LagreBillett(Billett billett)
        {
            try
            {
                _db.Billetter.Add(billett);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Billett> HentAlleBilletter()
        {
            try
            {
                var Billettene = _db.Billetter.ToList();
                return Billettene;
            }
            catch
            {
                return null;
            }
        }

        public bool SlettEnBillett(int bid)
        {
            try
            {
                var billett = _db.Billetter.Find(bid);
                _db.Billetter.Remove(billett);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
