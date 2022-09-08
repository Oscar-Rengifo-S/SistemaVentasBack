using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Base
    {
        string cad = "Server=26.105.170.5;database=BDVentas;uid=sa;password=server_280196;Persist Security Info=False;Pooling=True;Max Pool Size=2000;Min Pool Size=0;Connection Lifetime=3;Connection Timeout=5";

        public string CadenaConexion
        {
            get { return cad; }
        }

    }
}
