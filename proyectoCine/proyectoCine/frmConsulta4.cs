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
    public partial class frmConsulta4 : Form
    {
        conexion con;
        public frmConsulta4()
        {
            InitializeComponent();
        }
        public frmConsulta4(conexion c):this()
        {
            con = c;
        }

        private void frmConsulta4_Load(object sender, EventArgs e)
        {

        }
    }
}
