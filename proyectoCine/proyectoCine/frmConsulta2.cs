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
    public partial class frmConsulta2 : Form
    {
        conexion con;
        DataTable dataT;
        string printHeader;
        int rowCount = 0, pageCount = 1;
        public frmConsulta2()
        {
            InitializeComponent();
            printHeader = "Reservas Registradas";
        }
        private void consulta()
        {
            string condicion= " where upper(c.ape_cliente+', '+c.nom_cliente) like '%'+upper('" + txtCliente.Text + "')+'%' ";
            if (rbtMes.Checked && cbxMes.SelectedIndex != -1)
            {
                printHeader = "Reservas registradas para el mes de " + cbxMes.SelectedItem;
                condicion += "and month(r.fecha_hora) = " + (cbxMes.SelectedIndex+1) + " and year(r.fecha_hora)=" + nudAño.Value ;
            }
            else if (rbtDesde.Checked)
            {
                printHeader = "Reservas registradas entre " + dtpDesde.Value.ToString("dd/MM/yyyy")+" y "+ dtpHasta.Value.ToString("dd/MM/yyyy");
                condicion += " and r.fecha_hora between '"+dtpDesde.Value.ToString()+"' and '" + dtpHasta.Value.ToString()+"'";
            }
            dataT =  con.consultaDT("select r.cod_reserva 'Código de reserva', r.fecha_hora Fecha, c.ape_cliente+', '+c.nom_cliente Cliente, f.dia_horario 'Fecha de la función', f.cod_sala Sala,r.cod_butaca Butaca, s.nom_sucursal Sucursal " +
                "from reserva r join clientes c on r.cod_cliente=c.cod_cliente join Funciones f on r.cod_funcion = f.cod_funcion join Butacas b on r.cod_butaca=b.cod_butaca join Sucursales s on r.cod_sucursal=s.cod_sucursal "+condicion);
            dgDatos.DataSource = dataT;
        }
        public frmConsulta2(conexion c):this()
        {
            con = c;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmConsulta2_Load(object sender, EventArgs e)
        {
            cbxMes.SelectedIndex = DateTime.Today.Month-1;
            nudAño.Value= DateTime.Today.Year;
            dtpHasta.Value = DateTime.Today;
            consulta();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta();
            
        }

        private void nudAño_ValueChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            consulta();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cbxMes.Enabled = rbtMes.Checked;
            nudAño.Enabled = rbtMes.Checked;
            consulta();
        }

        private void rbtDesde_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = rbtDesde.Checked;
            dtpHasta.Enabled = rbtDesde.Checked;
            consulta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            printPreviewDialog1.PrintPreviewControl.Zoom = 150 / 100f;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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
