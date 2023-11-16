using Microsoft.AspNetCore.Mvc;
using DataCineDb.Entidades.Auxiliares;
using DataCineDb.Entidades.Maestras;
using DataCineDb.Service;
using DataCineDb.Entidades.Reportes;
using DataCineDb.Entidades;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReporteController : ControllerBase
    {

        // GET: api/<ReporteController>
        ServiceReportes service = new ServiceReportes();
        
        [HttpGet("peliculas/{sala}/{genero}/{orden}")]
        public IActionResult Get(int? sala,string? genero, int? orden)
        {
 // se necsita el Genero de la clase Genero y el numero de la clase Sala,
 // pueden no enviarse, los acepta como nulos (trae sin filtros)
 // si o si hay que enviar el orden
            try
            {

                List<ReportePeliculasGanancia> list = service.GetReportePeliculasGanancias(sala, genero, orden);
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

        [HttpGet("butacas/{funcion}/{estado}")]

        public IActionResult Get(int funcion, string? estado)
        {
            try
            {
                List<ReporteButacasDisponibles> list = service.getReporteButacasDisponibles(funcion, estado);
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

        [HttpGet("funciones/{fechaInicio}/{fechaFinal}/{hora}")]

        public IActionResult Get(DateTime? fechaInicio, DateTime? fechaFinal,TimeSpan hora )
        {
            try
            {
                List<ReportePeliculasXFecha> list = service.reportePeliculasFechaHora(fechaInicio, fechaFinal,hora);
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


        [HttpGet("peliculasGeneroClasi/{genero}/{duracion}/{clasificacion}")]

        public IActionResult Get(string? genero, TimeSpan duracion, string clasificacion)
        {
            try
            {
                List<ReportePeliculasGanancia> list = service.ReporteTodasLasPeliculas(genero, clasificacion, duracion);
                if (list == null || list.Count == 0)
                {
                    return BadRequest("No se encontraron datos del reporte.");
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

        [HttpGet("facturaFormaPago/{fechaInicio}/{fechaFinal}/{descuento}")]

        public IActionResult Get(DateTime? fechaInicio, DateTime? fechaFinal, int? descuento)
        {
            try
            {
                List<ReporteFacturasFormaPago> list = service.ReporteFacturaFormaPago(fechaInicio, fechaFinal, descuento);
                if (list == null || list.Count == 0)
                {
                    return BadRequest("No se encontraron datos del reporte.");
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

        //// GET api/<ReporteController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ReporteController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        //// PUT api/<ReporteController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ReporteController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
