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
    public class ClienteDa:Base
    {
        public int SaveClienteFactura(ClienteFactura entity)
        {
            int bresult = 0;

            try
            {
                using (IDbConnection db = new SqlConnection(base.CadenaConexion))
                {
                    db.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@ruc", entity.ruc);
                    parametros.Add("@razon_social", entity.razon_social);
                    parametros.Add("@direccion", entity.direccion);
                    parametros.Add("@id_cliente_factura", entity.id_cliente_factura);
                    
                    db.Execute("SP_CLIENTE_FACTURA_INS_01", param: parametros, commandType: CommandType.StoredProcedure);
                    db.Close();
                    db.Dispose();
                    bresult = 1;
                }
            }
            catch (Exception ex)
            {
                bresult = -1;
            }
            return bresult;
        }

        public int DeleteClienteFactura(ClienteFactura entity)
        {
            int bresult = 0;

            try
            {
                using (IDbConnection db = new SqlConnection(base.CadenaConexion))
                {
                    db.Open();
                    var parametros = new DynamicParameters();
                    parametros.Add("@id_cliente_factura", entity.id_cliente_factura);

                    db.Execute("SP_CLIENTE_FACTURA_DEL_01", param: parametros, commandType: CommandType.StoredProcedure);
                    db.Close();
                    db.Dispose();
                    bresult = 1;
                }
            }
            catch (Exception ex)
            {
                bresult = -1;
            }
            return bresult;
        }

        public List<ClienteFactura> GetListClientesFactura()
        {
            List<ClienteFactura> ListEntity = new List<ClienteFactura>();

            try
            {
                using (IDbConnection db = new SqlConnection(base.CadenaConexion))
                {
                    db.Open();
                    var parametros = new DynamicParameters();

                    ListEntity = db.Query<ClienteFactura>("SP_CLIENTE_FACTURA_SEL_01", param: parametros, commandType: CommandType.StoredProcedure).ToList();
                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            return ListEntity;
        }

    }
}
