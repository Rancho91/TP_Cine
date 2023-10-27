using DataCineDb.Entidades;
using DataCineDb.Entidades.Factura;
using DataCineDb.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormasPagoController : ControllerBase
    {

        ServiceFormasPago service = new ServiceFormasPago();
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FormasPagos> formasPago = service.GetFormasPagos();
                if (formasPago == null || formasPago.Count == 0)
                {
                    return BadRequest("No se encontraron datos de géneros.");
                }
                return Ok(formasPago);
            }
            catch (Exception ex)
            {
                // Registra la excepción para ver más detalles en el registro o en la salida de la consola
                Console.WriteLine($"Excepción: {ex.Message}");
                // También puedes registrar detalles adicionales, como ex.StackTrace, para obtener más información sobre la excepción
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Puedes devolver un mensaje de error genérico o personalizado en la respuesta
                return BadRequest("Se ha producido un error");
            }
        }

        /*
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
        */
    }
}
