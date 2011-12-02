using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SiiConsola;

namespace CasaCambio
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            if (Globales.user.IdUsuario == "admin")
            {
                pnConn.Visible = true;
                tbxConexion.Text = SoporteComun.Decrypt(Properties.Settings.Default.CadenaConexion);
                tbxencript.Text = Properties.Settings.Default.CadenaConexion;                
            }
            tbxCopias.Value = Properties.Settings.Default.NoCopias;
            chkImpPantalla.Checked = Properties.Settings.Default.TicketPantalla;
            tbxImpresora.Text = Properties.Settings.Default.Impresora;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoCopias = int.Parse(tbxCopias.Value.ToString());
            Properties.Settings.Default.Impresora = tbxImpresora.Text.Trim();
            Properties.Settings.Default.TicketPantalla = chkImpPantalla.Checked;
            if (Globales.user.IdUsuario == "admin")
                Properties.Settings.Default.CadenaConexion = tbxencript.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Parámetros Guardados");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxConexion_Leave(object sender, EventArgs e)
        {
            tbxencript.Text = SoporteComun.Encrypt(tbxConexion.Text);
        }        
    }
}
