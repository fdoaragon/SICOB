using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLL;

namespace CasaCambio
{
    public partial class frmCheques : Form
    {
        SicobDataSet.ChequesDataTable dtChq;
        int idchq=-1;
        public frmCheques()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Cheques";

            dgvCheques.AutoGenerateColumns = false;
            dgvCheques.AllowUserToAddRows = false;
            dgvCheques.ReadOnly = true;
            cbxTipo.ValueMember = "Id";
            cbxTipo.DisplayMember = "Descripcion";
            cbxTipo.DataSource = CatalogosBLL.EstatusCheque();

            this.clmIdEstatus.ValueMember = "Id";
            clmIdEstatus.DisplayMember = "Descripcion";
            clmIdEstatus.DataSource = CatalogosBLL.EstatusCheque();
        }

        private void frmCheques_Load(object sender, EventArgs e)
        {
            ObtenerCheques();
        }

        void ObtenerCheques()
        {
            EstatusCheque est;
            est = (EstatusCheque)cbxTipo.SelectedValue;
            dtChq = ChequesBLL.Obtener(est);
            dgvCheques.DataSource=null;
            dgvCheques.Refresh();
            dgvCheques.DataSource = dtChq;
            dgvCheques.Refresh();
        }

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerCheques();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idchq < 0) return;
            ChequesBLL.ActualizarEstatus(idchq, EstatusCheque.Cancelado);
            idchq = -1;
            MessageBox.Show("Cheque Cancelado");
            ObtenerCheques();
        }

        private void dgvCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0) return;
            idchq = (int)dgvCheques[0, e.RowIndex].Value;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (idchq < 0) return;
            ChequesBLL.ActualizarEstatus(idchq, EstatusCheque.Valido);
            idchq = -1;
            MessageBox.Show("Cheque Cobrado");
            ObtenerCheques();
        }

        
    }
}
