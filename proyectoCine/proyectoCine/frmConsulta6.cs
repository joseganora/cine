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
    public partial class frmConsulta6 : Form
    {
        conexion con;
        public frmConsulta6()
        {
            InitializeComponent();
        }
        public frmConsulta6(conexion c):this()
        {
            con = c;
        }
        private void frmConsulta6_Load(object sender, EventArgs e)
        {

        }
    }
}
