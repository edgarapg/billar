using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace billar
{

    class conexion
    {
        SqlConnection cnx;

        public conexion()
        {

            try
            {
               cnx = new SqlConnection("data source=LAPTOP-VHK1MAKD\\CONEXION; Inicial Catalog=gestion_gastos; integrated security=SSPI");
                cnx.Open();

            }catch (Exception ex)
            {

            }
        }
    }
}
