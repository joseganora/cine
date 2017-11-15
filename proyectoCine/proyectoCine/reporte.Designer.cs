namespace proyectoCine
{
    using Microsoft.Reporting.WinForms;
    using System.Data;
    partial class reporte
    {
        DataSet datosDelReporte;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void cargarDataTable(string nombre,DataTable dt)
        {
            //datosDelReporte = dt;
            reportViewer1.LocalReport.DisplayName=nombre;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(source);
            //reportViewer1.LocalReport.Refresh();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "proyectoCine.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(549, 423);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 447);
            this.Controls.Add(this.reportViewer1);
            this.Name = "reporte";
            this.Text = "reporte";
            this.Load += new System.EventHandler(this.reporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}