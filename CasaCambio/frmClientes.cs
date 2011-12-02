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
    public partial class frmClientes : Form
    {
        private Cliente cliente;
        public int idcliente=0;
        public frmClientes()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Clientes";
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cliente = new Cliente();
            CargarCombos();
            if (idcliente != 0)
                cbxCliente.SelectedValue = idcliente;
        }

        void CargarCombos()
        {
            SicobDataSet.CatalogosDataTable dt;
            dt = CatalogosBLL.Clientes();
            dt.AddCatalogosRow("( Nuevo Cliente )");
            dt.DefaultView.Sort = "Descripcion ASC";
            cbxCliente.DisplayMember = "Descripcion";
            cbxCliente.ValueMember = "Id";
            cbxCliente.DataSource = dt.DefaultView;            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cliente!=null)
                cliente.Dispose();
            cliente = null;
            LimpiarFormulario();
            if ((int)cbxCliente.SelectedValue == -1)
            {
                cliente = new Cliente();
                return;
            }
            else
                cliente = ClientesBLL.ObtenerPorId((int)cbxCliente.SelectedValue);
            if (cliente == null)
            {
                MessageBox.Show("No se pudo obtener la información del cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else
                MostrarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            cliente.Datos.Nombres = tbxNombres.Text.Trim();
            cliente.Datos.Apellidos = tbxApellidos.Text.Trim();
            cliente.Datos.Direccion = tbxDir.Text.Trim();
            cliente.Datos.Telefonos=tbxTels.Text.Trim();
            cliente.Datos.Referencia1=tbxRef1.Text.Trim();
            cliente.Datos.Referencia2 = tbxRef2.Text.Trim();
            if (ClientesBLL.GuardarCliente(cliente))
            {
                CargarCombos();
                MessageBox.Show("Cliente Guardado", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool Validar()
        {
            if (cliente == null)
                return false;
            string err=string.Empty;
            if(tbxNombres.Text.Trim()==string.Empty)
                err+=" - Escriba el nombre\n";
                if(tbxApellidos.Text.Trim()==string.Empty)
                    err+=" - Escriba los apellidos\n";
            if(tbxDir.Text.Trim()==string.Empty)
                err+=" - Escriba la dirección\n";
            if (tbxTels.Text.Trim() == string.Empty)
                err += " - Escriba el teléfono";
            if (err != string.Empty)
            {
                MessageBox.Show(err, "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void MostrarDatos()
        {
            tbxNombres.Text = cliente.Datos.Nombres;
            tbxApellidos.Text = cliente.Datos.Apellidos;
            tbxDir.Text = cliente.Datos.Direccion;
            tbxTels.Text = cliente.Datos.Telefonos;
            tbxRef1.Text = cliente.Datos.Referencia1;
            tbxRef2.Text = cliente.Datos.Referencia2;
        }

        void LimpiarFormulario()
        {
            tbxNombres.Text = string.Empty;
            tbxApellidos.Text = string.Empty;
            tbxDir.Text = string.Empty;
            tbxTels.Text = string.Empty;
            string[] ln= new string[4];
            ln[0] = "Nombres:"; ln[1] = "Dirección:"; ln[2] = "Teléfonos"; ln[3] = "Parentesco";
            tbxRef1.Lines = ln;
            tbxRef2.Lines = ln;
        }
    }
}
