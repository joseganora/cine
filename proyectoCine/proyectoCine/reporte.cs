using Microsoft.Reporting.WinForms;
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
    public partial class reporte : Form
    {
        string nombre;
        DataTable dt;
        public reporte()
        {
            InitializeComponent();
        }
        public reporte(string nom,DataTable dt) : this()
        {
            nombre = nom;
            this.dt = dt;
        }
        private void reporte_Load(object sender, EventArgs e)
        {


        }
    }
}
