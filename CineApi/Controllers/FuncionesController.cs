using DataCineDb.Entidades;
using DataCineDb.Entidades.Maestras;
using DataCineDb.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        ServiceFunciones service = new ServiceFunciones();
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Funciones> funciones = service.getFunciones();
                if (funciones == null || funciones.Count == 0)
                {
                    return BadRequest("No se encontraron datos de géneros.");
                }
                return Ok(funciones);
            }
            catch (Exception ex)
            {
                // Registra la excepción para ver más detalles en el registro o en la salida de la consola
                Console.WriteLine($"Excepción: {ex.Message}");
                // También puedes registrar detalles adicionales, como ex.StackTrace, para obtener más información sobre la excepción
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Puedes devolver un mensaje de error genérico o personalizado en la respuesta
                return BadRequest("Se ha producido un error al obtener los géneros.");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Funciones funcion = service.getFuncionesButacas(id);
                if (funcion == null)
                {
                    return BadRequest("No se encontraron datos de géneros.");
                }
                return Ok(funcion);
            }
            catch (Exception ex)
            {
                // Registra la excepción para ver más detalles en el registro o en la salida de la consola
                Console.WriteLine($"Excepción: {ex.Message}");
                // También puedes registrar detalles adicionales, como ex.StackTrace, para obtener más información sobre la excepción
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Puedes devolver un mensaje de error genérico o personalizado en la respuesta
                return BadRequest("Se ha producido un error al obtener los géneros.");
            }
        }

        //POST api/<ValuesController>
           
        [HttpPost]
        public IActionResult Post([FromBody] Salas sala)
        {
            try
            {
                Console.WriteLine(sala);
                service.postFunciones(sala);
                return Ok( sala);
            }
            catch (Exception ex)
            {
                // Registra la excepción para ver más detalles en el registro o en la salida de la consola
                Console.WriteLine($"Excepción: {ex.Message}");
                // También puedes registrar detalles adicionales, como ex.StackTrace, para obtener más información sobre la excepción
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Puedes devolver un mensaje de error genérico o personalizado en la respuesta
                return BadRequest("Se ha producido un error al obtener los géneros.");
            }
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
