using Microsoft.AspNetCore.Mvc;
using DataCineDb.Entidades.Auxiliares;
using DataCineDb.Entidades.Maestras;
using DataCineDb.Service;
using DataCineDb.Entidades.Reportes;
using DataCineDb.Entidades;
using CineApi.interfaceReportes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReporteController : ControllerBase
    {

        // GET: api/<ReporteController>
        ServiceReportes service = new ServiceReportes();

        [HttpPut("peliculas")]
        public IActionResult Put(ReportePelicula consulta)
        {
 // se necsita el Genero de la clase Genero y el numero de la clase Sala,
 // pueden no enviarse, los acepta como nulos (trae sin filtros)
 // si o si hay que enviar el orden
            try
            {
                List<ReportePeliculasGanancia> list = service.GetReportePeliculasGanancias(consulta.Sala, consulta.Genero, consulta.orden);
                if (list == null || list.Count == 0)
                {
                    return BadRequest("No se encontraron datos de géneros.");
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return BadRequest("Se ha producido un error");
            }

        }

        // GET api/<ReporteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReporteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReporteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReporteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
