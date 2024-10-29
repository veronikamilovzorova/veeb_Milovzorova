using Microsoft.AspNetCore.Mvc;
using veeb_Milovzorova.Models;

namespace veeb_Milovzorova.Controllers
{
    [Route("api/toode")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1, "Koola", 1.5, true),
            new Toode(2, "Fanta", 1.0, false),
            new Toode(3, "Sprite", 1.7, true),
            new Toode(4, "Vichy", 2.0, true),
            new Toode(5, "Vitamin well", 2.5, true)
        };

        // DELETE /toode/kustuta/{index}
        [HttpDelete("kustuta/{index}")]
        public ActionResult<List<Toode>> Kustuta(int index)
        {
            if (index < 1 || index > _tooted.Count) return NotFound("Toodet ei leitud!");
            _tooted.RemoveAt(index - 1);
            return Ok(_tooted);
        }

        // PUT /toode/lylitus-tegevus/{index}
        [HttpPut("lylitus-tegevus/{index}")]
        public ActionResult<List<Toode>> MuudaAktiivsust(int index)
        {
            if (index < 1 || index > _tooted.Count) return NotFound("Toodet ei leitud!");
            _tooted[index - 1].IsActive = !_tooted[index - 1].IsActive;
            return Ok(_tooted);
        }

        // PUT /toode/muuta-nimi/{index}/{uusNimi}
        [HttpPut("muuta-nimi/{index}/{uusNimi}")]
        public ActionResult<List<Toode>> MuudaNime(int index, string uusNimi)
        {
            if (index < 1 || index > _tooted.Count) return NotFound("Toodet ei leitud!");
            _tooted[index - 1].Name = uusNimi;
            return Ok(_tooted);
        }

        // PUT /toode/update-price/{index}/{kordaja}
        [HttpPut("uuendus-hind/{index}/{kordaja}")]
        public ActionResult<List<Toode>> UuendaHinda(int index, double kordaja)
        {
            if (index < 1 || index > _tooted.Count) return NotFound("Toodet ei leitud!");
            _tooted[index - 1].Price *= kordaja;
            return Ok(_tooted);
        }

        // GET /toode/{index}
        [HttpGet("{index}")]
        public ActionResult<Toode> SaadaToode(int index)
        {
            if (index < 1 || index > _tooted.Count) return NotFound("Toodet ei leitud!");
            return Ok(_tooted[index - 1]);
        }
    }
}
