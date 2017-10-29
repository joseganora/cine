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
        string connectionString = "Data Source=PEPE-PC;Initial Catalog=CINE_TPI;Integrated Security=True"; 
        SqlConnection connection;
        SqlCommand comando;

        public conexion()
        {
            connection = new SqlConnection(connectionString); 
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
        public DataTable consulta(string consulta)
        {
            comando = new SqlCommand(consulta,connection);
            connection.Open();
            SqlDataReader myReader = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(myReader);
            myReader.Close();
            connection.Close();
            return dt;
        }
        public void insert_update(string consulta)
        {
            comando = new SqlCommand(consulta, connection);
            connection.Open();
            comando.ExecuteNonQuery();
            connection.Close();
        }

    }
}
