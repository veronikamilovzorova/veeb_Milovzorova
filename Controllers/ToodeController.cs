using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veeb_Milovzorova.Models;

namespace veeb_Milovzorova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new()
        {
            new Toode(1,"Koola", 1.5, true),
            new Toode(2,"Fanta", 1.0, false),
            new Toode(3,"Sprite", 1.7, true),
            new Toode(4,"Vichy", 2.0, true),
            new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET https://localhost:4444/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }

        // DELETE https://localhost:4444/tooted/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }

        // POST https://localhost:4444/tooted/lisa/1/Coca/1.5/true
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpPost("lisa2")]
        public List<Toode> Add2(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        // PATCH https://localhost:4444/tooted/hind-dollaritesse/1.5
        [HttpPatch("hind-dollaritesse/{kurss}")]
        public List<Toode> UpdatePrices(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }
        [HttpGet("kustuta-koik")]
        public string DeleteAll()
        {
            _tooted.Clear();
            return "Kõik tooted on kustutatud!";
        }

        [HttpGet("deaktiveeri-koik")]
        public List<Toode> DeactivateAll()
        {
            foreach (var t in _tooted)
            {
                t.IsActive = false;
            }
            return _tooted;
        }
        [HttpGet("toode/{index}")]
        public ActionResult<Toode> GetProduct(int index)
        {
            if (index < 0 || index >= _tooted.Count)
            {
                return NotFound("Toodet ei leitud!");
            }
            return _tooted[index];
        }
        [HttpGet("kalleim-toode")]
        public ActionResult<Toode> GetMostExpensiveProduct()
        {
            if (_tooted.Count == 0)
            {
                return NotFound("Tooteid ei ole saadaval!");
            }

            Toode? mostExpensive = _tooted.OrderByDescending(t => t.Price).FirstOrDefault();

            if (mostExpensive == null)
            {
                return NotFound("Kalleimat toodet ei leitud!");
            }

            return Ok(mostExpensive);
        }


    }
}
