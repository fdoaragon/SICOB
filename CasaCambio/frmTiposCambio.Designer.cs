namespace CasaCambio
{
    partial class frmTiposCambio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.tbxVenta = new System.Windows.Forms.NumericUpDown();
            this.tbxCompra = new System.Windows.Forms.NumericUpDown();
            this.dgvTiposC = new System.Windows.Forms.DataGridView();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTCV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbxVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposC)).BeginInit();
            this.SuspendLayout();
            // 
            // dpFecha
            // 
            this.dpFecha.Checked = false;
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(12, 25);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(90, 20);
            this.dpFecha.TabIndex = 0;
            // 
            // tbxVenta
            // 
            this.tbxVenta.DecimalPlaces = 2;
            this.tbxVenta.Location = new System.Drawing.Point(108, 25);
            this.tbxVenta.Name = "tbxVenta";
            this.tbxVenta.Size = new System.Drawing.Size(90, 20);
            this.tbxVenta.TabIndex = 1;
            // 
            // tbxCompra
            // 
            this.tbxCompra.DecimalPlaces = 2;
            this.tbxCompra.Location = new System.Drawing.Point(204, 25);
            this.tbxCompra.Name = "tbxCompra";
            this.tbxCompra.Size = new System.Drawing.Size(90, 20);
            this.tbxCompra.TabIndex = 2;
            // 
            // dgvTiposC
            // 
            this.dgvTiposC.AllowUserToAddRows = false;
            this.dgvTiposC.AllowUserToDeleteRows = false;
            this.dgvTiposC.AllowUserToOrderColumns = true;
            this.dgvTiposC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiposC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFecha,
            this.clmTCV,
            this.clmTCC});
            this.dgvTiposC.Location = new System.Drawing.Point(12, 54);
            this.dgvTiposC.Name = "dgvTiposC";
            this.dgvTiposC.ReadOnly = true;
            this.dgvTiposC.RowHeadersVisible = false;
            this.dgvTiposC.Size = new System.Drawing.Size(281, 324);
            this.dgvTiposC.TabIndex = 3;
            // 
            // clmFecha
            // 
            this.clmFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.clmFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.ReadOnly = true;
            // 
            // clmTCV
            // 
            this.clmTCV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTCV.DataPropertyName = "TCVenta";
            this.clmTCV.HeaderText = "Venta";
            this.clmTCV.Name = "clmTCV";
            this.clmTCV.ReadOnly = true;
            this.clmTCV.Width = 60;
            // 
            // clmTCC
            // 
            this.clmTCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmTCC.DataPropertyName = "TCCompra";
            this.clmTCC.HeaderText = "Compra";
            this.clmTCC.Name = "clmTCC";
            this.clmTCC.ReadOnly = true;
            this.clmTCC.Width = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compra";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 384);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 21);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(93, 384);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 21);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // frmTiposCambio
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 414);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTiposC);
            this.Controls.Add(this.tbxCompra);
            this.Controls.Add(this.tbxVenta);
            this.Controls.Add(this.dpFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTiposCambio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipos de Cambios";
            this.Load += new System.EventHandler(this.frmTiposCambio_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTiposCambio_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tbxVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.NumericUpDown tbxVenta;
        private System.Windows.Forms.NumericUpDown tbxCompra;
        private System.Windows.Forms.DataGridView dgvTiposC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTCV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTCC;
    }
}

