namespace CasaCambio
{
    partial class frmConfig
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.tbxImpresora = new System.Windows.Forms.TextBox();
            this.chkImpPantalla = new System.Windows.Forms.CheckBox();
            this.tbxCopias = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxConexion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbxencript = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnConn = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCopias)).BeginInit();
            this.pnConn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 15);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(172, 15);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Impresora Predeterminada";
            // 
            // tbxImpresora
            // 
            this.tbxImpresora.Location = new System.Drawing.Point(15, 33);
            this.tbxImpresora.Name = "tbxImpresora";
            this.tbxImpresora.Size = new System.Drawing.Size(501, 23);
            this.tbxImpresora.TabIndex = 1;
            // 
            // chkImpPantalla
            // 
            this.chkImpPantalla.AutoSize = true;
            this.chkImpPantalla.Location = new System.Drawing.Point(141, 77);
            this.chkImpPantalla.Name = "chkImpPantalla";
            this.chkImpPantalla.Size = new System.Drawing.Size(150, 19);
            this.chkImpPantalla.TabIndex = 2;
            this.chkImpPantalla.Text = "Imprimir en  Pantalla";
            this.chkImpPantalla.UseVisualStyleBackColor = true;
            // 
            // tbxCopias
            // 
            this.tbxCopias.Location = new System.Drawing.Point(15, 77);
            this.tbxCopias.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tbxCopias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxCopias.Name = "tbxCopias";
            this.tbxCopias.Size = new System.Drawing.Size(120, 23);
            this.tbxCopias.TabIndex = 3;
            this.tbxCopias.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "No. Copias Ticket";
            // 
            // tbxConexion
            // 
            this.tbxConexion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxConexion.Location = new System.Drawing.Point(12, 27);
            this.tbxConexion.Multiline = true;
            this.tbxConexion.Name = "tbxConexion";
            this.tbxConexion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxConexion.Size = new System.Drawing.Size(501, 47);
            this.tbxConexion.TabIndex = 6;
            this.tbxConexion.Leave += new System.EventHandler(this.tbxConexion_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Conexión";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::CasaCambio.Properties.Resources.cancel_24;
            this.btnCancelar.Location = new System.Drawing.Point(272, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 39);
            this.btnCancelar.TabIndex = 77;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::CasaCambio.Properties.Resources.save_24;
            this.btnGuardar.Location = new System.Drawing.Point(145, 267);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 39);
            this.btnGuardar.TabIndex = 76;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbxencript
            // 
            this.tbxencript.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxencript.Location = new System.Drawing.Point(12, 95);
            this.tbxencript.Multiline = true;
            this.tbxencript.Name = "tbxencript";
            this.tbxencript.ReadOnly = true;
            this.tbxencript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxencript.Size = new System.Drawing.Size(501, 47);
            this.tbxencript.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 15);
            this.label1.TabIndex = 78;
            this.label1.Text = "Conexión Encriptada";
            // 
            // pnConn
            // 
            this.pnConn.Controls.Add(this.tbxencript);
            this.pnConn.Controls.Add(this.label1);
            this.pnConn.Controls.Add(this.tbxConexion);
            this.pnConn.Controls.Add(this.label3);
            this.pnConn.Location = new System.Drawing.Point(3, 106);
            this.pnConn.Name = "pnConn";
            this.pnConn.Size = new System.Drawing.Size(521, 152);
            this.pnConn.TabIndex = 80;
            // 
            // frmConfig
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(524, 314);
            this.ControlBox = false;
            this.Controls.Add(this.pnConn);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCopias);
            this.Controls.Add(this.chkImpPantalla);
            this.Controls.Add(this.tbxImpresora);
            this.Controls.Add(this.lbl1);
            this.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbxCopias)).EndInit();
            this.pnConn.ResumeLayout(false);
            this.pnConn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox tbxImpresora;
        private System.Windows.Forms.CheckBox chkImpPantalla;
        private System.Windows.Forms.NumericUpDown tbxCopias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxConexion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox tbxencript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnConn;
    }
}