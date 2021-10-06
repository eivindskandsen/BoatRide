using BoatRide.DAL;
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
        private readonly IKundeRepository _db;
        private ILogger<KundeController> _log;
        public KundeController(IKundeRepository db, ILogger<KundeController> log)
        {
            _db = db;
            _log = log;
        }
        public async Task<ActionResult<Kunde>> HentAlle()
        {
            List<Kunde> allekunder = await _db.HentAlle();
            return Ok(allekunder);
        }
        public async Task<ActionResult> LagreKunde(Kunde kunde)
        {
            if (ModelState.IsValid) {
                bool returOK = await _db.LagreKunde(kunde);
                if (!returOK)
                {
                    _log.LogInformation("Kunde ble ikke lagret!");
                    return BadRequest("Kunde ble ikke lagret");
                }
                return Ok("Kunde lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering");
        }
        public async Task<ActionResult> HentEnKunde(int kid)
        {
            Kunde enKunde = await _db.HentEnKunde(kid);
            if (enKunde == null)
            {
                _log.LogInformation("Fant ingen kunde!");
                return BadRequest("Fant ingen kunde");
            }
            
            return Ok("Kunden funnet");
        }
    }
}
