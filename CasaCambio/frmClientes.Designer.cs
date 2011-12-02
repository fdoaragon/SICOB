namespace CasaCambio
{
    partial class frmClientes
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
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.tbxNombres = new System.Windows.Forms.TextBox();
            this.tbxApellidos = new System.Windows.Forms.TextBox();
            this.tbxDir = new System.Windows.Forms.TextBox();
            this.tbxTels = new System.Windows.Forms.TextBox();
            this.tbxRef1 = new System.Windows.Forms.TextBox();
            this.tbxRef2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxCliente
            // 
            this.cbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(12, 12);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(373, 21);
            this.cbxCliente.TabIndex = 0;
            this.cbxCliente.SelectedIndexChanged += new System.EventHandler(this.cbxCliente_SelectedIndexChanged);
            // 
            // tbxNombres
            // 
            this.tbxNombres.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbxNombres.Location = new System.Drawing.Point(136, 39);
            this.tbxNombres.MaxLength = 100;
            this.tbxNombres.Name = "tbxNombres";
            this.tbxNombres.Size = new System.Drawing.Size(249, 20);
            this.tbxNombres.TabIndex = 1;
            // 
            // tbxApellidos
            // 
            this.tbxApellidos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbxApellidos.Location = new System.Drawing.Point(136, 65);
            this.tbxApellidos.MaxLength = 100;
            this.tbxApellidos.Name = "tbxApellidos";
            this.tbxApellidos.Size = new System.Drawing.Size(249, 20);
            this.tbxApellidos.TabIndex = 2;
            // 
            // tbxDir
            // 
            this.tbxDir.Location = new System.Drawing.Point(136, 91);
            this.tbxDir.MaxLength = 200;
            this.tbxDir.Multiline = true;
            this.tbxDir.Name = "tbxDir";
            this.tbxDir.Size = new System.Drawing.Size(249, 40);
            this.tbxDir.TabIndex = 3;
            // 
            // tbxTels
            // 
            this.tbxTels.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbxTels.Location = new System.Drawing.Point(136, 137);
            this.tbxTels.MaxLength = 100;
            this.tbxTels.Multiline = true;
            this.tbxTels.Name = "tbxTels";
            this.tbxTels.Size = new System.Drawing.Size(249, 40);
            this.tbxTels.TabIndex = 4;
            // 
            // tbxRef1
            // 
            this.tbxRef1.Location = new System.Drawing.Point(136, 183);
            this.tbxRef1.MaxLength = 500;
            this.tbxRef1.Multiline = true;
            this.tbxRef1.Name = "tbxRef1";
            this.tbxRef1.Size = new System.Drawing.Size(249, 60);
            this.tbxRef1.TabIndex = 5;
            this.tbxRef1.Text = "Nombre:\r\nDirección:\r\nTeléfonos:\r\nParentesco:";
            // 
            // tbxRef2
            // 
            this.tbxRef2.Location = new System.Drawing.Point(136, 249);
            this.tbxRef2.MaxLength = 500;
            this.tbxRef2.Multiline = true;
            this.tbxRef2.Name = "tbxRef2";
            this.tbxRef2.Size = new System.Drawing.Size(249, 60);
            this.tbxRef2.TabIndex = 6;
            this.tbxRef2.Text = "Nombre:\r\nDirección:\r\nTeléfonos:\r\nParentesco:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Apellidos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dirección";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Telefonos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Referencia 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Referencia 2";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(310, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 346);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxRef2);
            this.Controls.Add(this.tbxRef1);
            this.Controls.Add(this.tbxTels);
            this.Controls.Add(this.tbxDir);
            this.Controls.Add(this.tbxApellidos);
            this.Controls.Add(this.tbxNombres);
            this.Controls.Add(this.cbxCliente);
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.TextBox tbxNombres;
        private System.Windows.Forms.TextBox tbxApellidos;
        private System.Windows.Forms.TextBox tbxDir;
        private System.Windows.Forms.TextBox tbxTels;
        private System.Windows.Forms.TextBox tbxRef1;
        private System.Windows.Forms.TextBox tbxRef2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardar;
    }
}