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
    public partial class frmConsulta5 : Form
    {
        conexion con;
        public frmConsulta5()
        {
            InitializeComponent();
        }
        public frmConsulta5(conexion c):this()
        {
            con = c;
        }
        private void frmConsulta5_Load(object sender, EventArgs e)
        {

        }
    }
}
