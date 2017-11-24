namespace proyectoCine
{
    partial class frmConsulta3
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsulta3));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerDescripcion = new System.Windows.Forms.Button();
            this.btnVerActores = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxDirector = new System.Windows.Forms.ComboBox();
            this.cbxGeneros = new System.Windows.Forms.ComboBox();
            this.cbxAno = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgDatos, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1276, 733);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.btnVerDescripcion);
            this.groupBox1.Controls.Add(this.btnVerActores);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbxDirector);
            this.groupBox1.Controls.Add(this.cbxGeneros);
            this.groupBox1.Controls.Add(this.cbxAno);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(20, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1236, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnVerDescripcion
            // 
            this.btnVerDescripcion.Location = new System.Drawing.Point(493, 60);
            this.btnVerDescripcion.Name = "btnVerDescripcion";
            this.btnVerDescripcion.Size = new System.Drawing.Size(100, 23);
            this.btnVerDescripcion.TabIndex = 6;
            this.btnVerDescripcion.Text = "Ver Descripcion";
            this.btnVerDescripcion.UseVisualStyleBackColor = true;
            this.btnVerDescripcion.Click += new System.EventHandler(this.btnVerDescripcion_Click);
            // 
            // btnVerActores
            // 
            this.btnVerActores.Location = new System.Drawing.Point(493, 31);
            this.btnVerActores.Name = "btnVerActores";
            this.btnVerActores.Size = new System.Drawing.Size(100, 23);
            this.btnVerActores.TabIndex = 6;
            this.btnVerActores.Text = "Ver Actores";
            this.btnVerActores.UseVisualStyleBackColor = true;
            this.btnVerActores.Click += new System.EventHandler(this.btnVerActores_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(628, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 61);
            this.button1.TabIndex = 5;
            this.button1.Text = "Imprimir Informe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxDirector
            // 
            this.cbxDirector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDirector.FormattingEnabled = true;
            this.cbxDirector.Location = new System.Drawing.Point(293, 66);
            this.cbxDirector.Name = "cbxDirector";
            this.cbxDirector.Size = new System.Drawing.Size(156, 21);
            this.cbxDirector.TabIndex = 4;
            this.cbxDirector.SelectedIndexChanged += new System.EventHandler(this.cbxDirector_SelectedIndexChanged);
            // 
            // cbxGeneros
            // 
            this.cbxGeneros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGeneros.FormattingEnabled = true;
            this.cbxGeneros.Location = new System.Drawing.Point(293, 33);
            this.cbxGeneros.Name = "cbxGeneros";
            this.cbxGeneros.Size = new System.Drawing.Size(156, 21);
            this.cbxGeneros.TabIndex = 4;
            this.cbxGeneros.SelectedIndexChanged += new System.EventHandler(this.cbxGeneros_SelectedIndexChanged);
            // 
            // cbxAno
            // 
            this.cbxAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAno.FormattingEnabled = true;
            this.cbxAno.Location = new System.Drawing.Point(78, 66);
            this.cbxAno.Name = "cbxAno";
            this.cbxAno.Size = new System.Drawing.Size(107, 21);
            this.cbxAno.TabIndex = 4;
            this.cbxAno.SelectedIndexChanged += new System.EventHandler(this.cbxAno_SelectedIndexChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(78, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(107, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(221, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Director: ";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Género: ";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año:";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Titulo:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgDatos
            // 
            this.dgDatos.AllowUserToAddRows = false;
            this.dgDatos.AllowUserToDeleteRows = false;
            this.dgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDatos.GridColor = System.Drawing.Color.Gainsboro;
            this.dgDatos.Location = new System.Drawing.Point(20, 170);
            this.dgDatos.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.dgDatos.MultiSelect = false;
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.ReadOnly = true;
            this.dgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDatos.Size = new System.Drawing.Size(1236, 603);
            this.dgDatos.TabIndex = 0;
            this.dgDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDatos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1270, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PELICULAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmConsulta3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmConsulta3";
            this.Text = "frmConsulta3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConsulta3_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxDirector;
        private System.Windows.Forms.ComboBox cbxGeneros;
        private System.Windows.Forms.ComboBox cbxAno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnVerDescripcion;
        private System.Windows.Forms.Button btnVerActores;
    }
}