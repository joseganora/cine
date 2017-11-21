using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
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
        string printHeader;
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
            agruparPor = " order by Cliente";
            printHeader = "Clientes registrados";
            bool condicionExiste = false;
            if (agregarColumnaSexo)
            {
                dgDatos.Columns.Add(cargarSexo());
                agregarColumnaSexo = false;
            }
            if (!txtNombre.Text.Equals(""))
            {
                printHeader="Clientes registrados";
                condicionExiste = true;
                condicion = " where upper(nom_cliente+', '+ape_cliente) like '%'+upper('" + txtNombre.Text + "')+'%' ";
            }
            else
            {
                condicion = "";
            }
            if (cboBarrios.SelectedIndex != -1 && cboBarrios.SelectedIndex != 0)
            {
                printHeader = "Clientes registrados del barrio "+ ((DataRowView)cboBarrios.SelectedItem)[cboBarrios.DisplayMember];
                if (!condicionExiste) condicion = " where ";
                else condicion += "and ";
                condicion += "b.cod_barrio="+cboBarrios.SelectedValue+" ";
                condicionExiste = true;
            }
            
            if (cbxAgruparBarrio.Checked)
            {
                printHeader = "Cantidad de clientes por Barrio";
                condicion = "";
                campos = "b.barrio 'Barrios', count(*) Cantidad";
                agruparPor = " group by Barrio order by Barrios";
                agregarColumnaSexo = true;
            }
            else
            {
                if (cbxSexo.Checked)
                {
                    printHeader = "Cantidad de clientes por Sexo";
                    condicion = "";
                    campos = "sexo 'Sexo', count(*) Cantidad";
                    agruparPor = " group by sexo order by sexo";
                }
                else
                {
                    campos = "nom_cliente+', '+ape_cliente Cliente, fecha_nac 'Fecha de Nacimiento', sexo Sexo, b.barrio Barrio, direccion Direccion, nro_tel Teléfono, mail Mail";
                    agruparPor = " order by Cliente";
                }
                
            }
            if (cbxUltimaCompra.Checked && !cbxAgruparBarrio.Checked && !cbxSexo.Checked)
            {
                campos += ", t.fecha_hora 'Ultima Compra' ";
                condicion = " left join Tickets t on t.fecha_hora=(select max(fecha_hora) from Tickets where cod_cliente=c.cod_Cliente) " + condicion;
            }
            string consulta = "select " + campos + " from clientes c join barrios b on c.cod_barrio=b.cod_barrio " + condicion + agruparPor;
            if (cbxTieneReserva.Checked && !cbxAgruparBarrio.Checked && !cbxSexo.Checked) {
                if (condicionExiste) condicion += " and ";
                else condicion += " where ";
                consulta = "select " + campos + ", 'Si' 'Tiene Reserva' from clientes c join barrios b on c.cod_barrio=b.cod_barrio " + condicion + " exists (select cod_cliente from Reserva where cod_cliente=c.cod_cliente and fecha_hora>getdate()) " ;
                consulta += "union select " + campos + ", 'No' 'Tiene Reserva' from clientes c join barrios b on c.cod_barrio=b.cod_barrio " + condicion + " not exists (select cod_cliente from Reserva where cod_cliente=c.cod_cliente and fecha_hora>getdate()) " + agruparPor ;
            }
            
            //consulta = "select nom_cliente+', '+ape_cliente Cliente, fecha_nac 'Fecha de Nacimiento', sexo Sexo, b.barrio Barrio, direccion Direccion, nro_tel Teléfono, mail Mail from clientes,Barrios b";
            dataT = con.consultaDT(consulta);
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
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            printPreviewDialog1.PrintPreviewControl.Zoom = 150 / 100f;
            printPreviewDialog1.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxAgruparBarrio_CheckedChanged(object sender, EventArgs e)
        {
            consulta();
            txtNombre.Enabled = !cbxAgruparBarrio.Checked;
            cboBarrios.Enabled = !cbxAgruparBarrio.Checked;
            cbxTieneReserva.Enabled = !cbxAgruparBarrio.Checked;
            cbxUltimaCompra.Enabled = !cbxAgruparBarrio.Checked;
            cbxSexo.Enabled = !cbxAgruparBarrio.Checked;
           
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
            cbxTieneReserva.Enabled = !cbxSexo.Checked;
            cbxUltimaCompra.Enabled = !cbxSexo.Checked;
            cbxAgruparBarrio.Enabled = !cbxSexo.Checked;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            consulta();
        }
        int rowcount = 0;
        int pageCount = 1;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int count = 0;
            string footer = string.Empty;
            int columnCount = dataT.Columns.Count;
            
            int maxRows = dataT.Rows.Count;
            PaperSize pz= printDocument1.DefaultPageSettings.PaperSize;
            
            using (Graphics g = e.Graphics)
            {
                
                Brush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(brush);
                Font font;
                if (columnCount>3) font= new Font("Arial", 5);
                else font = new Font("Arial", 10);
                SizeF size;

                int x = 20, y = 20, width = (pz.Width/columnCount)-(40/ columnCount);
                float xPadding;

                // Here title is written, sets to top-middle position of the page
                size = g.MeasureString(printHeader, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(printHeader, font, brush, (pz.Width- size.Width) /2, y + 5);

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
                    if (rowcount < count) { 
                    

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
                        else if (row[i].GetType() == typeof(bool))
                        {
                            size = g.MeasureString("V", font);
                            xPadding = (width - size.Width) / 2;
                            if ((bool)row[i]) g.DrawString("V", font, brush, x + xPadding, y + 5);
                            else g.DrawString("M", font, brush, x + xPadding, y + 5);
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
                footer = "Registros: " + rowcount + " - " + count + " | Pagina: " + pageCount;
                if (e.HasMorePages)
                {
                    pageCount++;
                    rowcount = count;
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
