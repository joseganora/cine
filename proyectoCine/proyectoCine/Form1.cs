using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoCine
{
    public partial class frmPrincipal : Form
    {
        conexion con;
        public frmPrincipal()
        {
            con = new conexion();
            InitializeComponent();
        }

        private void btnConsulta1_Click(object sender, EventArgs e)
        {

            if (con.verificarConexion())
            {
                new frmConsulta1().Show();
            }
            else
            {
                MessageBox.Show("No se puede realizar la consulta, verifique la conexión");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool estado = con.verificarConexion();
            btnConsulta1.Enabled = estado;
            btnConsulta2.Enabled = estado;
            btnConsulta3.Enabled = estado;
            btnConsulta4.Enabled = estado;
            btnConsulta5.Enabled = estado;
            btnConsulta6.Enabled = estado;
            if (estado)
            {
                lblEstadoConexion.Text = "Conectado";
                lblEstadoConexion.ForeColor = Color.Green;
            }
            else
            {
                lblEstadoConexion.Text = "Desconectado";
                lblEstadoConexion.ForeColor = Color.Red;
            }
        }
    }
}
