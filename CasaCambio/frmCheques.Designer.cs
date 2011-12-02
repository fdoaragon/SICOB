namespace CasaCambio
{
    partial class frmCheques
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCheques = new System.Windows.Forms.DataGridView();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFolioS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDatos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEndozo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIdEstatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheques)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(89, 6);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(240, 21);
            this.cbxTipo.TabIndex = 0;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.cbxTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ver Cheques:";
            // 
            // dgvCheques
            // 
            this.dgvCheques.AllowUserToAddRows = false;
            this.dgvCheques.AllowUserToDeleteRows = false;
            this.dgvCheques.AllowUserToResizeRows = false;
            this.dgvCheques.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmFecha,
            this.clmFolioS,
            this.clmCaja,
            this.clmDatos,
            this.clmEndozo,
            this.clmIdEstatus});
            this.dgvCheques.Location = new System.Drawing.Point(12, 33);
            this.dgvCheques.Name = "dgvCheques";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheques.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCheques.Size = new System.Drawing.Size(704, 341);
            this.dgvCheques.TabIndex = 2;
            this.dgvCheques.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheques_CellClick);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Image = global::CasaCambio.Properties.Resources.apply;
            this.btnCobrar.Location = new System.Drawing.Point(426, 380);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(144, 32);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Cobrar Cheque";
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::CasaCambio.Properties.Resources.cancel_24;
            this.btnCancelar.Location = new System.Drawing.Point(158, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(144, 32);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar Cheque";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // clmId
            // 
            this.clmId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmId.DataPropertyName = "IdChq";
            this.clmId.HeaderText = "IdChq";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            this.clmId.Width = 60;
            // 
            // clmFecha
            // 
            this.clmFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.clmFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmFecha.HeaderText = "Fecha";
            this.clmFecha.Name = "clmFecha";
            this.clmFecha.Width = 62;
            // 
            // clmFolioS
            // 
            this.clmFolioS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFolioS.DataPropertyName = "FolioSalida";
            dataGridViewCellStyle2.Format = "000000";
            dataGridViewCellStyle2.NullValue = null;
            this.clmFolioS.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmFolioS.HeaderText = "Folio Salida";
            this.clmFolioS.Name = "clmFolioS";
            this.clmFolioS.ReadOnly = true;
            this.clmFolioS.Width = 86;
            // 
            // clmCaja
            // 
            this.clmCaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCaja.DataPropertyName = "IdCaja";
            this.clmCaja.HeaderText = "Caja";
            this.clmCaja.Name = "clmCaja";
            this.clmCaja.ReadOnly = true;
            this.clmCaja.Width = 53;
            // 
            // clmDatos
            // 
            this.clmDatos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDatos.DataPropertyName = "DatosCheque";
            this.clmDatos.HeaderText = "Datos";
            this.clmDatos.Name = "clmDatos";
            this.clmDatos.ReadOnly = true;
            // 
            // clmEndozo
            // 
            this.clmEndozo.DataPropertyName = "Endozo";
            this.clmEndozo.HeaderText = "Endozo";
            this.clmEndozo.Name = "clmEndozo";
            this.clmEndozo.ReadOnly = true;
            // 
            // clmIdEstatus
            // 
            this.clmIdEstatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmIdEstatus.DataPropertyName = "IdEstatusChq";
            this.clmIdEstatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.clmIdEstatus.HeaderText = "Estatus";
            this.clmIdEstatus.Name = "clmIdEstatus";
            this.clmIdEstatus.Width = 48;
            // 
            // frmCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 424);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvCheques);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTipo);
            this.Name = "frmCheques";
            this.Text = "frmCheques";
            this.Load += new System.EventHandler(this.frmCheques_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCheques;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFolioS;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEndozo;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmIdEstatus;
    }
}