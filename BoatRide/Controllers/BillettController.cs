using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoatRide.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BoatRide.DAL;

namespace BoatRide.Controllers
{
    [Route("[controller]/[action]")]
    public class BillettController : ControllerBase
    {
        private readonly IBillettRepository _db;

        private ILogger<BillettController> _log;

        public BillettController(IBillettRepository db, ILogger<BillettController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> LagreBillett([FromBody] LagreBillettRequest request)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _db.LagreBillett(request);
                if (!returOK)
                {
                    _log.LogInformation("Billett ble ikke lagret!");
                    return BadRequest("Billett ble ikke lagret");
                }
                return Ok("Billett lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering");
        }
        public async Task<ActionResult<Billett>> HentAlleBilletter()
        {
            List<Billett> alleBilletter = await _db.HentAlleBilletter();
            return Ok(alleBilletter);
            
        }
        public async Task<ActionResult> SlettEnBillett(int bid)
        {
            bool returOK = await _db.SlettEnBillett(bid);
            if (!returOK)
            {
                _log.LogInformation("Billett ble ikke slettet!");
                return BadRequest("Billett ble ikke slettet");
            }
            return Ok("Billett slettet");
        }
        public async Task<ActionResult<Billett>> HentKundesBilletter(int kid)
        {
            List<Billett> kundesBilletter = await _db.HentKundesBilletter(kid);
            return Ok(kundesBilletter);
        }  
    }

}
