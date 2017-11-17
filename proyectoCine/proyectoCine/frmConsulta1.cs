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
        string campos;
        string agruparPor;
        string condicion;
        bool agregarColumnaSexo = false;
        DataTable dataT;
        public frmConsulta1()
        {
            InitializeComponent();
        }
        public frmConsulta1(conexion c) : this()
        {
            campos = "nom_cliente+', '+ape_cliente Cliente, fecha_nac 'Fecha de Nacimiento', sexo Sexo, b.barrio Barrio, direccion Direccion, nro_tel Teléfono, mail Mail";
            agruparPor = "";
            condicion = "";
            con = c;
        }
        private void consulta()
        {
            bool condicionExiste = false;
            if (agregarColumnaSexo)
            {
                dgDatos.Columns.Add(cargarSexo());
                agregarColumnaSexo = false;
            }
            if (!txtNombre.Text.Equals(""))
            {
                condicionExiste = true;
                condicion = " where upper(nom_cliente+', '+ape_cliente) like '%'+upper('" + txtNombre.Text + "')+'%' ";
            }
            else
            {
                condicion = "";
            }
            if (cboBarrios.SelectedIndex != -1 && cboBarrios.SelectedIndex != 0)
            {
                if (!condicionExiste) condicion = " where ";
                else condicion += "and ";
                condicion += "b.cod_barrio="+cboBarrios.SelectedValue+" ";
            }
            
            if (cbxAgruparBarrio.Checked)
            {
                condicion = "";
                campos = "b.barrio 'Barrios', count(*) Cantidad";
                agruparPor = " group by Barrio";
                agregarColumnaSexo = true;
            }
            else
            {
                if (cbxSexo.Checked)
                {
                    condicion = "";
                    campos = "sexo 'Sexo', count(*) Cantidad";
                    agruparPor = " group by sexo";
                }
                else
                {
                    campos = "nom_cliente+', '+ape_cliente Cliente, fecha_nac 'Fecha de Nacimiento', sexo Sexo, b.barrio Barrio, direccion Direccion, nro_tel Teléfono, mail Mail";
                    agruparPor = "";
                }
                
            }
            dataT = con.consultaDT("select " + campos + " from clientes join barrios b on clientes.cod_barrio=b.cod_barrio " + condicion + agruparPor);
            dgDatos.DataSource = dataT;
            if(dgDatos.Columns["Sexo"]!=null && dgDatos.Columns.Count>2) dgDatos.Columns["Sexo"].DisplayIndex = 2;
        }
        private DataGridViewComboBoxColumn cargarSexo()
        {
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.DataPropertyName= "Sexo";
            cbo.Name = "Sexo";
            cbo.FlatStyle =  FlatStyle.Flat;
            DataTable dtc = new DataTable();
            dtc.Columns.Add("Sexo",typeof(bool));
            dtc.Columns.Add("sexoString", typeof(string));
            dtc.Rows.Add(true,"Varon");
            dtc.Rows.Add(false, "Mujer");
            cbo.DataSource = dtc;
            cbo.ValueMember = "sexo";
            cbo.DisplayMember = "sexoString";
            return cbo;
        }
        private void frmConsulta1_Load(object sender, EventArgs e)
        {
            dgDatos.Columns.Add(cargarSexo());
            consulta();
            cargarBarrios();
        }
        private void cargarBarrios()
        {
            DataTable dt = con.consultaDT("select * from barrios order by barrio");
            DataRow dr=dt.NewRow();
            dr["cod_barrio"] = -1;
            dr["barrio"] = "TODOS";
            dr["cod_ciudad"] = 0;
            dt.Rows.InsertAt(dr,0);
            cboBarrios.DataSource=dt;
            cboBarrios.ValueMember="cod_barrio";
            cboBarrios.DisplayMember = "barrio";
            
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta();
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            consulta();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reporte r = new reporte();
            r.cargarDataTable("Clientes",dataT);
            r.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxAgruparBarrio_CheckedChanged(object sender, EventArgs e)
        {
            consulta();
            txtNombre.Enabled = !cbxAgruparBarrio.Checked;
            cboBarrios.Enabled = !cbxAgruparBarrio.Checked;
            if (cbxSexo.Checked) cbxSexo.Checked = false;
        }

        private void cboBarrios_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void cbxSexo_CheckedChanged(object sender, EventArgs e)
        {
            consulta();
            txtNombre.Enabled = !cbxSexo.Checked;
            cboBarrios.Enabled = !cbxSexo.Checked;
            if (cbxAgruparBarrio.Checked) cbxAgruparBarrio.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
