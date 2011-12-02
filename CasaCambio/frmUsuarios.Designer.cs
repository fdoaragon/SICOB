namespace CasaCambio
{
    partial class frmUsuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.clmUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUsuario,
            this.clmPass,
            this.clmNombres,
            this.clmApellidos,
            this.clmSucursal,
            this.clmCaja});
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(710, 304);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUsuarios_DataError);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(566, 310);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // clmUsuario
            // 
            this.clmUsuario.DataPropertyName = "IdUsuario";
            this.clmUsuario.HeaderText = "Usuario";
            this.clmUsuario.Name = "clmUsuario";
            // 
            // clmPass
            // 
            this.clmPass.DataPropertyName = "Contrasena";
            this.clmPass.HeaderText = "Contraseña";
            this.clmPass.Name = "clmPass";
            // 
            // clmNombres
            // 
            this.clmNombres.DataPropertyName = "Nombres";
            this.clmNombres.HeaderText = "Nombres";
            this.clmNombres.Name = "clmNombres";
            // 
            // clmApellidos
            // 
            this.clmApellidos.DataPropertyName = "Apellidos";
            this.clmApellidos.HeaderText = "Apellidos";
            this.clmApellidos.Name = "clmApellidos";
            // 
            // clmSucursal
            // 
            this.clmSucursal.DataPropertyName = "IdSucursal";
            this.clmSucursal.HeaderText = "Sucursal";
            this.clmSucursal.Name = "clmSucursal";
            // 
            // clmCaja
            // 
            this.clmCaja.DataPropertyName = "IdCaja";
            this.clmCaja.HeaderText = "Caja";
            this.clmCaja.Name = "clmCaja";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 341);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCaja;
    }
}