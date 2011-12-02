namespace CasaCambio
{
    partial class frmSucursales
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxSucursal = new System.Windows.Forms.ComboBox();
            this.gbTC = new System.Windows.Forms.GroupBox();
            this.tbxTCCompra = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTCVenta = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxPie = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxCab = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxLogotipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxRFC = new System.Windows.Forms.TextBox();
            this.tbxRazon = new System.Windows.Forms.TextBox();
            this.gbCajas = new System.Windows.Forms.GroupBox();
            this.btnCajaE = new System.Windows.Forms.Button();
            this.btnCajaG = new System.Windows.Forms.Button();
            this.cbxCajas = new System.Windows.Forms.ComboBox();
            this.btnSucE = new System.Windows.Forms.Button();
            this.btnSucG = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.tbxCaja = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTCCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTCVenta)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.gbCajas.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxSucursal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SUCURSAL";
            // 
            // cbxSucursal
            // 
            this.cbxSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSucursal.FormattingEnabled = true;
            this.cbxSucursal.Location = new System.Drawing.Point(6, 28);
            this.cbxSucursal.Name = "cbxSucursal";
            this.cbxSucursal.Size = new System.Drawing.Size(383, 21);
            this.cbxSucursal.TabIndex = 0;
            // 
            // gbTC
            // 
            this.gbTC.Controls.Add(this.tbxTCCompra);
            this.gbTC.Controls.Add(this.label2);
            this.gbTC.Controls.Add(this.tbxTCVenta);
            this.gbTC.Controls.Add(this.label1);
            this.gbTC.Location = new System.Drawing.Point(12, 73);
            this.gbTC.Name = "gbTC";
            this.gbTC.Size = new System.Drawing.Size(395, 60);
            this.gbTC.TabIndex = 1;
            this.gbTC.TabStop = false;
            this.gbTC.Text = "TIPO DE CAMBIO";
            // 
            // tbxTCCompra
            // 
            this.tbxTCCompra.DecimalPlaces = 2;
            this.tbxTCCompra.Location = new System.Drawing.Point(255, 19);
            this.tbxTCCompra.Name = "tbxTCCompra";
            this.tbxTCCompra.Size = new System.Drawing.Size(85, 20);
            this.tbxTCCompra.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Compra";
            // 
            // tbxTCVenta
            // 
            this.tbxTCVenta.DecimalPlaces = 2;
            this.tbxTCVenta.Location = new System.Drawing.Point(96, 19);
            this.tbxTCVenta.Name = "tbxTCVenta";
            this.tbxTCVenta.Size = new System.Drawing.Size(85, 20);
            this.tbxTCVenta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Razon Social";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.label9);
            this.gbDatos.Controls.Add(this.tbxDescripcion);
            this.gbDatos.Controls.Add(this.label8);
            this.gbDatos.Controls.Add(this.tbxPie);
            this.gbDatos.Controls.Add(this.label7);
            this.gbDatos.Controls.Add(this.tbxCab);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.tbxLogotipo);
            this.gbDatos.Controls.Add(this.label5);
            this.gbDatos.Controls.Add(this.tbxDireccion);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.tbxRFC);
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.tbxRazon);
            this.gbDatos.Location = new System.Drawing.Point(12, 139);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(395, 208);
            this.gbDatos.TabIndex = 2;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "DATOS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Pie Ticket";
            // 
            // tbxPie
            // 
            this.tbxPie.Location = new System.Drawing.Point(82, 149);
            this.tbxPie.Name = "tbxPie";
            this.tbxPie.Size = new System.Drawing.Size(307, 20);
            this.tbxPie.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cab. Ticket";
            // 
            // tbxCab
            // 
            this.tbxCab.Location = new System.Drawing.Point(82, 123);
            this.tbxCab.Name = "tbxCab";
            this.tbxCab.Size = new System.Drawing.Size(307, 20);
            this.tbxCab.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Logotipo";
            // 
            // tbxLogotipo
            // 
            this.tbxLogotipo.Location = new System.Drawing.Point(82, 97);
            this.tbxLogotipo.Name = "tbxLogotipo";
            this.tbxLogotipo.Size = new System.Drawing.Size(307, 20);
            this.tbxLogotipo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dirección";
            // 
            // tbxDireccion
            // 
            this.tbxDireccion.Location = new System.Drawing.Point(82, 71);
            this.tbxDireccion.Name = "tbxDireccion";
            this.tbxDireccion.Size = new System.Drawing.Size(307, 20);
            this.tbxDireccion.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "RFC";
            // 
            // tbxRFC
            // 
            this.tbxRFC.Location = new System.Drawing.Point(82, 45);
            this.tbxRFC.Name = "tbxRFC";
            this.tbxRFC.Size = new System.Drawing.Size(307, 20);
            this.tbxRFC.TabIndex = 5;
            // 
            // tbxRazon
            // 
            this.tbxRazon.Location = new System.Drawing.Point(82, 19);
            this.tbxRazon.Name = "tbxRazon";
            this.tbxRazon.Size = new System.Drawing.Size(307, 20);
            this.tbxRazon.TabIndex = 0;
            // 
            // gbCajas
            // 
            this.gbCajas.Controls.Add(this.tbxCaja);
            this.gbCajas.Controls.Add(this.btnCajaE);
            this.gbCajas.Controls.Add(this.btnCajaG);
            this.gbCajas.Controls.Add(this.cbxCajas);
            this.gbCajas.Location = new System.Drawing.Point(12, 353);
            this.gbCajas.Name = "gbCajas";
            this.gbCajas.Size = new System.Drawing.Size(395, 62);
            this.gbCajas.TabIndex = 3;
            this.gbCajas.TabStop = false;
            this.gbCajas.Text = "CAJAS";
            // 
            // btnCajaE
            // 
            this.btnCajaE.Image = global::CasaCambio.Properties.Resources.cancel_16;
            this.btnCajaE.Location = new System.Drawing.Point(357, 13);
            this.btnCajaE.Name = "btnCajaE";
            this.btnCajaE.Size = new System.Drawing.Size(32, 32);
            this.btnCajaE.TabIndex = 3;
            this.btnCajaE.UseVisualStyleBackColor = true;
            // 
            // btnCajaG
            // 
            this.btnCajaG.Image = global::CasaCambio.Properties.Resources.save_16;
            this.btnCajaG.Location = new System.Drawing.Point(319, 13);
            this.btnCajaG.Name = "btnCajaG";
            this.btnCajaG.Size = new System.Drawing.Size(32, 32);
            this.btnCajaG.TabIndex = 2;
            this.btnCajaG.UseVisualStyleBackColor = true;
            // 
            // cbxCajas
            // 
            this.cbxCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCajas.FormattingEnabled = true;
            this.cbxCajas.Location = new System.Drawing.Point(6, 19);
            this.cbxCajas.Name = "cbxCajas";
            this.cbxCajas.Size = new System.Drawing.Size(155, 21);
            this.cbxCajas.TabIndex = 1;
            // 
            // btnSucE
            // 
            this.btnSucE.Image = global::CasaCambio.Properties.Resources.cancel_24;
            this.btnSucE.Location = new System.Drawing.Point(226, 421);
            this.btnSucE.Name = "btnSucE";
            this.btnSucE.Size = new System.Drawing.Size(110, 44);
            this.btnSucE.TabIndex = 5;
            this.btnSucE.Text = "  Eliminar";
            this.btnSucE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSucE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSucE.UseVisualStyleBackColor = true;
            // 
            // btnSucG
            // 
            this.btnSucG.Image = global::CasaCambio.Properties.Resources.save_24;
            this.btnSucG.Location = new System.Drawing.Point(83, 421);
            this.btnSucG.Name = "btnSucG";
            this.btnSucG.Size = new System.Drawing.Size(110, 44);
            this.btnSucG.TabIndex = 4;
            this.btnSucG.Text = "  Guardar";
            this.btnSucG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSucG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSucG.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Descripción";
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Location = new System.Drawing.Point(82, 175);
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.Size = new System.Drawing.Size(307, 20);
            this.tbxDescripcion.TabIndex = 15;
            // 
            // tbxCaja
            // 
            this.tbxCaja.Location = new System.Drawing.Point(167, 19);
            this.tbxCaja.Name = "tbxCaja";
            this.tbxCaja.Size = new System.Drawing.Size(146, 20);
            this.tbxCaja.TabIndex = 4;
            // 
            // frmSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 474);
            this.Controls.Add(this.btnSucE);
            this.Controls.Add(this.btnSucG);
            this.Controls.Add(this.gbCajas);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbTC);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSucursales";
            this.Text = "frmSucursales";
            this.Load += new System.EventHandler(this.frmSucursales_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbTC.ResumeLayout(false);
            this.gbTC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTCCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxTCVenta)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbCajas.ResumeLayout(false);
            this.gbCajas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxSucursal;
        private System.Windows.Forms.GroupBox gbTC;
        private System.Windows.Forms.NumericUpDown tbxTCVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tbxTCCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxRazon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxRFC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxCab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxLogotipo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxPie;
        private System.Windows.Forms.GroupBox gbCajas;
        private System.Windows.Forms.ComboBox cbxCajas;
        private System.Windows.Forms.Button btnCajaE;
        private System.Windows.Forms.Button btnCajaG;
        private System.Windows.Forms.Button btnSucG;
        private System.Windows.Forms.Button btnSucE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.TextBox tbxCaja;
    }
}