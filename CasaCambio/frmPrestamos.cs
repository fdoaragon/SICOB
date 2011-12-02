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
using LlenarDocumentos;
using System.IO;

namespace CasaCambio
{
    public partial class frmPrestamos : Form
    {
        Prestamo prestamo;
        Cliente cliente;
        public int idprestamo = 0;
        public frmPrestamos()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.Text = "Prestamos";
            //cbxEstatus.Enabled = false;
            tbxCapital.Enabled = false;
            tbxPago.Enabled = false;
            dgvPrestamos.AutoGenerateColumns = false;
            foreach (DataGridViewColumn c in dgvPrestamos.Columns)
            {
                if (c.Name == "clmCapital" || c.Name == "clmCapitalA" || c.Name == "clmInteres" || c.Name == "clmMulta" || c.Name == "clmPago")
                {
                    //c.Width = 80;
                    c.DefaultCellStyle.Format = "c";
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                //else
                //    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvPrestamos.Font = new Font(dgvPrestamos.Font.FontFamily.Name, 10);
            dgvPlazos.Font = new Font(dgvPrestamos.Font.FontFamily.Name, 10);
            
        }

        private void frmPrestamos_Load(object sender, EventArgs e)
        {
            prestamo= new Prestamo();
            CargarCombos();
            if (idprestamo != 0)
                cbxPrestamo.SelectedValue = idprestamo;
            cbxPrestamo.Enabled = false;
            if (Globales.user.Datos.IdSucursal != 0)
            {
                btnGuardar.Enabled = false;
                btnDescuento.Enabled = false;
                btnEntregar.Enabled = false;
                cbxPrestamo.Enabled = false;
            }
        }

        void CargarCombos()
        {
            SicobDataSet.CatalogosDataTable dt2 = CatalogosBLL.Clientes();
            dt2.AddCatalogosRow("( Seleccione un cliente )");
            dt2.DefaultView.Sort = "Descripcion ASC";
            cbxCliente.DisplayMember = "Descripcion";
            cbxCliente.ValueMember = "Id";
            cbxCliente.DataSource = dt2.DefaultView;

            SicobDataSet.CatalogosDataTable dt3 = CatalogosBLL.EstatusPrestamo();
            cbxEstatus.DisplayMember = "Descripcion";
            cbxEstatus.ValueMember = "Id";
            cbxEstatus.DataSource = dt3.DefaultView;

            SicobDataSet.CatalogosDataTable dt4 = CatalogosBLL.TiposMovimiento();
            clmTipo.DataSource = dt4;
            clmTipo.DisplayMember = "Descripcion";
            clmTipo.ValueMember = "Id";

            CargarPrestamos(false);
        }

        void CargarPrestamos(bool masreciente)
        {
            SicobDataSet.CatalogosDataTable dt;
            dt = CatalogosBLL.Prestamos();
            dt.AddCatalogosRow("( Nuevo Prestamo )");
            if(!masreciente)
                dt.DefaultView.Sort = "Descripcion ASC";
            else
                dt.DefaultView.Sort = "Id DESC";
            cbxPrestamo.DisplayMember = "Descripcion";
            cbxPrestamo.ValueMember = "Id";            
            cbxPrestamo.DataSource = dt.DefaultView;
            if (masreciente)
            {
                cbxPrestamo.SelectedIndex = 0;
                cbxPrestamo_SelectedIndexChanged(null, null);
            }
        }

        bool Validar()
        {
            if (prestamo == null)
                return false;
            if ((int)cbxCliente.SelectedValue == -1)
            {
                MessageBox.Show("Debe elegir a un cliente");
                return false;
            }
            return true;
        }

        void MostrarDatos()
        {
            tbxCantidad.Value = prestamo.Datos.Cantidad;
            tbxDia.Value = prestamo.Datos.DiaPago;
            tbxInteres.Value = prestamo.Datos.Interes;
            tbxMulta.Value = prestamo.Datos.Multa;
            cbxCliente.SelectedValue = prestamo.Datos.IdCliente;
            cbxEstatus.SelectedValue = prestamo.Datos.Estatus;
            dtpFecha.Value = prestamo.Datos.FechaPago;
            tbxCapital.Value = prestamo.Datos.Capital;
            tbxPago.Value = prestamo.Datos.PagoMinimo;
            if (!prestamo.Datos.IsPagosFijosNull())
                chkPagosF.Checked = prestamo.Datos.PagosFijos;
            if (!prestamo.Datos.IsFechaLimiteNull())
                dtpFechaLimite1.Value = prestamo.Datos.FechaLimite;
            if (!prestamo.Datos.IsEmpenoNull())
                chkempeno.Checked = prestamo.Datos.Empeno;
            if (!prestamo.Datos.IsDetallesEmpenoNull())
                tbxDetalles.Text = prestamo.Datos.DetallesEmpeno;
            dgvPrestamos.DataSource = prestamo.Movimientos;
            dgvPrestamos.Refresh();
            BloquearCampos();
        }

        void BloquearCampos()
        {
            tbxCantidad.Enabled = true;
            tbxDia.Enabled = true;
            tbxInteres.Enabled = true;
            tbxMulta.Enabled = true;
            cbxCliente.Enabled = true;
            btnGuardar.Enabled = true;
            btnEntregar.Visible = true;
            dtpFecha.Enabled = true;
           if(prestamo.Datos.Estatus == (int)EstatusPrestamo.Cancelado
               || prestamo.Datos.Estatus == (int)EstatusPrestamo.Terminado)
           {
                    tbxDia.Enabled = false;
                    tbxInteres.Enabled = false;
                    tbxMulta.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnEntregar.Visible = false;
                    dtpFecha.Enabled = false;
                    cbxCliente.Enabled = false;
           }
           if (prestamo.Datos.Estatus == (int)EstatusPrestamo.Curso
               || prestamo.Datos.Estatus == (int)EstatusPrestamo.Vencido
               || prestamo.Datos.Estatus == (int)EstatusPrestamo.Pagado)
           {
               tbxCantidad.Enabled = false;
               //cbxCliente.Enabled = false;
               btnEntregar.Visible = false;               
           }

        }

        void LimpiarFormulario()
        {
            tbxCantidad.Value = 1;
            tbxDia.Value = 1;
            tbxInteres.Value = 1;
            tbxMulta.Value = 1;
            cbxCliente.SelectedIndex = -1;
            chkempeno.Checked = chkPagosF.Checked = false;
            tbxDetalles.Text = string.Empty;
            dtpFechaLimite1.Value = DateTime.Today;
            tbxDescuento.Value = 0;
            tbxObs.Text = string.Empty;
            dgvPrestamos.DataSource = null;
            dgvPrestamos.Refresh();
        }

        private void cbxPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prestamo != null)
                prestamo.Dispose();
            prestamo = null;
            LimpiarFormulario();
            int idprestamo = (int)cbxPrestamo.SelectedValue;
            if (idprestamo == -1)
                prestamo = new Prestamo();
            else
                prestamo = PrestamosBLL.ObtenerPorId(idprestamo);
            if (prestamo == null)
            {
                MessageBox.Show("No se pudo obtener la información del prestamo", "Prestamo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MostrarDatos();           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            prestamo.Datos.Cantidad = tbxCantidad.Value;
            prestamo.Datos.DiaPago = int.Parse(tbxDia.Value.ToString());
            prestamo.Datos.Estatus = (int)cbxEstatus.SelectedValue;
            prestamo.Datos.IdCliente = (int)cbxCliente.SelectedValue;
            prestamo.Datos.Interes = int.Parse(tbxInteres.Value.ToString());
            prestamo.Datos.Multa = tbxMulta.Value;
            prestamo.Datos.FechaPago = dtpFecha.Value;
            prestamo.Datos.FechaCorte = dtpFecha.Value;
            prestamo.Datos.Empeno = chkempeno.Checked;            
            prestamo.Datos.PagosFijos = chkPagosF.Checked;
            prestamo.Datos.DetallesEmpeno = tbxDetalles.Text;
            if (!chkPagosF.Checked)
                prestamo.Datos.SetFechaLimiteNull();
            else
                prestamo.Datos.FechaLimite = dtpFechaLimite1.Value.Date;

            if (PrestamosBLL.Guardar(prestamo))
            {
                if (cbxPrestamo.Text == "( Nuevo Prestamo )")
                {
                    CargarPrestamos(true);                    
                }
                else
                    cbxPrestamo_SelectedIndexChanged(null, null);
                MessageBox.Show("Prestamo Guardado", "Prestamo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (prestamo == null)
                return;
            if (prestamo.Datos.IdPrestamo < 1)
            {
                MessageBox.Show("Tiene que guardar primero");
                return;
            }
            if (!ValidarCaja())
                return;
            res = MessageBox.Show("Desea entregar el dinero del préstamo al cliente?", "Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;
            int Folio = PrestamosBLL.EntregarPrestamo(prestamo.Datos.IdPrestamo, prestamo.Datos.Cantidad, prestamo.Datos.Interes, Globales.IdCaja, Globales.user.IdUsuario, null);
            if (Folio == 0)
                return;
            cbxPrestamo_SelectedIndexChanged(null, null);
            res = MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000")
                ,"Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool ValidarCaja()
        {
            string err = string.Empty;
            if (this.tbxCantidad.Value == 0)
                err += " - No se puede realizar una operación de $0.00\n";
            Caja caja = new Caja(Globales.IdCaja);
            if (!caja.IsNull())
            {
                if (tbxCantidad.Value > caja.Datos.InventarioPesos)
                    err += " - La caja no cuenta con la cantidad de pesos suficientes";                
                caja = null;
            }
            else
                err += " - No se pudo obtener la información de la caja";
            if (err != string.Empty)
            {
                MessageBox.Show(err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void dgvMovimientos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Caja caja = new Caja(Globales.IdCaja);
            string logo=string.Empty;
            if (!caja.IsNull())
                logo = Application.StartupPath + "\\Imagenes\\Logotipos\\" + caja.Sucursal.Datos.Logo;
            caja = null;
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load("Reportes\\Historial.rpt");
            rpt.SetDataSource((DataTable)this.dgvPrestamos.DataSource);
            rpt.SetParameterValue("NoPrestamo", cbxPrestamo.SelectedValue.ToString());
            rpt.SetParameterValue("Cliente", cbxCliente.Text);
            rpt.SetParameterValue("Capital", tbxCapital.Value);
            rpt.SetParameterValue("PagoMinimo", tbxPago.Value);
            rpt.SetParameterValue("FechaCorte", dtpFecha.Value);
            rpt.SetParameterValue("Estatus", cbxEstatus.Text);
            rpt.SetParameterValue("Logo", logo);
            frmReporte frm = new frmReporte(rpt);
            frm.ShowDialog();
            rpt.Dispose();
            rpt = null;
            frm.Dispose();
            frm = null;
        }        

        private void btnVerCliente_Click(object sender, EventArgs e)
        {
            if ((int)cbxCliente.SelectedValue == -1)
                return;
            frmClientes frm = new frmClientes();
            frm.idcliente = (int)cbxCliente.SelectedValue;
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Aplicar Descuento?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;
            decimal pago=0,multa=0;
            if(tbxDescuento.Value>0)
                pago=tbxDescuento.Value;
            else
                multa=tbxDescuento.Value * -1;
            PrestamosBLL.AplicarAjuste(prestamo, pago, multa, tbxObs.Text);
            cbxPrestamo_SelectedIndexChanged(null, null);
        }

        private void cbxEstatus_Enter(object sender, EventArgs e)
        {
            cbxPrestamo.Focus();
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> valores = new Dictionary<string, string>();
            string reporte = Application.StartupPath + "\\Reportes\\";
            if (cbxDocumento.SelectedIndex == 0)
            {
                valores.Add("<cliente>", tbxDoc1.Text);
                valores.Add("<fechaactual>", tbxDoc2.Text);
                valores.Add("<cantidad>", tbxDoc3.Text);
                valores.Add("<cantidadletra>", tbxDoc4.Text);
                valores.Add("<domicilio>", tbxDoc5.Text);
                valores.Add("<fechalimite>", tbxDoc6.Text);                
                valores.Add("<interes>", tbxDoc7.Text);                
                valores.Add("<poblacion>", tbxDoc8.Text);
                reporte += "pagare.docx";
                string documento=Application.StartupPath + "\\Documentos de Prestamos\\" + tbxDoc1.Text.ToUpper() + "_" + prestamo.Datos.IdPrestamo.ToString() + "_PAGARE.docx";
                if (LLenarDocumentos.LLenarDocumentoWord(reporte, documento, valores))
                {
                    System.Diagnostics.Process.Start(documento);
                }
            }
            if (cbxDocumento.SelectedIndex == 1)
            {
                valores.Add("<cliente>", tbxDoc1.Text);
                DateTime fecha;
                if(!DateTime.TryParse(tbxDoc2.Text,out fecha)) fecha=DateTime.Today;                    
                valores.Add("<dia>", fecha.Day.ToString());
                valores.Add("<mes>", fecha.ToString("MMMM").ToUpper());
                valores.Add("<anno>", fecha.Year.ToString());
                valores.Add("<cantidad>", tbxDoc3.Text);
                valores.Add("<cantidadletra>", tbxDoc4.Text);
                valores.Add("<domicilio>", tbxDoc5.Text);
                valores.Add("<marca>", tbxDoc6.Text);
                valores.Add("<tipo>", tbxDoc7.Text);
                valores.Add("<modelo>", tbxDoc8.Text);
                valores.Add("<color>", tbxDoc9.Text);
                valores.Add("<motor>", tbxDoc10.Text);
                valores.Add("<serie>", tbxDoc11.Text);
                valores.Add("<tenencia>", tbxDoc12.Text);
                reporte += "compraventavehiculo.docx";
                string documento = Application.StartupPath + "\\Documentos de Prestamos\\" + tbxDoc1.Text.ToUpper() + "_" + prestamo.Datos.IdPrestamo.ToString() + "_COMPRAVENTAVEHICULO.docx";
                if (LLenarDocumentos.LLenarDocumentoWord(reporte, documento, valores))
                {
                    System.Diagnostics.Process.Start(documento);
                }
            }
            if (cbxDocumento.SelectedIndex == 2)
            {
                valores.Add("<cliente>", tbxDoc1.Text);
                DateTime fecha;
                if (!DateTime.TryParse(tbxDoc2.Text, out fecha)) fecha = DateTime.Today;
                valores.Add("<dia>", fecha.Day.ToString());
                valores.Add("<mes>", fecha.ToString("MMMM"));
                valores.Add("<anno>", fecha.Year.ToString());
                valores.Add("<cantidad>", tbxDoc3.Text);
                valores.Add("<cantidadletra>", tbxDoc4.Text);
                valores.Add("<domicilio>", tbxDoc5.Text);
                valores.Add("<plazo2>", tbxDoc6.Text);
                valores.Add("<interes>", tbxDoc7.Text);
                valores.Add("<ocupacion>", tbxDoc8.Text);
                valores.Add("<fecnac>", tbxDoc9.Text);
                valores.Add("<ciudad>", tbxDoc10.Text);
                valores.Add("<inmueble>", tbxDoc15.Text);
                valores.Add("<norte>", tbxDoc16.Text);
                valores.Add("<sur>", tbxDoc17.Text);
                valores.Add("<este>", tbxDoc18.Text);
                valores.Add("<oeste>", tbxDoc19.Text);
                valores.Add("<plazo>", dgvPlazos.Rows.Count.ToString());
                for (int i = 0; i < dgvPlazos.Rows.Count; i++)
                {
                    DateTime fecha1;
                    if (!DateTime.TryParse(dgvPlazos.Rows[i].Cells[1].Value.ToString(), out fecha1)) fecha1 = DateTime.Today;
                    valores.Add("<dia" + (i+1).ToString() + ">", fecha1.Day.ToString());
                    valores.Add("<mes" + (i + 1).ToString() + ">", fecha1.ToString("MMMM"));
                    valores.Add("<anno" + (i + 1).ToString() + ">", fecha1.Year.ToString());
                    valores.Add("<cantidad" + (i + 1).ToString() + ">", dgvPlazos.Rows[i].Cells[2].Value.ToString());
                    valores.Add("<cantidadletra" + (i + 1).ToString() + ">", dgvPlazos.Rows[i].Cells[3].Value.ToString());
                }
                reporte += "reconocimientoadeudo.docx";
                string documento = Application.StartupPath + "\\Documentos de Prestamos\\" + tbxDoc1.Text.ToUpper() + "_" + prestamo.Datos.IdPrestamo.ToString() + "_RECONOCIMIENTOADEUDO.docx";
                if (LLenarDocumentos.LLenarDocumentoWord(reporte, documento, valores))
                {
                    System.Diagnostics.Process.Start(documento);
                }
            }
        }

        private void cbxDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDoc1.Text = lblDoc2.Text = lblDoc3.Text = lblDoc4.Text = lblDoc5.Text = lblDoc6.Text = lblDoc7.Text = ".";
            lblDoc8.Text = lblDoc9.Text = lblDoc10.Text = lblDoc11.Text = lblDoc12.Text  = ".";
            lblDoc13.Text = lblDoc14.Text = lblDoc15.Text = lblDoc16.Text = lblDoc17.Text = lblDoc18.Text = lblDoc19.Text = ".";
            tbxDoc1.Text = tbxDoc2.Text = tbxDoc3.Text = tbxDoc4.Text = tbxDoc5.Text = tbxDoc6.Text = tbxDoc7.Text = string.Empty;
            tbxDoc8.Text = tbxDoc9.Text = tbxDoc10.Text = tbxDoc11.Text = tbxDoc12.Text = string.Empty;
            tbxDoc13.Text = tbxDoc14.Text = tbxDoc15.Text = tbxDoc16.Text = tbxDoc17.Text = tbxDoc18.Text = tbxDoc19.Text = string.Empty;
            if (cbxDocumento.SelectedIndex == 0)
            {
                lblDoc1.Text = "Cliente"; tbxDoc1.Text = (cliente != null ? cliente.Datos.Nombres.ToUpper() + " " + cliente.Datos.Apellidos.ToUpper() : "");
                lblDoc2.Text = "Fecha"; tbxDoc2.Text = DateTime.Today.Date.Date.ToLongDateString();
                lblDoc3.Text = "Cantidad"; tbxDoc3.Text = tbxCapital.Value.ToString("#,###.00");
                lblDoc4.Text = "Cantidad letra";
                lblDoc5.Text = "Domicilio"; tbxDoc5.Text = (cliente != null ? cliente.Datos.Direccion.ToUpper() : "");
                lblDoc6.Text = "Fecha de Págo"; tbxDoc6.Text = (chkPagosF.Checked ? dtpFechaLimite1.Value.Date.ToLongDateString().ToUpper() :
                    dtpFecha.Value.Date.ToLongDateString());
                lblDoc7.Text = "Interes"; tbxDoc7.Text = tbxInteres.Value.ToString();                
                lblDoc8.Text = "Población";
                
            }

            if (cbxDocumento.SelectedIndex == 1)
            {
                lblDoc1.Text = "Cliente"; tbxDoc1.Text = (cliente != null ? cliente.Datos.Nombres.ToUpper() + " " + cliente.Datos.Apellidos.ToUpper() : "");
                lblDoc2.Text = "Fecha"; tbxDoc2.Text = DateTime.Today.Date.Date.ToShortDateString();
                lblDoc3.Text = "Cantidad"; tbxDoc3.Text = tbxCapital.Value.ToString("#,###.00");
                lblDoc4.Text = "Cantidad letra";
                lblDoc5.Text = "Domicilio"; tbxDoc5.Text = (cliente != null ? cliente.Datos.Direccion.ToUpper() : "");
                lblDoc6.Text = "Marca";
                lblDoc7.Text = "Tipo";
                lblDoc8.Text = "Modelo";
                lblDoc9.Text = "Color";
                lblDoc10.Text = "Motor";
                lblDoc11.Text = "Serie";
                lblDoc12.Text = "Año tenencia";
            }
            if (cbxDocumento.SelectedIndex == 2)
            {
                lblDoc1.Text = "Cliente"; tbxDoc1.Text = (cliente != null ? cliente.Datos.Nombres + " " + cliente.Datos.Apellidos : "");
                lblDoc2.Text = "Fecha"; tbxDoc2.Text = DateTime.Today.Date.Date.ToShortDateString();
                lblDoc3.Text = "Cantidad"; tbxDoc3.Text = tbxCapital.Value.ToString("#,###.00");
                lblDoc4.Text = "Cantidad letra";
                lblDoc5.Text = "Domicilio"; tbxDoc5.Text = (cliente != null ? cliente.Datos.Direccion : "");
                lblDoc6.Text = "Plazos letra";
                lblDoc7.Text = "Interes"; tbxDoc7.Text = tbxInteres.Value.ToString();                
                lblDoc8.Text = "Ocupacion";
                lblDoc9.Text = "Fecha nac.";
                lblDoc10.Text = "Originario";
                lblDoc15.Text = "Inmueble";
                lblDoc16.Text = "Norte";
                lblDoc17.Text = "Sur";
                lblDoc18.Text = "Este";
                lblDoc19.Text = "Oeste";
            }
        }

        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedIndex >= 0)
                cliente = new Cliente(prestamo.Datos.IdCliente);
            else
                cliente = null;
        }

        private void tbnAgregarPlazo_Click(object sender, EventArgs e)
        {
            dgvPlazos.Rows.Add(dgvPlazos.Rows.Count + 1, dtpFecPlazo.Value.Date.ToShortDateString(), tbxCantPlazo.Value,tbxPlazoLetra.Text);
        }

        private void btnQuitarPlazo_Click(object sender, EventArgs e)
        {
            if(dgvPlazos.Rows.Count>=1)
                dgvPlazos.Rows.RemoveAt(dgvPlazos.Rows.Count - 1);
        }                                
        
    }
}
