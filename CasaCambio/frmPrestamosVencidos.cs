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
    public partial class frmPrestamosVencidos : Form
    {
        public frmPrestamosVencidos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Text = "Listado de Prestamos";
            this.dgvPres.AutoGenerateColumns = false;
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void frmPrestamosVencidos_Load(object sender, EventArgs e)
        {
            
            SicobDataSet.CatalogosDataTable dtEstatus = CatalogosBLL.EstatusPrestamo();
            dtEstatus.AddCatalogosRow("(Todos)");
            dtEstatus.AddCatalogosRow("Activos");
            dtEstatus.AddCatalogosRow("Inactivos");
            dtEstatus.DefaultView.Sort = "Descripcion ASC";
            cbxEstatus.DisplayMember= clmEstatusPrestamo.DisplayMember = "Descripcion";
            cbxEstatus.ValueMember= clmEstatusPrestamo.ValueMember = "Id";
            cbxEstatus.DataSource= clmEstatusPrestamo.DataSource = dtEstatus.DefaultView;

            SicobDataSet.CatalogosDataTable dtClientes = CatalogosBLL.Clientes();
            dtClientes.AddCatalogosRow("(Todos)");
            dtClientes.DefaultView.Sort = "Descripcion ASC";
            cbxClientes.DisplayMember= clmIdCliente.DisplayMember = "Descripcion";
            cbxClientes.ValueMember= clmIdCliente.ValueMember = "Id";
            cbxClientes.DataSource= clmIdCliente.DataSource = dtClientes.DefaultView;

            int anchofecha=80, anchocantidad=100, anchochico=50, anchomedio=70;
            clmIdPrestamo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; clmIdPrestamo.DefaultCellStyle.Format = "00000";
            clmIdCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clmFechaAlta.Width = anchofecha;
            clmCantidad.Width = anchocantidad; clmCantidad.DefaultCellStyle.Format = "c";
            clmCapitalPrestamo.Width = anchocantidad; clmCapitalPrestamo.DefaultCellStyle.Format = "c";
            clmDetalles.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clmdiaPago.Width = anchochico;
            clmEmpeño.Width = anchochico;
            clmEstatusPrestamo.Width = anchofecha;
            clmFechaCorte.Width = anchofecha;
            clmFechaLimite.Width = anchofecha;
            clmIntereses.Width = anchochico;
            clmMulta.Width = anchocantidad; clmMulta.DefaultCellStyle.Format = "c";
            clmPagoMinicmo.Width = anchocantidad; clmPagoMinicmo.DefaultCellStyle.Format = "c";
            clmPagosFijos.Width = anchochico;

            //dtpFecha.Value = DateTime.Today;
            cbxClientes.Text = "(Todos)";
            cbxEstatus.Text = "Activos";
            ActualizarGrid();
            //VerPrestamosVencidos();
        }

        private void ActualizarGrid()
        {
            string filtro = string.Empty;
            if (cbxClientes.Text != "(Todos)") filtro = "idcliente=" + cbxClientes.SelectedValue.ToString() + " and ";
            switch(cbxEstatus.Text)
            {
                case "Activos": filtro += "estatus not in (1,5,6) and "; break;
                case "Inactivos": filtro += "estatus in (1,5,6) and "; break;
                case "(Todos)": break;
                default: filtro += "estatus=" + cbxEstatus.SelectedValue.ToString() + " and "; break;
            }
            if (dtpFechaCorte.Checked)
                filtro += "fechacorte<=" + dtpFechaCorte.Value.ToString("yyyy-mm-dd") + " and "; 
            filtro += "1=1";
            SicobDataSet.PrestamosDataTable dt=PrestamosBLL.Obtener(null, null);
            dt.DefaultView.RowFilter = filtro;
            dt.DefaultView.Sort = "fechacorte desc";
            dgvPres.DataSource = dt.DefaultView;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvPres.SelectedRows == null) return;
            frmPrestamos frm = new frmPrestamos();
            frm.idprestamo = (int)dgvPres.SelectedRows[0].Cells[0].Value;
            frm.ShowDialog();
            ActualizarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmPrestamos frm = new frmPrestamos();            
            frm.ShowDialog();
        }        

        private void dgvPres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVer_Click(null, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvPres.SelectedRows == null) return;
            if (DialogResult.No ==
                MessageBox.Show("Desea cancelar el prestamo?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            Prestamo p= PrestamosBLL.ObtenerPorId((int)dgvPres.SelectedRows[0].Cells[0].Value);
            p.Datos.Estatus=(int)EstatusPrestamo.Cancelado;
            PrestamosBLL.Guardar(p);
            ActualizarGrid();
        }

        private void btnCortar_Click(object sender, EventArgs e)
        {
            if (dgvPres.SelectedRows == null) return;
            if (DialogResult.No ==
                MessageBox.Show("Desea realizar el corte al prestamo seleccionado?", "Corte", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            PrestamosBLL.Cortar((DateTime)dgvPres.SelectedRows[0].Cells["clmFechaCorte"].Value);
            ActualizarGrid();
        }

        private void dgvPres_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvPres.Rows)
            {
                if ((int)r.Cells["clmEstatusPrestamo"].Value == 4)
                    r.DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        
        
        
       
    }
}
