using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoCine
{
    public partial class frmConsulta1 : Form
    {
        conexion con;
        
        public frmConsulta1()
        {
            InitializeComponent();
        }
        

        private void frmConsulta1_Load(object sender, EventArgs e)
        {
            con = new conexion();
            DataTable dt =  con.consulta("select * from clientes");
            
            dgDatos.DataSource = dt;
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = con.consulta("select * from clientes where upper(nom_cliente) like '%upper("+txtNombre.Text+ ")%'");

            dgDatos.DataSource = dt;
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt = con.consulta("select * from clientes where upper(nom_cliente) like upper('%" + txtNombre.Text + "%')");

            dgDatos.DataSource = dt;
        }
    }
}
