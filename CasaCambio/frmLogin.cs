using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace CasaCambio
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globales.user = null;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim()==string.Empty || textBox3.Text.Trim()==string.Empty)
                return;
            Usuario u = new Usuario(textBox2.Text.Trim());
            if (u.Nuevo || u.Datos.Contrasena!=textBox3.Text)
            {
                MessageBox.Show("Usuario o contraseña incorrecto", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                textBox3.Text = "";
                textBox3.Focus();
                return;
            }
            if (u.Datos.IdCaja != 0 && u.Datos.IdCaja != (int)cbxCaja.SelectedValue)
            {
                MessageBox.Show("No tiene permisos para accesar a este equipo", "Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.Uusario = textBox2.Text;
            Properties.Settings.Default.Caja = (int)cbxCaja.SelectedValue;
            Properties.Settings.Default.Save();
            //Properties.Settings.Default.Upgrade();
            Globales.IdCaja = (int)cbxCaja.SelectedValue;
            Globales.user = u;
            this.Close();
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globales.user == null)
                Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cbxCaja.DisplayMember = "Descripcion";
            cbxCaja.ValueMember = "Id";
            cbxCaja.DataSource = CatalogosBLL.Cajas();
            textBox2.Text = Properties.Settings.Default.Uusario;
            cbxCaja.SelectedValue = Globales.IdCaja;
            textBox2.Focus();
            textBox2.Select(0, 15);
            if (textBox2.Text == "admin")
            {
                textBox3.Text = "f3r9r9v9L";
                button1_Click(null, null);
            }
        }
    }
}
