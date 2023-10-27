using DataCineDb.Entidades;
using DataCineDb.Entidades.Auxiliares;
using DataCineDb.Service
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomasController : ControllerBase
    {
        ServiceIdioma service = new ServiceIdioma();
        // GET: api/<IdiomasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Idiomas> idiomas = service.GetIdiomas();
                if (idiomas == null || idiomas.Count == 0)
                {
                    return BadRequest("No se encontraron datos de géneros.");
                }
                return Ok(idiomas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return BadRequest("Se ha producido un error");
            }
        }

        // GET api/<IdiomasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IdiomasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IdiomasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IdiomasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
