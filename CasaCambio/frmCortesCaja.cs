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
    public partial class frmCortesCaja : Form
    {
        public frmCortesCaja()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Cortes de Caja";
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
            btnTransaccion.Enabled = false;

            dgvCheques.AutoGenerateColumns = false;
            dgvCheques.AllowUserToAddRows = false;
            dgvCheques.ReadOnly = true;
        }

        private void frmCortesCaja_Load(object sender, EventArgs e)
        {
            SicobDataSet.CatalogosDataTable dt5 = CatalogosBLL.TiposTransaccion();
            clmTipo.DisplayMember = "Descripcion";
            clmTipo.ValueMember = "Id";
            clmTipo.DataSource = dt5;
            if (Globales.user.Datos.IdSucursal != 0)
            {
                SicobDataSet.CajasDataTable dtcajas = CajasBLL.ObtenerPorSucursal(Globales.user.Datos.IdSucursal);
                dtcajas.AddCajasRow(-1, Globales.user.Datos.IdSucursal, " (Seleccione una caja) ", 0, 0, "");
                dtcajas.DefaultView.Sort = "IdCaja Asc";
                cbxCaja.DisplayMember = "Descripcion";
                cbxCaja.ValueMember = "IdCaja";
                cbxCaja.DataSource = dtcajas.DefaultView;                
            }
            else
            {
                SicobDataSet.CatalogosDataTable dt2 = CatalogosBLL.Cajas();
                dt2.AddCatalogosRow(" (Seleccione una caja) ");
                dt2.DefaultView.Sort = "Id Asc";
                cbxCaja.DisplayMember = "Descripcion";
                cbxCaja.ValueMember = "Id";
                cbxCaja.DataSource = dt2.DefaultView;
            }            
            cbxCaja.SelectedIndexChanged += new EventHandler(cbxCaja_SelectedIndexChanged);
            cbxCaja.SelectedIndex = 0;
            if (Globales.user.Datos.IdCaja != 0)
            {
                cbxCaja.SelectedValue = Globales.user.Datos.IdCaja.ToString();
                cbxCaja.Enabled = false;
            }
        }

        void cbxCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxDolares.Value = tbxPesos.Value = tbxCantidad.Value = tbxCantidad2.Value = 0;
            tbxObs.Text = string.Empty;
            btnTransaccion.Enabled = false;
            if ((int)cbxCaja.SelectedValue == -1)
                return;
            int idcaja =(int)cbxCaja.SelectedValue;
            SicobDataSet.TransaccionesDataTable dt=TransaccionesBLL.Corte(idcaja);
            dgvTransacciones.DataSource = dt;
            //if (dt.Rows.Count == 0)
            //{
            //    tbxCantidad.Value = tbxCantidad2.Value = tbxPesos.Value = tbxDolares.Value = 0;
            //    return;
            //}
            btnTransaccion.Enabled = true;
            Caja caja = new Caja(idcaja);
            tbxCantidad.Value = caja.Datos.InventarioPesos;
            tbxCantidad2.Value = caja.Datos.InventarioDolares;

            SicobDataSet.ChequesDataTable dtChq = ChequesBLL.Obtener(EstatusCheque.Pendiente,caja.IdCaja);
            dgvCheques.DataSource = dtChq;            
        }

        private void btnTransaccion_Click(object sender, EventArgs e)
        {
            decimal cargop = 0, abonop = 0, cargod = 0, abonod = 0;
            DialogResult res;
            res = MessageBox.Show("Esta a punto de efectuar una transacción\nDesea continuar?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            if (tbxCantidad.Value < tbxPesos.Value)
                abonop = tbxPesos.Value - tbxCantidad.Value;
            else
                cargop = tbxCantidad.Value - tbxPesos.Value;

            if (tbxCantidad2.Value < tbxDolares.Value)
                abonod = tbxDolares.Value - tbxCantidad2.Value;
            else
                cargod = tbxCantidad2.Value - tbxDolares.Value;

            int Folio = 0;
            Folio = TransaccionesBLL.Insertar((int)TipoTransaccion.Corte, (int)cbxCaja.SelectedValue, Globales.user.IdUsuario,cargop,abonop,cargod,abonod, tbxObs.Text.Trim(), null,0,0);
            if (Folio == 0)
                return;
            res = MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000")
                , "Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImprimir_Click(null, null);
            cbxCaja.SelectedIndex = 0;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Error al generar el reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Caja caja = new Caja((int)cbxCaja.SelectedValue);
            string logo = string.Empty;
            if (!caja.IsNull())
                logo = Application.StartupPath + "\\Imagenes\\Logotipos\\" + caja.Sucursal.Datos.Logo;
            caja = null;
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load("Reportes\\CorteCaja.rpt");
            rpt.Subreports[0].SetDataSource((DataTable)dgvCheques.DataSource);
            rpt.SetDataSource((DataTable)dgvTransacciones.DataSource);
            rpt.SetParameterValue("Caja", cbxCaja.Text);
            rpt.SetParameterValue("PesosR", tbxPesos.Value);
            rpt.SetParameterValue("PesosS", tbxCantidad.Value);
            rpt.SetParameterValue("DolaresR", tbxDolares.Value);
            rpt.SetParameterValue("DolaresS", tbxCantidad2.Value);
            rpt.SetParameterValue("PB1000",tbxPB1000.Text);
            rpt.SetParameterValue("PB500", tbxPB500.Text);
            rpt.SetParameterValue("PB200", tbxPB200.Text);
            rpt.SetParameterValue("PB100", tbxPB100.Text);
            rpt.SetParameterValue("PB50", tbxPB50.Text);
            rpt.SetParameterValue("PB20", tbxPB20.Text);
            rpt.SetParameterValue("PM100", tbxPM100.Text);
            rpt.SetParameterValue("PM20", tbxPM20.Text);
            rpt.SetParameterValue("PM10", tbxPM10.Text);
            rpt.SetParameterValue("PM5", tbxPM5.Text);
            rpt.SetParameterValue("PM2", tbxPM2.Text);
            rpt.SetParameterValue("PM1", tbxPM1.Text);
            rpt.SetParameterValue("PM50C", tbxPC50.Text);
            rpt.SetParameterValue("PM20C", tbxPC20.Text);
            rpt.SetParameterValue("PM10C", tbxPC10.Text);
            rpt.SetParameterValue("PM5C", tbxPC5.Text);

            rpt.SetParameterValue("DB100", tbxDB100.Text);
            rpt.SetParameterValue("DB50", tbxDB50.Text);
            rpt.SetParameterValue("DB20", tbxDB20.Text);
            rpt.SetParameterValue("DB10", tbxDB10.Text);
            rpt.SetParameterValue("DB5", tbxDB5.Text);
            rpt.SetParameterValue("DB1", tbxDB1.Text);
            rpt.SetParameterValue("DM1", tbxDM1.Text);
            rpt.SetParameterValue("DM50", tbxDC50.Text);
            rpt.SetParameterValue("DM25", tbxDC25.Text);
            rpt.SetParameterValue("DM10", tbxDC10.Text);
            rpt.SetParameterValue("DM5", tbxDC5.Text);
            rpt.SetParameterValue("DM1C", tbxDC1.Text);

            rpt.SetParameterValue("Logo", logo);

            
            frmReporte frm = new frmReporte(rpt);
            frm.ShowDialog();
            rpt.Dispose();
            rpt = null;
            frm.Dispose();
            frm = null;
        }

        private void tbxPC5_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            int valor;
            if (int.TryParse(tbx.Text, out valor))
            {
                SumarPesos();
            }
            else
            {
                tbx.Text = "0";
            }
        }

        void SumarPesos()
        {
            decimal suma = 0;
            decimal d; 
            int valor;
            int.TryParse(tbxPB1000.Text,out valor);
            suma += valor * 1000;
            int.TryParse(tbxPB500.Text, out valor);
            suma += valor * 500;
            int.TryParse(tbxPB200.Text, out valor);
            suma += valor * 200;
            int.TryParse(tbxPB100.Text, out valor);
            suma += valor * 100;
            int.TryParse(tbxPB50.Text, out valor);
            suma += valor * 50;
            int.TryParse(tbxPB20.Text, out valor);
            suma += valor * 20;
            int.TryParse(tbxPM100.Text, out valor);
            suma += valor * 100;
            int.TryParse(tbxPM20.Text, out valor);
            suma += valor * 20;
            int.TryParse(tbxPM10.Text, out valor);
            suma += valor * 10;
            int.TryParse(tbxPM5.Text, out valor);
            suma += valor * 5;
            int.TryParse(tbxPM2.Text, out valor);
            suma += valor * 2;
            int.TryParse(tbxPM1.Text, out valor);
            suma += valor;
            int.TryParse(tbxPC50.Text, out valor);
            d = new decimal(0.5);
            suma += Decimal.Multiply(valor,d);
            int.TryParse(tbxPC20.Text, out valor);
            d = new decimal(0.2);
            suma += Decimal.Multiply(valor, d);
            int.TryParse(tbxPC10.Text, out valor);
            d = new decimal(0.1);
            suma += Decimal.Multiply(valor, d);
            int.TryParse(tbxPC5.Text, out valor);
            d = new decimal(0.05);
            suma += Decimal.Multiply(valor, d);
            tbxPesos.Value = suma;
        }

        private void tbxDC1_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            int valor;
            if (int.TryParse(tbx.Text, out valor))
            {
                SumarDolares();
            }
            else
            {
                tbx.Text = "0";
            }
        }

        void SumarDolares()
        {
            decimal suma = 0;
            decimal d;
            int valor;
            int.TryParse(tbxDB100.Text, out valor);
            suma += valor * 100;
            int.TryParse(tbxDB50.Text, out valor);
            suma += valor * 50;
            int.TryParse(tbxDB20.Text, out valor);
            suma += valor * 20;
            int.TryParse(tbxDB10.Text, out valor);
            suma += valor * 10;
            int.TryParse(tbxDB5.Text, out valor);
            suma += valor * 5;
            int.TryParse(tbxDB1.Text, out valor);
            suma += valor * 1;
            int.TryParse(tbxDM1.Text, out valor);
            suma += valor;
            int.TryParse(tbxDC50.Text, out valor);
            d = new decimal(0.5);
            suma += Decimal.Multiply(valor, d);
            int.TryParse(tbxDC25.Text, out valor);
            d = new decimal(0.25);
            suma += Decimal.Multiply(valor, d);
            int.TryParse(tbxDC10.Text, out valor);
            d = new decimal(0.1);
            suma += Decimal.Multiply(valor, d);
            int.TryParse(tbxDC5.Text, out valor);
            d = new decimal(0.05);
            suma += Decimal.Multiply(valor, d);
            int.TryParse(tbxDC1.Text, out valor);
            d = new decimal(0.01);
            suma += Decimal.Multiply(valor, d);
            tbxDolares.Value = suma;
        }
    }
}
