using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] ClienteFactura value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("SaveClienteFactura")]
        [HttpPost]
        public ActionResult SaveClienteFactura(ClienteFactura saveEntity)
        {
            var oClienteDa = new ClienteDa();
            oClienteDa.SaveClienteFactura(saveEntity);
            return Ok();
        }

        [Route("DeleteClienteFactura")]
        [HttpPost]
        public ActionResult DeleteClienteFactura(ClienteFactura saveEntity)
        {
            var oClienteDa = new ClienteDa();
            oClienteDa.DeleteClienteFactura(saveEntity);
            return Ok();
        }

        [Route("GetListClientesFactura")]
        [HttpPost]
        public ActionResult GetListClientesFactura()
        {
            var oClienteDa = new ClienteDa();
            var ListEntity = oClienteDa.GetListClientesFactura();
            return Ok(ListEntity);
        }


    }
}
