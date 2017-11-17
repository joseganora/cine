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
    public partial class frmConsulta2 : Form
    {
        conexion con;
        public frmConsulta2()
        {
            InitializeComponent();
        }
        public frmConsulta2(conexion c):this()
        {
            con = c;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
