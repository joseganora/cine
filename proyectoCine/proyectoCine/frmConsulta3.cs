using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoCine
{
    public partial class frmConsulta3 : Form
    {
        conexion con;
        DataTable dataT;
        string masCondiciones = "";
        string printHeader = "";
        int rowCount = 0, pageCount = 1;
        public frmConsulta3()
        {
            InitializeComponent();
        }
        void consulta()
        {
            masCondiciones = "";
            if (cbxAno.SelectedIndex!=-1 && cbxAno.SelectedIndex != 0)
            {
                masCondiciones += " and year(p.fecha_estreno)=" + ((DataRowView)cbxAno.SelectedItem)["value"].ToString();
            }
            if (cbxDirector.SelectedIndex != -1 && cbxDirector.SelectedIndex != 0)
            {
                masCondiciones += " and d.cod_director=" + cbxDirector.SelectedValue;
            }
            if (cbxGeneros.SelectedIndex != -1 && cbxGeneros.SelectedIndex != 0)
            {
                masCondiciones += " and g.cod_genero=" + cbxGeneros.SelectedValue;
            }
            string consulta = "select p.cod_pelicula Id,p.titulo Titulo, year(p.fecha_estreno) 'Año', p.idioma 'Idioma',g.nombre 'Genero', d.apellido+', '+d.nombre 'Director',p.calificacion Califición, p.duracion 'Duracion (Min)' from Peliculas p join Generos g on p.cod_genero =g.cod_genero join Directores d on p.cod_director = d.cod_director where upper(p.titulo) like '%'+upper('"+txtNombre.Text+"')+'%' "+masCondiciones+ " order by Titulo";
            dataT = con.consultaDT(consulta);
            dgDatos.DataSource = dataT;
        }
        public frmConsulta3(conexion c):this()
        {
            con = c;
        }
        private void frmConsulta3_Load(object sender, EventArgs e)
        {
            cargarCombo(cbxAno, "peliculas", "year(fecha_estreno)", "year(fecha_estreno)","");
            cargarCombo(cbxDirector, "directores", "cod_director", "nombre+', '+apellido","");
            cargarCombo(cbxGeneros, "generos", "cod_genero", "nombre","");
            consulta();
        }
        void cargarCombo(ComboBox cb,string tabla,string value,string display, string cond)
        {
            DataTable dt = con.consultaDT("select distinct "+value+" value, convert(varchar(30),"+display+") display from "+tabla+" h "+cond);
            DataRow dr = dt.NewRow();
            dr["value"] = -1;
            dr["display"] = "TODOS";
            dt.Rows.InsertAt(dr, 0);
            cb.DataSource = dt;
            cb.ValueMember = "value";
            cb.DisplayMember = "display";
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta();

            //cargarCombo(cbxDirector, "directores", "cod_director", "nombre+', '+apellido", " where exists (select cod_pelicula from peliculas p where p.cod_director= h.cod_director and year(p.fecha_estreno)="+ ((DataRowView)cbxAno.SelectedItem)["value"].ToString() + ") ");
            //cargarCombo(cbxGeneros, "generos", "cod_genero", "nombre", "where 0=0 " + " where exists (select cod_pelicula from peliculas p where p.cod_genero= h.cod_genero and year(p.fecha_estreno)=" + ((DataRowView)cbxAno.SelectedItem)["value"].ToString() + ") ");
        }

        private void cbxGeneros_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta();
            //cargarCombo(cbxAno, "peliculas", "year(fecha_estreno)", "year(fecha_estreno)", "where 0=0 " + masCondiciones);
            //cargarCombo(cbxDirector, "directores", "cod_director", "nombre+', '+apellido", "where 0=0 " + masCondiciones);
        }

        private void cbxDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta();
            //cargarCombo(cbxAno, "peliculas", "year(fecha_estreno)", "year(fecha_estreno)", "where 0=0 " + masCondiciones);
            //cargarCombo(cbxGeneros, "generos", "cod_genero", "nombre", "where 0=0 " + masCondiciones);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            printPreviewDialog1.ShowDialog();
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVerActores.Enabled = dgDatos.SelectedRows != null;
            btnVerDescripcion.Enabled = dgDatos.SelectedRows != null;
        }

        private void btnVerActores_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDatos.SelectedRows[0];
            int id = (int)dr.Cells[0].Value ;
            DataTable dt = con.consultaDT("select p.titulo,a.apellido+', '+a.nombre 'Nombre' from Peliculas p join actores_peliculas ap on p.cod_pelicula=ap.cod_pelicula join Actores a on ap.cod_actor =a.cod_actor where p.cod_pelicula="+id);
            string actores="";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                actores += " - "+dt.Rows[i]["Nombre"].ToString()+"\n";
            }
            if(dt.Rows.Count==0) MessageBox.Show("El sistema no registra actores para esta pelicula", "ACTORES DE " + dr.Cells[1].Value.ToString());
            MessageBox.Show(actores,"ACTORES DE "+ dr.Cells[1].Value.ToString());
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int count = 0;
            string footer = string.Empty;
            int columnCount = dataT.Columns.Count;

            int maxRows = dataT.Rows.Count;
            PaperSize pz = printDocument1.DefaultPageSettings.PaperSize;

            using (Graphics g = e.Graphics)
            {

                Brush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(brush);
                Font font;
                if (columnCount > 3) font = new Font("Arial", 5);
                else font = new Font("Arial", 10);
                SizeF size;

                int x = 20, y = 20, width = (pz.Width / columnCount) - (40 / columnCount);
                float xPadding;

                // Here title is written, sets to top-middle position of the page
                size = g.MeasureString(printHeader, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(printHeader, font, brush, (pz.Width - size.Width) / 2, y + 5);

                x = 20;
                y += 50;

                // Writes out all column names in designated locations, aligned as a table
                foreach (DataColumn column in dataT.Columns)
                {
                    size = g.MeasureString(column.ColumnName, font);
                    xPadding = (width - size.Width) / 2;
                    g.DrawString(column.ColumnName, font, brush, x + xPadding, y + 5);
                    x += width;
                }

                x = 20;
                y += 30;

                // Process each row and place each item under correct column.

                foreach (DataRow row in dataT.Rows)
                {
                    count++;
                    if (rowCount < count)
                    {


                        for (int i = 0; i < columnCount; i++)
                        {
                            size = g.MeasureString(row[i].ToString(), font);
                            xPadding = (width - size.Width) / 2;
                            if (row[i].GetType() == typeof(DateTime))
                            {
                                size = g.MeasureString(((DateTime)row[i]).ToString("dd/MM/yyyy"), font);
                                xPadding = (width - size.Width) / 2;
                                g.DrawString(((DateTime)row[i]).ToString("dd/MM/yyyy"), font, brush, x + xPadding, y + 5);
                            }
                            else
                                g.DrawString(row[i].ToString(), font, brush, x + xPadding, y + 5);
                            x += width;
                        }

                        x = 20;
                        y += 30;
                        if (y > pz.Height - 100)
                        {
                            e.HasMorePages = true;
                            break;
                        }
                    }
                }
                y += 30;
                footer = "Registros: " + rowCount + " - " + count + " | Pagina: " + pageCount;
                if (e.HasMorePages)
                {
                    pageCount++;
                    rowCount = count;
                }
                size = g.MeasureString(footer, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(footer, font, brush, (pz.Width - size.Width) / 2, y + 5);

                x = 20;
                y += 30;
            }
        }
    }
}
