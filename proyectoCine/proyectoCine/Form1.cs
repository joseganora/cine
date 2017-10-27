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

            
                new frmConsulta1().Show();
            
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

        private void btnConsulta3_Click(object sender, EventArgs e)
        {
            new frmConsulta3().Show();
        }

        private void btnConsulta2_Click(object sender, EventArgs e)
        {
            new frmConsulta2().Show();
        }

        private void btnConsulta4_Click(object sender, EventArgs e)
        {
            new frmConsulta4().Show();
        }

        private void btnConsulta5_Click(object sender, EventArgs e)
        {
            new frmConsulta5().Show();
        }

        private void btnConsulta6_Click(object sender, EventArgs e)
        {
            new frmConsulta6().Show();
        }
    }
}
