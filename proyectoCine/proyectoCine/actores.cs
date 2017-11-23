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
    public partial class frmActores : Form
    {
        conexion con;
        int id;
        int idActor;
        public int pIdActor
        {
            get { return idActor; }
        }
        bool Aceptar;
        public bool pAceptar
        {
            get { return Aceptar; }
        }
        public frmActores(conexion conex, int id)
        {
            InitializeComponent();
            con = conex;
            this.id = id;
            Aceptar = false;
        }

        private void frmActores_Load(object sender, EventArgs e)
        {
            DataTable dt = con.consultaDT("select a.nombre+', '+a.apellido Actor, a.cod_actor id from Actores a where not exists (select cod_actor from actores_peliculas where cod_actor=a.cod_actor and cod_pelicula=" + id+ ") order by Actor");
            cbxActores.DataSource = dt;
            cbxActores.DisplayMember = "Actor";
            cbxActores.ValueMember="id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //agregar Actor
            groupBox1.Visible = true;
            btnAgregar.Enabled = false;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            cbxActores.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idActor = (int)cbxActores.SelectedValue;
            Aceptar = true;
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            btnAgregar.Enabled = true;
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            cbxActores.Enabled = true;
            con.insert_update("insert into actores values((select max(cod_actor) from actores)+1,'" +  txtNombre.Text.ToUpper() + "', '" + txtApellido.Text.ToUpper() + "')");
            DataTable dt = con.consultaDT("select a.nombre+', '+a.apellido Actor, a.cod_actor id from Actores a where not exists (select cod_actor from actores_peliculas where cod_actor=a.cod_actor and cod_pelicula=" + id + ") order by Actor");
            cbxActores.DataSource = dt;
            cbxActores.DisplayMember = "Actor";
            cbxActores.ValueMember = "id";
            cbxActores.SelectedValue = con.consultaDT("select max(cod_actor) from actores").Rows[0].ItemArray[0];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            btnAgregar.Enabled = true;
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            cbxActores.Enabled = true;
            txtApellido.Text = "";
            txtNombre.Text = "";
        }
    }
}
