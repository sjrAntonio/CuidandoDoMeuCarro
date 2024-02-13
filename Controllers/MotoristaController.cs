using CuidandoDoMeuCarro.BusinessRules;
using Microsoft.AspNetCore.Mvc;

namespace CuidandoDoMeuCarro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MotoristaController : ControllerBase
    {

        private readonly MotoristaRules rules;

        public MotoristaController(MotoristaRules Rules)
        {
            rules = Rules;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ret = rules.BuscaTodosMotoristas(null, null);
            return Ok(ret.Result);
        }

        [HttpGet("{pageNumber:int}/pageSize/{pageSize:int}")]
        public IActionResult GetAllPagination(int pageNumber, int pageSize)
        {
            var ret = rules.BuscaTodosMotoristas(pageNumber, pageSize);
            return Ok(ret.Result);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
