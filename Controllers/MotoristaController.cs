using CuidandoDoMeuCarro.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidandoDoMeuCarro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MotoristaController : ControllerBase
    {


        // GET: api/<MotoristaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<MotoristaController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {

            return Ok();

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
