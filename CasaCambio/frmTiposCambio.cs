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
    public partial class frmTiposCambio : Form
    {
        public frmTiposCambio()
        {
            InitializeComponent();
        }

        private void frmTiposCambio_Load(object sender, EventArgs e)
        {
            btnActualizar_Click(null,null);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvTiposC.DataSource = TiposCambiosBLL.Obtener();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TiposCambiosBLL.Actualizar(dpFecha.Value, tbxVenta.Value, tbxCompra.Value);
            dgvTiposC.DataSource = TiposCambiosBLL.Obtener();
        }

        private void frmTiposCambio_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }
    }
}
