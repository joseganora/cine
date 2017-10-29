﻿using System;
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
        string dbString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/PEPE/cine/cine-tp.accdb";
        OleDbConnection con;
        OleDbCommand comand;
        pelicula[] peliculas;
        director[] directores;
        genero[] generos;
        bool nuevo = false;
        int contPeliculas = 0;
        public abmPeliculas()
        {
            con = new OleDbConnection(dbString);
            InitializeComponent();
        }

        private void abmPeliculas_Load(object sender, EventArgs e)
        {
            cargarArreglos();
            cargarListas();
            activarFormulario(false);
        }
        private void cargarArreglos()
        {
            string comando = "select count(*) from generos";
            comand = new OleDbCommand(comando, con);
            con.Open();
            OleDbDataReader dr = comand.ExecuteReader();
            dr.Read();
            int cantidad;
            cantidad = dr.GetInt32(0);
            dr.Close();

            generos = new genero[cantidad];
            comando = "select * from generos";
            comand = new OleDbCommand(comando, con);
            dr = comand.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                generos[i] = new genero(dr.GetInt32(0),(String)dr.GetValue(1));
                i++;
            }
            dr.Close();

            comando = "select count(*) from directores";
            comand = new OleDbCommand(comando, con);
            dr = comand.ExecuteReader();
            dr.Read();
            cantidad = dr.GetInt32(0);
            dr.Close();

            directores = new director[cantidad];
            comando = "select * from directores";
            comand = new OleDbCommand(comando, con);
            dr = comand.ExecuteReader();
            i = 0;
            while (dr.Read())
            {
                directores[i] = new director(dr.GetInt32(0), (String)dr.GetValue(1), (String)dr.GetValue(2));
                i++;
            }
            dr.Close();

            comando = "select count(*) from peliculas";
            comand = new OleDbCommand(comando, con);
            dr = comand.ExecuteReader();
            dr.Read();
            cantidad = dr.GetInt32(0)+50;
            dr.Close();

            peliculas = new pelicula[cantidad];
            comando = "select * from peliculas order by titulo";
            comand = new OleDbCommand(comando, con);
            dr = comand.ExecuteReader();
            contPeliculas = 0;
            while (dr.Read())
            {
                pelicula p = new pelicula();
                p.pId = dr.GetInt32(0);
                p.pTitulo = (string)dr.GetValue(1);
                p.pEstreno = DateTime.Parse((string)dr.GetValue(2));
                p.pIdioma = (string)dr.GetValue(3);
                p.pSinopsis = (string)dr.GetValue(4);
                p.pGenero = getGenero(dr.GetInt32(5));
                p.pDirector = getDirector(dr.GetInt32(6));
                p.pCalificacion = dr.GetInt32(7);
                p.pDuracion = dr.GetInt32(8);
                peliculas[contPeliculas] = p;
                contPeliculas++;
            }
            dr.Close();
            con.Close();

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
            btnNuevo.Enabled = !activar;
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
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nuevo
            activarFormulario(true);
            limpiarFormulario();
            con.Open();
            comand = new OleDbCommand("select max(cod_pelicula) from peliculas",con);
            OleDbDataReader dr = comand.ExecuteReader();
            dr.Read();
            txtId.Text = (dr.GetInt32(0)+1).ToString();
            dr.Close();
            con.Close();
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
                    con.Open();
                    string comando = "delete * from peliculas where cod_pelicula=" + id.ToString();
                    comand = new OleDbCommand(comando, con);
                    comand.ExecuteNonQuery();
                    con.Close();
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
            con.Open();
            comand = new OleDbCommand(comando,con);
            comand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Pelicula" + accion + "correctamente", "éxito", MessageBoxButtons.OK);
            activarFormulario(false);
            cargarListas();
            limpiarFormulario();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //cancelar
            limpiarFormulario();
            activarFormulario(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}