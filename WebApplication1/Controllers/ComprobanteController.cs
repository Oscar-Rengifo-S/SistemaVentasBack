using DataAccess;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController : ControllerBase
    {

        [Route("SaveFactura")]
        [HttpPost]
        public ActionResult SaveFactura(SaveFacturaFlt saveEntity)
        {
            var oFacturaDa = new FacturaDa();
            oFacturaDa.SaveFactura(saveEntity);
            foreach(var row in saveEntity.ListSaveFacturaDetFlt)
            {
                row.id_factura = saveEntity.id_factura;
                oFacturaDa.SaveFacturaDet(row);
            }
            return Ok();
        }



    }
}
