using Microsoft.AspNetCore.Mvc;
using veeb_Milovzorova.Models;
using System.Linq;

namespace veeb_Milovzorova.Controllers
{
    [Route("api/tooted")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1, "Koola", 1.5, true),
            new Toode(2, "Fanta", 1.0, false),
            new Toode(3, "Sprite", 1.7, true),
            new Toode(4, "Vichy", 2.0, true),
            new Toode(5, "Vitamin well", 2.5, true)
        };

        // GET /tooted
        [HttpGet]
        public ActionResult<List<Toode>> KoikTooted()
        {
            return Ok(_tooted);
        }

        // POST /tooted/lisa
        [HttpPost("lisa")]
        public ActionResult<List<Toode>> LisaToode([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return Ok(_tooted);
        }

        // DELETE /tooted/kustuta-koik
        [HttpDelete("kustuta-koik")]
        public ActionResult KustutaKoik()
        {
            _tooted.Clear();
            return Ok("Kõik tooted on kustutatud!");
        }

        // PATCH /tooted/hind-dollaritesse/{kurss}
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public ActionResult<List<Toode>> UuendaKoigiToodeteHinnad(double kurss)
        {
            foreach (var toode in _tooted)
            {
                toode.Price *= kurss;
            }
            return Ok(_tooted);
        }

        // PUT /tooted/deaktiveeri-koik
        [HttpPut("deaktiveeri-koik")]
        public ActionResult<List<Toode>> DeaktiveeriKoik()
        {
            foreach (var toode in _tooted)
            {
                toode.IsActive = false;
            }
            return Ok(_tooted);
        }

        // GET /tooted/kalleim-toode
        [HttpGet("kalleim-toode")]
        public ActionResult<Toode> KalleimToode()
        {
            if (!_tooted.Any()) return NotFound("Tooteid ei ole saadaval!");
            var kalleimToode = _tooted.OrderByDescending(t => t.Price).FirstOrDefault();
            return Ok(kalleimToode);
        }
    }
}
