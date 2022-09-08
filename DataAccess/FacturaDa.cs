using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class FacturaDa:Base
    {
        public long SaveFactura(SaveFacturaFlt entity)
        {
            long bresult = 0;

            try
            {
                using (IDbConnection db = new SqlConnection(base.CadenaConexion))
                {
                    db.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@serie", entity.serie);
                    parametros.Add("@num_correlativo", entity.num_correlativo);
                    parametros.Add("@fec_emision", entity.fec_emision);
                    parametros.Add("@ruc", entity.ruc);
                    parametros.Add("@id_cliente_factura", entity.id_cliente_factura);
                    parametros.Add("@razon_social", entity.razon_social);
                    parametros.Add("@fec_vcmto", entity.fec_vcmto);
                    parametros.Add("@id_moneda", entity.id_moneda);
                    parametros.Add("@por_impto_venta", entity.por_impto_venta);
                    parametros.Add("@imp_impto_venta", entity.imp_impto_venta);
                    parametros.Add("@imp_valor_venta", entity.imp_valor_venta);
                    parametros.Add("@imp_total_venta", entity.imp_total_venta);
                    parametros.Add("@imp_paga_venta", entity.imp_paga_venta);
                    parametros.Add("@imp_vuelto_venta", entity.imp_vuelto_venta);
                    parametros.Add("@id_usuario", entity.id_usuario);
                    parametros.Add("@correo_cliente", entity.correo_cliente);
                    parametros.Add("@id_factura", entity.id_factura);

                    db.Execute("SP_CLIENTE_FACTURA_INS_01", param: parametros, commandType: CommandType.StoredProcedure);
                    db.Close();
                    db.Dispose();
                    entity.id_factura = parametros.Get<long>("@id_factura");
                    bresult = 1;
                }
            }
            catch (Exception ex)
            {
                bresult = -1;
            }
            return bresult;
        }

        public long SaveFacturaDet(SaveFacturaDetFlt entity)
        {
            long bresult = 0;

            try
            {
                using (IDbConnection db = new SqlConnection(base.CadenaConexion))
                {
                    db.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@id_factura", entity.id_factura);
                    parametros.Add("@item_factura", entity.item_factura);
                    parametros.Add("@conceptop_vta", entity.conceptop_vta);
                    parametros.Add("@imp_unit_vta_det", entity.imp_unit_vta_det);
                    parametros.Add("@can_unit_vta_det", entity.can_unit_vta_det);
                    parametros.Add("@imp_costo_vta_det", entity.imp_costo_vta_det);
                    parametros.Add("@por_impto_vta_det", entity.por_impto_vta_det);
                    parametros.Add("@imp_impto_vta_det", entity.imp_impto_vta_det);
                    parametros.Add("@imp_precio_vta_det", entity.imp_precio_vta_det);

                    db.Execute("SP_CLIENTE_FACTURA_INS_01", param: parametros, commandType: CommandType.StoredProcedure);
                    db.Close();
                    db.Dispose();
                    bresult = parametros.Get<long>("@id_factura");
                }
            }
            catch (Exception ex)
            {
                bresult = -1;
            }
            return bresult;
        }


    }
}
