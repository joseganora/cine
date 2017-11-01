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
        SqlDataReader dr;
        public SqlDataReader pDr
        {
            get { return dr; }
            set { dr = value; }
        }  
        public conexion()
        {
            connection = new SqlConnection(connectionString); 
        }
        public conexion(string stringConn)
        {
            connectionString = stringConn;
            connection = new SqlConnection(connectionString);
        }
        public bool verificarConexion()
        {
            bool band = false;
            try
            {
                connection.Open();
                band = connection.State == ConnectionState.Open;
                connection.Close();
                
            }
            catch(SqlException exc)
            {

            }
            return band;

        }
        public DataTable consultaDT(string consulta)
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
        public void consultaDR(string consulta)
        {
            comando = new SqlCommand(consulta, connection);
            if(connection.State != ConnectionState.Open) connection.Open();
            dr = comando.ExecuteReader();

        }
        public void desconectar()
        {
            
                connection.Close();
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
