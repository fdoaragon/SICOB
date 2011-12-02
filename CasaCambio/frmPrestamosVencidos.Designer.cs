namespace CasaCambio
{
    partial class frmPrestamosVencidos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxClientes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxEstatus = new System.Windows.Forms.ComboBox();
            this.dtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvPres = new System.Windows.Forms.DataGridView();
            this.clmIdPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdCliente = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmFechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCapitalPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPagoMinicmo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIntereses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFechaCorte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmdiaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEstatusPrestamo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmPagosFijos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmEmpeño = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmFechaLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCortar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPres)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(935, 583);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxClientes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxEstatus);
            this.groupBox1.Controls.Add(this.dtpFechaCorte);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Burcar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::CasaCambio.Properties.Resources.search;
            this.btnBuscar.Location = new System.Drawing.Point(642, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(104, 32);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Corte";
            // 
            // cbxClientes
            // 
            this.cbxClientes.FormattingEnabled = true;
            this.cbxClientes.Location = new System.Drawing.Point(9, 45);
            this.cbxClientes.Name = "cbxClientes";
            this.cbxClientes.Size = new System.Drawing.Size(255, 21);
            this.cbxClientes.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estatus";
            // 
            // cbxEstatus
            // 
            this.cbxEstatus.FormattingEnabled = true;
            this.cbxEstatus.Location = new System.Drawing.Point(270, 45);
            this.cbxEstatus.Name = "cbxEstatus";
            this.cbxEstatus.Size = new System.Drawing.Size(138, 21);
            this.cbxEstatus.TabIndex = 1;
            // 
            // dtpFechaCorte
            // 
            this.dtpFechaCorte.Checked = false;
            this.dtpFechaCorte.Location = new System.Drawing.Point(414, 46);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.ShowCheckBox = true;
            this.dtpFechaCorte.Size = new System.Drawing.Size(221, 20);
            this.dtpFechaCorte.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvPres);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(935, 475);
            this.splitContainer2.SplitterDistance = 814;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvPres
            // 
            this.dgvPres.AllowUserToAddRows = false;
            this.dgvPres.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPres.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIdPrestamo,
            this.clmIdCliente,
            this.clmFechaAlta,
            this.clmCantidad,
            this.clmCapitalPrestamo,
            this.clmPagoMinicmo,
            this.clmIntereses,
            this.clmMulta,
            this.clmFechaCorte,
            this.clmdiaPago,
            this.clmEstatusPrestamo,
            this.clmPagosFijos,
            this.clmEmpeño,
            this.clmFechaLimite,
            this.clmDetalles});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPres.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPres.Location = new System.Drawing.Point(0, 0);
            this.dgvPres.Name = "dgvPres";
            this.dgvPres.ReadOnly = true;
            this.dgvPres.RowHeadersVisible = false;
            this.dgvPres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPres.Size = new System.Drawing.Size(814, 475);
            this.dgvPres.TabIndex = 0;
            this.dgvPres.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPres_CellDoubleClick);
            this.dgvPres.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPres_DataBindingComplete);
            // 
            // clmIdPrestamo
            // 
            this.clmIdPrestamo.DataPropertyName = "IdPrestamo";
            this.clmIdPrestamo.HeaderText = "IdPrestamo";
            this.clmIdPrestamo.Name = "clmIdPrestamo";
            this.clmIdPrestamo.ReadOnly = true;
            // 
            // clmIdCliente
            // 
            this.clmIdCliente.DataPropertyName = "IdCliente";
            this.clmIdCliente.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.clmIdCliente.HeaderText = "Cliente";
            this.clmIdCliente.Name = "clmIdCliente";
            this.clmIdCliente.ReadOnly = true;
            this.clmIdCliente.Width = 45;
            // 
            // clmFechaAlta
            // 
            this.clmFechaAlta.DataPropertyName = "Fecha";
            this.clmFechaAlta.HeaderText = "Fecha Alta";
            this.clmFechaAlta.Name = "clmFechaAlta";
            this.clmFechaAlta.ReadOnly = true;
            this.clmFechaAlta.Width = 5;
            // 
            // clmCantidad
            // 
            this.clmCantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.clmCantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmCantidad.HeaderText = "Cantidad Prestada";
            this.clmCantidad.Name = "clmCantidad";
            this.clmCantidad.ReadOnly = true;
            this.clmCantidad.Width = 109;
            // 
            // clmCapitalPrestamo
            // 
            this.clmCapitalPrestamo.DataPropertyName = "Capital";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.clmCapitalPrestamo.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmCapitalPrestamo.HeaderText = "Capital";
            this.clmCapitalPrestamo.Name = "clmCapitalPrestamo";
            this.clmCapitalPrestamo.ReadOnly = true;
            this.clmCapitalPrestamo.Width = 64;
            // 
            // clmPagoMinicmo
            // 
            this.clmPagoMinicmo.DataPropertyName = "PagoMinimo";
            this.clmPagoMinicmo.HeaderText = "Pago Mínimo Pendiente";
            this.clmPagoMinicmo.Name = "clmPagoMinicmo";
            this.clmPagoMinicmo.ReadOnly = true;
            // 
            // clmIntereses
            // 
            this.clmIntereses.DataPropertyName = "Interes";
            this.clmIntereses.HeaderText = "% Intereses";
            this.clmIntereses.Name = "clmIntereses";
            this.clmIntereses.ReadOnly = true;
            // 
            // clmMulta
            // 
            this.clmMulta.DataPropertyName = "Multa";
            this.clmMulta.HeaderText = "Multa";
            this.clmMulta.Name = "clmMulta";
            this.clmMulta.ReadOnly = true;
            // 
            // clmFechaCorte
            // 
            this.clmFechaCorte.DataPropertyName = "FechaCorte";
            this.clmFechaCorte.HeaderText = "Fecha Corte";
            this.clmFechaCorte.Name = "clmFechaCorte";
            this.clmFechaCorte.ReadOnly = true;
            // 
            // clmdiaPago
            // 
            this.clmdiaPago.DataPropertyName = "DiaPago";
            this.clmdiaPago.HeaderText = "Día de Págo";
            this.clmdiaPago.Name = "clmdiaPago";
            this.clmdiaPago.ReadOnly = true;
            // 
            // clmEstatusPrestamo
            // 
            this.clmEstatusPrestamo.DataPropertyName = "Estatus";
            this.clmEstatusPrestamo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.clmEstatusPrestamo.HeaderText = "Estatus";
            this.clmEstatusPrestamo.Name = "clmEstatusPrestamo";
            this.clmEstatusPrestamo.ReadOnly = true;
            // 
            // clmPagosFijos
            // 
            this.clmPagosFijos.DataPropertyName = "PagosFijos";
            this.clmPagosFijos.HeaderText = "Págos Fijos";
            this.clmPagosFijos.Name = "clmPagosFijos";
            this.clmPagosFijos.ReadOnly = true;
            // 
            // clmEmpeño
            // 
            this.clmEmpeño.DataPropertyName = "Empeno";
            this.clmEmpeño.HeaderText = "Empeño";
            this.clmEmpeño.Name = "clmEmpeño";
            this.clmEmpeño.ReadOnly = true;
            // 
            // clmFechaLimite
            // 
            this.clmFechaLimite.DataPropertyName = "FechaLimite";
            this.clmFechaLimite.HeaderText = "Fecha Límite";
            this.clmFechaLimite.Name = "clmFechaLimite";
            this.clmFechaLimite.ReadOnly = true;
            // 
            // clmDetalles
            // 
            this.clmDetalles.DataPropertyName = "Detallesempeno";
            this.clmDetalles.HeaderText = "Detalles";
            this.clmDetalles.Name = "clmDetalles";
            this.clmDetalles.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnVer);
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo);
            this.flowLayoutPanel1.Controls.Add(this.btnCortar);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnBorrar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(117, 475);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnVer
            // 
            this.btnVer.Image = global::CasaCambio.Properties.Resources.View;
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(3, 3);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(104, 32);
            this.btnVer.TabIndex = 0;
            this.btnVer.Text = "Ver Detalles";
            this.btnVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::CasaCambio.Properties.Resources.add;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(3, 41);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(104, 32);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCortar
            // 
            this.btnCortar.Image = global::CasaCambio.Properties.Resources.exec;
            this.btnCortar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCortar.Location = new System.Drawing.Point(3, 79);
            this.btnCortar.Name = "btnCortar";
            this.btnCortar.Size = new System.Drawing.Size(104, 32);
            this.btnCortar.TabIndex = 2;
            this.btnCortar.Text = "Cortar";
            this.btnCortar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCortar.UseVisualStyleBackColor = true;
            this.btnCortar.Click += new System.EventHandler(this.btnCortar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::CasaCambio.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(3, 117);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 32);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::CasaCambio.Properties.Resources.delete;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(3, 155);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(104, 32);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrar.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmPrestamosVencidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 583);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPrestamosVencidos";
            this.Text = "frmPrestamosVencidos";
            this.Load += new System.EventHandler(this.frmPrestamosVencidos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPres)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvPres;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaCorte;
        private System.Windows.Forms.ComboBox cbxEstatus;
        private System.Windows.Forms.ComboBox cbxClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIdPrestamo;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCapitalPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPagoMinicmo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIntereses;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaCorte;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmdiaPago;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmEstatusPrestamo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmPagosFijos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmEmpeño;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFechaLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDetalles;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCortar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBorrar;
    }
}