using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAL;

namespace CasaCambio
{
    public partial class frmDiasFestivos : Form
    {
        private SicobDataSet.DiasFestivosDataTable dt;
        public frmDiasFestivos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Días Festivos";
            dgvDias.AllowUserToResizeRows = false;
            dgvDias.AllowUserToAddRows = false;
            dgvDias.AllowUserToDeleteRows = true;
            dgvDias.ReadOnly = true;
            dtpFecha.Value = DateTime.Today;
        }

        private void frmDiasFestivos_Load(object sender, EventArgs e)
        {
            dt = CatalogosBLL.DiasFestivos();
            dt.DefaultView.Sort = "Fecha DESC";
            this.dgvDias.DataSource = dt.DefaultView;
            dgvDias.Refresh();
        }

        private void dgvDias_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dt.FindByFecha(dtpFecha.Value.Date) != null)
                return;
            dt.AddDiasFestivosRow(dtpFecha.Value);
            CatalogosBLL.DiasFestivosGuardar(dt);
            dgvDias.Refresh();
        }

        private void dgvDias_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CatalogosBLL.DiasFestivosGuardar(dt);
            dgvDias.Refresh();
        }
    }
}
