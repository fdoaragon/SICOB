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
    public partial class frmUsuarios : Form
    {
        SicobDataSet.UsuariosDataTable dtUsr;
        public frmUsuarios()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Usuarios";
            this.dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            foreach (DataGridViewColumn c in dgvUsuarios.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            } 
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            dtUsr=UsuariosBLL.Obtener();
            dgvUsuarios.DataSource = dtUsr;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (UsuariosBLL.Guardar(dtUsr))
            {
                MessageBox.Show("Los datos se guardaron correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error en los datos introducidos, verifique e intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;            
        }
    }
}
