using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veeb_Milovzorova.Models;
using System.Collections.Generic;
using System.Linq;

namespace veeb_Milovzorova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private static List<Kasutaja> _kasutajad = new()
        {
            new Kasutaja(1, "ver1", "ver123", "Veronika", "Milovzorova"),
            new Kasutaja(1, "ver2", "ver1234", "Veronika1", "Milovzorova1"),

        };

        // GET /api/kasutaja
        [HttpGet]
        public ActionResult<List<Kasutaja>> Get()
        {
            return Ok(_kasutajad);
        }

        // GET /api/kasutaja/{id}
        [HttpGet("{id}")]
        public ActionResult<Kasutaja> Get(int id)
        {
            var kasutaja = _kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound("Kasutajat ei leitud!");
            }
            return Ok(kasutaja);
        }

        private static int _nextId = 1;
        // POST /api/kasutaja
        [HttpPost]
        public ActionResult<Kasutaja> Create([FromBody] Kasutaja kasutaja)
        {
            kasutaja.Id = _nextId++; // Увеличиваем _nextId для следующего пользователя
            _kasutajad.Add(kasutaja);
            return CreatedAtAction(nameof(Get), new { id = kasutaja.Id }, kasutaja);
        }

        // PUT /api/kasutaja/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Kasutaja kasutaja)
        {
            var existingUser = _kasutajad.FirstOrDefault(k => k.Id == id);
            if (existingUser == null)
            {
                return NotFound("Kasutajat ei leitud!");
            }

            existingUser.KasutajaNimi = kasutaja.KasutajaNimi;
            existingUser.Parool = kasutaja.Parool;
            existingUser.Eesnimi = kasutaja.Eesnimi;
            existingUser.Perenimi = kasutaja.Perenimi;

            return NoContent();
        }

        // DELETE /api/kasutaja/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var kasutaja = _kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound("Kasutajat ei leitud!");
            }
            _kasutajad.Remove(kasutaja);
            return NoContent();
        }
    }
}