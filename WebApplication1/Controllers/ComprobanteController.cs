using DataAccess;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            int resp = oFacturaDa.SaveFactura(saveEntity);
            if (resp > 0)
            {
                int item = 1;
                foreach (var row in saveEntity.ListSaveFacturaDetFlt)
                {
                    row.id_factura = saveEntity.id_factura;
                    row.item_factura = item;
                    oFacturaDa.SaveFacturaDet(row);
                    item++;
                }
                return Ok(StatusCodes.Status200OK);
            }
            return Ok(StatusCodes.Status500InternalServerError);
        }

        [Route("GetListFacturas")]
        [HttpGet]
        public ActionResult GetListFacturas()
        {
            var oFacturaDa = new FacturaDa();
            var resp = oFacturaDa.GetListFacturas();
            
            return Ok(resp);
        }


    }
}
