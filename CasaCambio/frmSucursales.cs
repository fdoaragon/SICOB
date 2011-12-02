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
    public partial class frmSucursales : Form
    {
        public frmSucursales()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Sucursales";
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            cbxSucursal.SelectedValueChanged += new EventHandler(cbxSucursal_SelectedValueChanged);
            cbxCajas.SelectedIndexChanged += new EventHandler(cbxCajas_SelectedIndexChanged);
            btnCajaG.Click += new EventHandler(btnCajaG_Click);
            btnCajaE.Click += new EventHandler(btnCajaE_Click);
            btnSucG.Click += new EventHandler(btnSucG_Click);
            btnSucE.Click += new EventHandler(btnSucE_Click);
            CargarSucursales();
        }

        void cbxCajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxCaja.Text = cbxCajas.Text;
        }

        void btnSucE_Click(object sender, EventArgs e)
        {
            int idsuc = (int)cbxSucursal.SelectedValue;
            if (idsuc != -1)
            {
                if (cbxCajas.Items.Count > 1)
                {
                    MessageBox.Show("No se puede eliminar la sucursal, tiene cajas ligadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(SucursalesBLL.Eliminar(idsuc))                    
                        MessageBox.Show("Sucursal eliminada");
                CargarSucursales();
            }
        }

        void btnSucG_Click(object sender, EventArgs e)
        {
            if (!ValidarSucursal())
                return;
            Sucursal suc;
            int idsuc = (int)cbxSucursal.SelectedValue;
            if (idsuc == -1)
                suc = new Sucursal();
            else
                suc = new Sucursal(idsuc);
            suc.Datos.Descripcion = tbxDescripcion.Text;
            suc.Datos.Cabecera = tbxCab.Text;
            suc.Datos.Direccion = tbxDireccion.Text;
            suc.Datos.Logo = tbxLogotipo.Text;
            suc.Datos.Pie = tbxPie.Text;
            suc.Datos.RazonSocial = tbxRazon.Text;
            suc.Datos.RFC = tbxRFC.Text;
            suc.Datos.TCCompra = tbxTCCompra.Value;
            suc.Datos.TCVenta = tbxTCVenta.Value;
            if (SucursalesBLL.Guardar(suc))
                MessageBox.Show("Datos Guardados");
            CargarSucursales();
        }

        void btnCajaE_Click(object sender, EventArgs e)
        {
            int idcaja = (int)cbxCajas.SelectedValue;
            if (idcaja != -1)
                CajasBLL.Eliminar(idcaja);
            CargarCajas();
        }

        void btnCajaG_Click(object sender, EventArgs e)
        {
            int idcaja = (int)cbxCajas.SelectedValue;
            int idsuc = (int)cbxSucursal.SelectedValue;
            if (idcaja == -1)
                CajasBLL.Insertar(idsuc, tbxCaja.Text);
            else
                CajasBLL.Actualizar(idcaja, tbxCaja.Text);
            CargarCajas();
        }

        void cbxSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            LimpiarFormulario();
            if (cbxSucursal.SelectedValue == null)
            {
                gbCajas.Enabled = false;
                return;
            }
            int idsuc =(int)cbxSucursal.SelectedValue;
            if (idsuc > 0)
            {
                Sucursal suc = new Sucursal(idsuc);
                tbxCab.Text = suc.Datos.Cabecera;
                tbxDireccion.Text = suc.Datos.Direccion;
                tbxLogotipo.Text = suc.Datos.Logo;
                tbxPie.Text = suc.Datos.Pie;
                tbxRazon.Text = suc.Datos.RazonSocial;
                tbxRFC.Text = suc.Datos.RFC;
                tbxTCCompra.Value = suc.Datos.TCCompra;
                tbxTCVenta.Value = suc.Datos.TCVenta;
                tbxDescripcion.Text = suc.Datos.Descripcion;
                CargarCajas();
                gbCajas.Enabled = true;
            }
            else
                gbCajas.Enabled = false;
            
            
        }

        bool ValidarSucursal()
        {
            if (tbxCab.Text.Trim() == string.Empty ||
                tbxCab.Text.Trim() == string.Empty ||
                this.tbxDireccion.Text.Trim() == string.Empty ||
                this.tbxLogotipo.Text.Trim() == string.Empty ||
                this.tbxPie.Text.Trim() == string.Empty ||
                this.tbxRazon.Text.Trim() == string.Empty ||
                this.tbxRFC.Text.Trim() == string.Empty ||
                this.tbxTCCompra.Value == 0 ||
                this.tbxTCVenta.Value == 0)
            {
                MessageBox.Show("No se permiten valores en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        void LimpiarFormulario()
        {
            tbxTCVenta.Value = 0;
            tbxTCCompra.Value = 0;
            tbxRFC.Text = string.Empty;
            tbxRazon.Text = string.Empty;
            tbxPie.Text = string.Empty;
            tbxLogotipo.Text = string.Empty;
            tbxDireccion.Text = string.Empty;
            tbxCab.Text = string.Empty;
            tbxDescripcion.Text = string.Empty;
        }

        void CargarSucursales()
        {
            cbxSucursal.DataSource = null; cbxSucursal.Items.Clear();
            cbxSucursal.ValueMember = "Id"; cbxSucursal.DisplayMember = "Descripcion";
            SicobDataSet.CatalogosDataTable dt;
            dt=BLL.CatalogosBLL.Sucursales();
            dt.AddCatalogosRow(" (Nueva sucursal) ");
            dt.DefaultView.Sort="Id asc";
            cbxSucursal.DataSource = dt.DefaultView;
            cbxSucursal.SelectedIndex = 0;
        }

        void CargarCajas()
        {
            cbxCajas.DataSource = null; cbxCajas.Items.Clear();
            cbxCajas.ValueMember = "IdCaja"; cbxCajas.DisplayMember = "Descripcion";
            SicobDataSet.CajasDataTable dt;
            int idsuc=(int)cbxSucursal.SelectedValue;
            dt = BLL.CajasBLL.ObtenerPorSucursal(idsuc);
            dt.AddCajasRow(-1, idsuc, " (Nueva Caja) ", 0, 0, "");
            dt.DefaultView.Sort = "IdCaja asc";
            cbxCajas.DataSource = dt.DefaultView;
            cbxCajas.SelectedIndex = 0;
        }

        

        

        


       

        
    }
}
