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
    public partial class frmInventarios : Form
    {
        string Filtros = string.Empty;
        public frmInventarios()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Inventarios";
            this.dgvTransacciones.AutoGenerateColumns = false;
            dgvTransacciones.ReadOnly = true;
            dgvTransacciones.RowHeadersVisible = false;
            dgvTransacciones.AllowUserToAddRows = false;
            dgvTransacciones.AllowUserToDeleteRows = false;
            dgvTransacciones.AllowUserToResizeRows = false;
            foreach (DataGridViewColumn c in dgvTransacciones.Columns)
            {
                if (c.Name == "clmAbonoD" || c.Name == "clmAbonoP" || c.Name == "clmCargosD" || c.Name == "clmCargoP" || c.Name == "clmInvD" || c.Name == "clmInvP")
                {
                    c.Width = 80;
                    c.DefaultCellStyle.Format = "#0.00";
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }            
        }

        void CargarCombos()
        {
            cbxSucursal.DisplayMember = cbxCaja.DisplayMember = cbxTipos.DisplayMember = cbxUsuarios.DisplayMember = cbxCajas2.DisplayMember= cbxUCaja.DisplayMember=cbxUSucursal.DisplayMember= "Descripcion";
            cbxSucursal.ValueMember = cbxCaja.ValueMember = cbxTipos.ValueMember = cbxUsuarios.ValueMember = cbxCajas2.ValueMember= cbxUCaja.ValueMember=cbxUSucursal.ValueMember="Id";
            SicobDataSet.CatalogosDataTable dt = CatalogosBLL.Sucursales();
            dt.AddCatalogosRow("(Todos)");
            dt.DefaultView.Sort = "Id Asc";
            cbxSucursal.DataSource = dt.DefaultView;
            SicobDataSet.CatalogosDataTable dt2 = CatalogosBLL.Cajas();
            dt2.AddCatalogosRow("(Todos)");
            dt2.DefaultView.Sort = "Id Asc";
            cbxCaja.DataSource = dt2.DefaultView;
            SicobDataSet.CatalogosDataTable dt3 = CatalogosBLL.TiposTransaccion();
            dt3.AddCatalogosRow("(Todos)");
            dt3.DefaultView.Sort = "Id Asc";
            cbxTipos.DataSource = dt3.DefaultView;
            
            
            SicobDataSet.CatalogosDataTable dt4= CatalogosBLL.Cajas();
            dt2.DefaultView.Sort = "Id Asc";
            cbxCajas2.DataSource = dt4.DefaultView;
            cbxOperacion.Items.Add("Deposito");
            cbxOperacion.Items.Add("Retiro");
            cbxOperacion.SelectedIndex = 0;

            DataTable dtUSuc = dt.Copy();
            DataTable dtUCaja = dt2.Copy();
            dtUSuc.DefaultView.Sort = "Id Asc";
            dtUCaja.DefaultView.Sort = "Id Asc";
            cbxUSucursal.DataSource = dtUSuc.DefaultView;
            cbxUCaja.DataSource = dtUCaja.DefaultView;

            SicobDataSet.CatalogosDataTable dt5 = CatalogosBLL.TiposTransaccion();
            clmTipo.DisplayMember = "Descripcion";
            clmTipo.ValueMember = "Id";
            clmTipo.DataSource = dt5;

            SicobDataSet.UsuariosDataTable dt6 = UsuariosBLL.Obtener();
            cbxUsuarios.DisplayMember = "IdUsuario";// dt6[0].IdUsuario
            cbxUsuarios.ValueMember = "IdUsuario";
            dt6.AddUsuariosRow("(Todos)", "", "", 0, 0, "");
            dt6.DefaultView.Sort = "IdUsuario Asc";
            cbxUsuarios.DataSource = dt6.DefaultView;
            
        }

        private void frmInventarios_Load(object sender, EventArgs e)
        {
            CargarCombos();            
            cbxSucursal.SelectedIndexChanged += new EventHandler(Filtrers_Changed);
            cbxCaja.SelectedIndexChanged += new EventHandler(Filtrers_Changed);
            cbxTipos.SelectedIndexChanged += new EventHandler(Filtrers_Changed);
            cbxUsuarios.SelectedIndexChanged += new EventHandler(Filtrers_Changed);
            dtpFechaIni.ValueChanged += new EventHandler(Filtrers_Changed);
            dtpFechaFin.ValueChanged += new EventHandler(Filtrers_Changed);
            btnUActualizar.Click += new EventHandler(btnUActualizar_Click);
            cbxUSucursal.SelectedIndexChanged += new EventHandler(cbxUSucursal_SelectedIndexChanged);
            Filtrers_Changed(cbxSucursal, null);
            //dtpFechaFin.Value = DateTime.Today;
            //dtpFechaIni.Value = DateTime.Today;
            dtpUFechaIni.Value = DateTime.Today.Date.Subtract(new TimeSpan(DateTime.Today.Day - 1, 0, 0, 0));
            dtpUFechaFin.Value = DateTime.Now;
            btnUActualizar_Click(null, null);
            tbxUAjustes.ValueChanged += new EventHandler(tbxUAjustes_ValueChanged);
        }

        void tbxUAjustes_ValueChanged(object sender, EventArgs e)
        {
            string formato = "#0.00";
            double suma = 0;
            suma = double.Parse(tbxUPagosIntereses.Text);
            suma +=  double.Parse(tbxUAjustes.Value.ToString());
            this.tbxUtilidadPrestamos.Text = Math.Round(suma, 2).ToString(formato);
            suma += double.Parse(tbxUtilidadDolares.Text);
            suma += double.Parse(tbxUtilidadComisiones.Text);
            tbxUtilidad.Text = suma.ToString(formato);
            suma -= double.Parse(tbxGastos.Text);
            tbxUtilidadNeta.Text = suma.ToString(formato);
        }        

        void cbxUSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = (DataView)cbxUCaja.DataSource;
                if (cbxUSucursal.SelectedIndex <= 0)
                {
                    dv.RowFilter = string.Empty;
                    cbxUCaja.Enabled = false;
                }
                else
                {
                    cbxUCaja.Enabled = true;
                    dv.RowFilter = "Descripcion Like \'*S" + cbxUSucursal.SelectedValue.ToString() + "*\' or Descripcion like '*(Todos)*'";
                }
                cbxUCaja.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void btnUActualizar_Click(object sender, EventArgs e)
        {
            int? idsucursal = null, idcaja = null;
            idsucursal = (int)cbxUSucursal.SelectedValue;
            idcaja = (int)cbxUCaja.SelectedValue;
            if (idsucursal.Value < 0) idsucursal = null;
            if (idcaja.Value < 0) idcaja = null;
            SicobDataSet.UtilidadesDataTable dt = UtilidadesBLL.Resumen(dtpUFechaIni.Value.Date, dtpUFechaFin.Value.Date, idsucursal, idcaja);
            string formato="#00.00";
            foreach (SicobDataSet.UtilidadesRow r in dt.Rows)
            {
                tbxUtilidadDolares.Text = r.UtilidadDolares.ToString(formato);
                tbxUPagosIntereses.Text = r.PagosIntereses.ToString(formato);
                tbxUtilidadPrestamos.Text = r.PagosIntereses.ToString(formato);
                tbxUtilidadComisiones.Text = r.ComisionCheques.ToString(formato);
                tbxUtilidad.Text = r.UtilidadPorOperaciones.ToString(formato);
                tbxGastos.Text = r.GastosPeriodo.ToString(formato);
                tbxUtilidadNeta.Text = r.UtilidadNeta.ToString(formato);
            }
        }

        void Filtrers_Changed(object sender, EventArgs e)
        {
            Filtros = string.Empty;
            int? caja=null,tipo=null,idsucursal=null;
            string idusuario=null;
            if ( sender!=null && ((Control)sender).Name == "cbxSucursal")
            {
                try
                {
                    DataView dv = (DataView)cbxCaja.DataSource;
                    if (cbxSucursal.SelectedIndex <= 0)
                    {
                        dv.RowFilter = string.Empty;
                        cbxCaja.Enabled = false;
                    }
                    else
                    {
                        cbxCaja.Enabled = true;
                        dv.RowFilter = "Descripcion Like \'*S" + cbxSucursal.SelectedValue.ToString() + "*\' or Descripcion like '*(Todos)*'";
                    }
                    cbxCaja.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (cbxSucursal.SelectedIndex != 0)
            {
                idsucursal = (int)cbxSucursal.SelectedValue;
            }
            if ((int)cbxCaja.SelectedValue != -1)
            {
                Filtros += (Filtros == string.Empty ? "" : " and ") + "IdCaja=" + cbxCaja.SelectedValue.ToString();
                caja = (int)cbxCaja.SelectedValue;
            }
            if ((int)cbxTipos.SelectedValue != -1)
            {
                Filtros += (Filtros == string.Empty ? "" : " and ") + "IdCaja=" + cbxTipos.SelectedValue.ToString();
                tipo = (int)cbxTipos.SelectedValue;
            }
            if (cbxUsuarios.SelectedIndex != 0)
            {
                idusuario = cbxUsuarios.Text;
                //Filtros += (Filtros == string.Empty ? "" : " and ") + "IdUsuario=" + cbxUsuarios.SelectedValue.ToString();
            }
            Filtros += (Filtros == string.Empty ? "" : " and ") + "Fecha between " + dtpFechaIni.Text + " and " + dtpFechaFin.Text;            
            SicobDataSet.TransaccionesDataTable dt=TransaccionesBLL.Obtener(null, dtpFechaIni.Value, dtpFechaFin.Value, tipo, caja, idusuario, null,idsucursal);
            dt.DefaultView.Sort="Folio desc";
            dgvTransacciones.DataSource = dt.DefaultView;
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Filtrers_Changed(null, null);
        }

        private void btnTransaccion_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Esta a punto de efectuar una transacción\nDesea continuar?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;
            if (!ValidarCaja())
                return;
            int Folio = 0;
            if (cbxOperacion.SelectedIndex == 0)
                Folio = TransaccionesBLL.Insertar((int)TipoTransaccion.DepositoInventario,(int)this.cbxCajas2.SelectedValue, Globales.user.IdUsuario,0,tbxCantidad.Value,0,tbxCantidad2.Value,tbxObs.Text.Trim(),null,chkMarca.Checked);
            else
                Folio = TransaccionesBLL.Insertar((int)TipoTransaccion.RetiroInventario, (int)this.cbxCajas2.SelectedValue, Globales.user.IdUsuario, tbxCantidad.Value, 0, tbxCantidad2.Value, 0, tbxObs.Text.Trim(), null, chkMarca.Checked);
            if (Folio == 0)
                return;
            tbxCantidad.Value = 0;
            tbxCantidad2.Value = 0;
            tbxObs.Text = string.Empty;
            Filtrers_Changed(null, null);
            res = MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000")
                , "Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool ValidarCaja()
        {
            string err = string.Empty;
            if (this.tbxCantidad.Value == 0 && tbxCantidad2.Value==0)
                err += " - No se puede realizar una operación de $0.00\n";
            if (cbxOperacion.SelectedIndex == 1)
            {
                Caja caja = new Caja((int)cbxCajas2.SelectedValue);
                if (!caja.IsNull())
                {
                    if (tbxCantidad.Value > caja.Datos.InventarioPesos)
                        err += " - La caja no cuenta con la cantidad de pesos suficientes";
                    if (tbxCantidad2.Value > caja.Datos.InventarioDolares)
                        err += " - La caja no cuenta con la cantidad de dolares suficientes";
                    caja = null;
                }
                else
                    err += " - No se pudo obtener la información de la caja";
            }
            if (err != string.Empty)
            {
                MessageBox.Show(err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Caja caja = new Caja((int)cbxCaja.SelectedValue);
            string logo = string.Empty;
            if (!caja.IsNull())
                logo = Application.StartupPath + "\\Imagenes\\Logotipos\\" + caja.Sucursal.Datos.Logo;
            caja = null;
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load("Reportes\\Inventarios.rpt");
            rpt.SetDataSource(((DataView)dgvTransacciones.DataSource).Table);
            rpt.SetParameterValue("Sucursal", cbxSucursal.Text);
            rpt.SetParameterValue("Caja", cbxCaja.Text);
            rpt.SetParameterValue("Usuario", cbxUsuarios.Text);
            rpt.SetParameterValue("Tipo", cbxTipos.Text);
            rpt.SetParameterValue("FechaIni", dtpFechaIni.Text);
            rpt.SetParameterValue("FechaFin", dtpFechaFin.Text);
            rpt.SetParameterValue("Logo", logo);
            frmReporte frm = new frmReporte(rpt);
            frm.ShowDialog();
            rpt.Dispose();
            rpt = null;
            frm.Dispose();
            frm = null;
        }

        private void dgvTransacciones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if ((bool)dgvTransacciones["clmmarca", e.RowIndex].Value)
            {
                dgvTransacciones.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }
        
        

       

        
    }
}
