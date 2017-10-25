using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoCine
{
    class conexion
    {
        string connectionString = "Data Source=PEPE-PC;Initial Catalog=cine;Integrated Security=True";
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
        public SqlDataReader consulta(string consulta)
        {
            
            comando = new SqlCommand(consulta,connection);
            connection.Open();
            SqlDataReader myReader = comando.ExecuteReader();
            connection.Close();
            return myReader;
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
