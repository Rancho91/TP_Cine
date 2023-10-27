using Microsoft.AspNetCore.Mvc;
using DataCineDb.Entidades.Factura;
using DataCineDb.Service;
using DataCineDb.Entidades;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        serviceFactura service = new serviceFactura();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult PostFactura(Facturas Factura)
        {
            try
            {
                service.crearFactura(Factura);
                return Ok(Factura);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    /*
        //PUT api/<ValuesController>/5
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
