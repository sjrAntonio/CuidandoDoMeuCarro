using CuidandoDoMeuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidandoDoMeuCarro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MotoristaController : ControllerBase
    {
        public List<Motorista> Motoristas = new List<Motorista>()
        {
            new Motorista(1, "Antonio", 1234567890, Motorista.enTipoCnh.B, new DateTime(2025, 1, 1, 0, 0, 0)),
            new Motorista(2, "Daniela", 2554787814, Motorista.enTipoCnh.B, new DateTime(2024, 10, 24, 0, 0, 0)),
            new Motorista(3, "Eduardo", 2547787851, Motorista.enTipoCnh.A, new DateTime(2026, 7, 12, 0, 0, 0))
        };

        // GET: api/<MotoristaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Motoristas);
        }

        // GET api/<MotoristaController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var MotoristaSel = Motoristas.FirstOrDefault(m => m.Id == id);

                if (MotoristaSel == null) { throw new Exception("Motorista não encontrado"); }

                return Ok(MotoristaSel);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MotoristaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MotoristaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotoristaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
