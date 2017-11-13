using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace proyectoCine
{
    class conexion
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\PEPE\cine\cine-tp.accdb"; 
        OleDbConnection connection;
        OleDbCommand comando;
        OleDbDataReader dr;
        public OleDbDataReader pDr
        {
            get { return dr; }
            set { dr = value; }
        }  
        public conexion()
        {
            connection = new OleDbConnection(connectionString); 
        }
        public conexion(string stringConn)
        {
            connectionString = stringConn;
            connection = new OleDbConnection(connectionString);
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
            catch(Exception exc)
            {

            }
            return band;

        }
        public DataTable consultaDT(string consulta)
        {
            comando = new OleDbCommand(consulta,connection);
            connection.Open();
            OleDbDataReader myReader = comando.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(myReader);
            myReader.Close();
            connection.Close();
            return dt;
        }
        public void consultaDR(string consulta)
        {
            comando = new OleDbCommand(consulta, connection);
            if(connection.State != ConnectionState.Open) connection.Open();
            dr = comando.ExecuteReader();

        }
        public void desconectar()
        {
            
                connection.Close();
        }
        public void insert_update(string consulta)
        {
            comando = new OleDbCommand(consulta, connection);
            connection.Open();
            comando.ExecuteNonQuery();
            connection.Close();
        }

    }
}
