using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proyectoCine
{

    public partial class abmPeliculas : Form
    {
        conexion conexion;
        pelicula[] peliculas;
        director[] directores;
        genero[] generos;
        bool nuevo = false;
        int contPeliculas = 0;
        
        public abmPeliculas()
        {
            InitializeComponent();
        }
        public abmPeliculas(conexion con) :this()
        {
            conexion = con;
        }
        private void abmPeliculas_Load(object sender, EventArgs e)
        {
            cargarArreglos();
            cargarListas();
            activarFormulario(false);
        }
        private void cargarArreglos()
        {
            cargarArregloAuxiliar("generos");
            cargarArregloAuxiliar("directores");
            cargarArregloPeliculas("");
        }
        private void cargarArregloPeliculas(string filtro)
        {
            peliculas = new pelicula[cantidadDeRegistros("peliculas") + 50];
            string comando="";
            comando = "select * from peliculas where upper(titulo)+convert(varchar(5),year(fecha_estreno))  like '%'+upper('" + filtro+ "')+'%' order by titulo";
            
            conexion.consultaDR(comando);
            OleDbDataReader dr = conexion.pDr;
            contPeliculas = 0;
            while (dr.Read())
            {
                pelicula p = new pelicula();
                if (!dr.IsDBNull(0)) p.pId = dr.GetInt32(0);
                if (!dr.IsDBNull(1)) p.pTitulo = (string)dr.GetValue(1);
                if (!dr.IsDBNull(2)) p.pEstreno = (DateTime)dr.GetValue(2);
                if (!dr.IsDBNull(3)) p.pIdioma = (string)dr.GetValue(3);
                if (!dr.IsDBNull(4)) p.pSinopsis = (string)dr.GetValue(4);
                if (!dr.IsDBNull(5)) p.pGenero = getGenero(dr.GetInt32(5));
                if (!dr.IsDBNull(6)) p.pDirector = getDirector(dr.GetInt32(6));
                if (!dr.IsDBNull(7)) p.pCalificacion = dr.GetInt32(7);
                if (!dr.IsDBNull(8)) p.pDuracion = dr.GetInt32(8);
                peliculas[contPeliculas] = p;
                contPeliculas++;
            }
            conexion.desconectar();
        }
        private void cargarArregloAuxiliar(string tabla)
        {
            int cantidad = cantidadDeRegistros(tabla);
            string comando = "select * from " + tabla;
            conexion.consultaDR(comando);
            OleDbDataReader dr = conexion.pDr;
            int i = 0;

            if (tabla.Equals("generos")) generos = new genero[cantidad];
            if (tabla.Equals("directores")) directores = new director[cantidad];
            while (dr.Read())
            {
                if (tabla.Equals("generos")) generos[i] = new genero(dr.GetInt32(0), (String)dr.GetValue(1));
                if (tabla.Equals("directores")) directores[i] = new director(dr.GetInt32(0), (String)dr.GetValue(1), (String)dr.GetValue(2));
                i++;
            }
            dr.Close();
        }
        private int cantidadDeRegistros(string tabla)
        {
            string comando = "select count(*) from " + tabla;
            conexion.consultaDR(comando);
            OleDbDataReader dr = conexion.pDr;
            dr.Read();
            int cantidad = dr.GetInt32(0);
            conexion.desconectar();
            return cantidad;
        }
        private void cargarCombo(ComboBox cmb, string nombreTabla)
        {

            DataTable dt = conexion.consultaDT("Select * from " + nombreTabla);
            cmb.DataSource = dt;
            cmb.ValueMember = dt.Columns[0].ColumnName;
            cmb.DisplayMember = dt.Columns[1].ColumnName;
        }
        private genero getGenero(int id)
        {
            for (int i = 0; i < generos.Length; i++) if (generos[i].pId == id) return generos[i];
            return null;
        }
        private director getDirector(int id)
        {
            for (int i = 0; i < directores.Length; i++) if (directores[i].pId == id) return directores[i];
            return null;
        }
        
        private void cargarListas()
        {
            for(int i=0;i<generos.Length;i++) cbxGenero.Items.Add(generos[i].pDescripcion);
            for(int i=0;i<directores.Length;i++) cbxDirector.Items.Add(directores[i].pNombre + ", " + directores[i].pApellido);
            lstPeliculas.Items.Clear();
            for (int i = 0; i < peliculas.Length; i++)
            {
                if (peliculas[i] != null)
                {
                    lstPeliculas.Items.Add(peliculas[i].pTitulo+" ("+ peliculas[i].pEstreno.Year+")");
                }
                else
                {
                    break;
                }
            }       
            
        }
        private void activarFormulario(bool activar)
        {
            txtId.Enabled = false;
            txtTitulo.Enabled = activar;
            dtpEstreno.Enabled = activar;
            cbxCalificacion.Enabled = activar;
            cbxDirector.Enabled = activar;
            cbxGenero.Enabled = activar;
            cbxIdioma.Enabled = activar;
            txtaSinopsis.Enabled = activar;
            txtDuracion.Enabled = activar;
            btnGuardar.Enabled = activar;
            btnCancelar.Enabled = activar;
            lstActores.Enabled = activar;
            btnNuevo.Enabled = !activar;
            lstPeliculas.Enabled = !activar;
            btnEditar.Enabled = !activar;
            btnBorrar.Enabled = !activar;
        }
        private void limpiarFormulario()
        {
            txtId.Text = "";
            txtTitulo.Text = "";
            dtpEstreno.Value = DateTime.Today;
            cbxCalificacion.SelectedIndex = -1;
            cbxDirector.SelectedIndex = -1;
            cbxGenero.SelectedIndex = -1;
            cbxIdioma.SelectedIndex = -1;
            txtaSinopsis.Text = "";
            txtDuracion.Text = "";
            lstActores.DataSource = null;
            //lstActores.Items.Clear();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nuevo
            activarFormulario(true);
            limpiarFormulario();
            
            string comand = "select max(cod_pelicula) from peliculas";
            conexion.consultaDR(comand);
            OleDbDataReader dr = conexion.pDr;
            dr.Read();
            txtId.Text = (dr.GetInt32(0)+1).ToString();
            conexion.desconectar();
            txtTitulo.Focus();
            nuevo = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //editar
            int seleccion = lstPeliculas.SelectedIndex;
            if (seleccion > -1)
            {
                txtId.Text = peliculas[seleccion].pId.ToString();
                txtTitulo.Text = peliculas[seleccion].pTitulo;
                dtpEstreno.Value = peliculas[seleccion].pEstreno;
                cbxCalificacion.SelectedItem = peliculas[seleccion].pCalificacion.ToString();
                cbxDirector.SelectedIndex = getIndexDir(peliculas[seleccion].pDirector.pId);
                cbxGenero.SelectedIndex = getIndexGenero(peliculas[seleccion].pGenero.pId);
                cbxIdioma.SelectedItem = peliculas[seleccion].pIdioma;
                txtaSinopsis.Text = peliculas[seleccion].pSinopsis;
                txtDuracion.Text = peliculas[seleccion].pDuracion.ToString();
                nuevo = false;
                activarFormulario(true);
                cargarListaDeActores(peliculas[seleccion].pId, true);
            }
            else
            {
                MessageBox.Show("SELECCIONE ALGUNA PELICULA PARA EDITAR");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //borrar
            int seleccion = lstPeliculas.SelectedIndex;
            if (seleccion > -1)
            {
                if (DialogResult.OK== MessageBox.Show("¿Esta seguro que quiere eliminar esta pelicula?", "éxito", MessageBoxButtons.OKCancel))
                {
                    int id = peliculas[lstPeliculas.SelectedIndex].pId;
                    
                    string comando = "delete * from peliculas where cod_pelicula=" + id.ToString();
                    conexion.insert_update(comando);
                    cargarArreglos();
                    cargarListas();
                }
            }
            else
            {
                MessageBox.Show("SELECCIONE ALGUNA PELICULA PARA EDITAR");
            }
        }
        private int getIndex(int id)
        {
            for(int i = 0; i < peliculas.Length; i++)
            {
                if (peliculas[i].pId == id) return i;
            }
            return -1;
        }
        private int getIndexGenero(int id)
        {
            for (int i = 0; i < generos.Length; i++)
            {
                if (generos[i].pId == id) return i;
            }
            return -1;
        }
        private int getIndexDir(int id)
        {
            for (int i = 0; i < directores.Length; i++)
            {
                if (directores[i].pId == id) return i;
            }
            return -1;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //guardar
            if (verificacionTexto(txtTitulo,label3)&&verificacionCombobox(cbxIdioma,label5) && verificacionCombobox(cbxGenero, label7) && verificacionCombobox(cbxDirector, label8) && verificacionCombobox(cbxCalificacion, label9)&& verificacionNumerica(txtDuracion, label10)) { 
            string comando = "";
            string accion;
            if (nuevo)
            {
                accion = " cargada ";
                pelicula p = new pelicula();
                p.pId = Convert.ToInt32(txtId.Text);
                p.pTitulo = txtTitulo.Text.ToUpper();
                p.pEstreno = dtpEstreno.Value;
                p.pIdioma = (string)cbxIdioma.SelectedItem;
                p.pSinopsis = txtaSinopsis.Text;
                p.pGenero = generos[cbxGenero.SelectedIndex];
                p.pDirector = directores[cbxDirector.SelectedIndex];
                p.pCalificacion = cbxCalificacion.SelectedIndex+1;
                p.pDuracion = Convert.ToInt32(txtDuracion.Text);
                peliculas[contPeliculas] = p;
                contPeliculas++;
                comando = "insert into peliculas values ("+ p.pId + ",'"+p.pTitulo+"', '"+p.pEstreno.ToShortDateString() + "', '"+
                          p.pIdioma + "', '" + p.pSinopsis + "', " + p.pGenero.pId + ", " + p.pDirector.pId + ", " +
                          p.pCalificacion + ", " +p.pDuracion+ ")";
            }
            else
            {
                accion = " editada ";
                int id = Convert.ToInt32(txtId.Text);
                int index = getIndex(id);
                peliculas[index].pTitulo = txtTitulo.Text.ToUpper();
                peliculas[index].pEstreno = dtpEstreno.Value;
                peliculas[index].pIdioma = (string)cbxIdioma.SelectedItem;
                peliculas[index].pSinopsis = txtaSinopsis.Text;
                peliculas[index].pGenero = generos[cbxGenero.SelectedIndex];
                peliculas[index].pDirector = directores[cbxDirector.SelectedIndex];
                peliculas[index].pCalificacion = cbxCalificacion.SelectedIndex + 1;
                peliculas[index].pDuracion = Convert.ToInt32(txtDuracion.Text);
                pelicula p=peliculas[index];
                comando = "update peliculas set titulo='" + p.pTitulo + "', fecha_estreno='" + p.pEstreno.ToShortDateString() + "', idioma='" +
                          p.pIdioma + "', sinopsis='" + p.pSinopsis + "', cod_genero=" + p.pGenero.pId + ", cod_director=" + p.pDirector.pId + ", calificacion=" +
                          p.pCalificacion + ", duracion=" + p.pDuracion + " where cod_pelicula="+ id;
            }
            conexion.insert_update(comando);
            MessageBox.Show("Pelicula" + accion + "correctamente", "éxito", MessageBoxButtons.OK);
            activarFormulario(false);
            cargarListas();
            limpiarFormulario();
            }
        }
        private bool verificacionTexto(TextBox t,Label l)
        {
            if (t.Text.Equals(""))
            {
                MessageBox.Show("El campo " + l.Text + " debe ser rellenado obligatoriamente");
                return false;
            }
            return true;
        }
        private bool verificacionNumerica(TextBox t,Label l)
        {
            try
            {
                Convert.ToInt32(t);
                return true;
            }catch(Exception exc)
            {
                MessageBox.Show("El campo "+l.Text+" solo acepta numeros. No incluya caracteres no numericos.");
                return false;
            }
        }
        private bool verificacionCombobox(ComboBox c, Label l)
        {
            if (c.SelectedIndex == -1)
            {
                MessageBox.Show("Es obligatorio llenar el campo " + l.Text );
                return false;
            }
            return true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //cancelar
            limpiarFormulario();
            activarFormulario(false);
            lstActores.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPelicula_TextChanged(object sender, EventArgs e)
        {
            cargarArregloPeliculas(txtPelicula.Text);
            cargarListas();
            if (lstPeliculas.SelectedIndex == -1)
                limpiarFormulario();
        }

        private void lstPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = lstPeliculas.SelectedIndex;
            if (seleccion > -1)
            {
                txtId.Text = peliculas[seleccion].pId.ToString();
                txtTitulo.Text = peliculas[seleccion].pTitulo;
                dtpEstreno.Value = peliculas[seleccion].pEstreno;
                cbxCalificacion.SelectedItem = peliculas[seleccion].pCalificacion.ToString();
                cbxDirector.SelectedIndex = getIndexDir(peliculas[seleccion].pDirector.pId);
                cbxGenero.SelectedIndex = getIndexGenero(peliculas[seleccion].pGenero.pId);
                cbxIdioma.SelectedItem = peliculas[seleccion].pIdioma;
                txtaSinopsis.Text = peliculas[seleccion].pSinopsis;
                txtDuracion.Text = peliculas[seleccion].pDuracion.ToString();
                cargarListaDeActores(peliculas[seleccion].pId,false);
            }
        }
        private void cargarListaDeActores(int id, bool nuevo)
        {
            DataTable dt = conexion.consultaDT("select a.nombre+', '+a.apellido Actor, a.cod_actor id from Actores a join actores_peliculas ap on a.cod_actor=ap.cod_actor where ap.cod_pelicula=" + id);
            if (nuevo) {
                DataRow dr = dt.NewRow();
                dr["Actor"] = "--------- NUEVO ----------";
                dr["id"] = 0;
                dt.Rows.Add(dr);
            }
            lstActores.DataSource = dt;
            lstActores.DisplayMember = "Actor";
            lstActores.SelectedIndex = -1;
        }

        private void lstActores_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lstActores.SelectedIndex != -1){
                int id = (int)((DataRowView)lstActores.SelectedItem)["id"];
                if (id == 0)
                {
                    frmActores actor = new frmActores(conexion,Convert.ToInt32(txtId.Text));
                    actor.ShowDialog();
                    if (actor.pAceptar){
                        conexion.insert_update("insert into actores_peliculas values ("+ Convert.ToInt32(txtId.Text) + ","+actor.pIdActor+")");
                        cargarListaDeActores(Convert.ToInt32(txtId.Text), true);
                    }
                }
            }
                
        }

        private void lstActores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstActores.SelectedIndex != -1)
            {
                int id = (int)((DataRowView)lstActores.SelectedItem)["id"];
                if (id != 0)
                {
                    DialogResult mess=MessageBox.Show("¿Desea quitar el actor " + ((DataRowView)lstActores.SelectedItem)["Actor"] + " de esta pelicula", "Eliminar actor de pelicula", MessageBoxButtons.OKCancel);

                    if (mess == DialogResult.OK){
                        conexion.insert_update("delete actores_peliculas where cod_pelicula=" + Convert.ToInt32(txtId.Text) + " and cod_actor=" + id);
                        cargarListaDeActores(Convert.ToInt32(txtId.Text), true);
                    }
                }
            }
        }
    }
}
