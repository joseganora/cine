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
    public partial class frmConsulta3 : Form
    {
        conexion con;
        public frmConsulta3()
        {
            InitializeComponent();
        }
        public frmConsulta3(conexion c):this()
        {
            con = c;
        }
        private void frmConsulta3_Load(object sender, EventArgs e)
        {

        }
    }
}
