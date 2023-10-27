using DataCineDb.Entidades.Auxiliares;
using DataCineDb.Entidades.Maestras;
using DataCineDb.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        ServicePeliculas service = new ServicePeliculas();
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Peliculas> peliculas = service.GetPeliculas();
                if (peliculas == null || peliculas.Count == 0)
                {
                    return BadRequest("No se encontraron datos de géneros.");
                }
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return BadRequest("Se ha producido un error");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
