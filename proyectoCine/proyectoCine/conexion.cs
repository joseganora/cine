using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoCine
{
    class conexion
    {
        string connectionString = "Persist Security Info=False;User ID=sa;Initial Catalog=Northwind;Data Source=MYSERVER";
        SqlConnection connection;
        SqlDataAdapter myDataAdapter;

        public conexion()
        {
            connection = new SqlConnection(connectionString);
            myDataAdapter = new SqlDataAdapter();
        }

        public bool verificarConexion()
        {
            bool band = false;
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open) band = true;
                connection.Close();
                
            }
            catch(SqlException exc)
            {

            }
            return band;

        }
    }
}
