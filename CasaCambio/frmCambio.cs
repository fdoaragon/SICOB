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
using CrystalDecisions.CrystalReports.Engine;

namespace CasaCambio
{
    public partial class frmCambio : Form
    {
        private TipoCambio Tc;        
        
        public frmCambio()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Text = "Operaciones de Cambio";
            dgvTransacciones.AutoGenerateColumns = false;
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
                    c.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
            }
            CargarPrestamos();
            SicobDataSet.CatalogosDataTable dt5 = CatalogosBLL.TiposTransaccion();
            clmTipo.DisplayMember = "Descripcion";
            clmTipo.ValueMember = "Id";
            clmTipo.DataSource = dt5;
            //clmAbonoD.AutoSizeMode = clmAbonoP.AutoSizeMode = clmCargosD.AutoSizeMode =
            //    clmInvD.AutoSizeMode = clmInvP.AutoSizeMode =
            //clmCargoP.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        }

        private void frmCambio_Load(object sender, EventArgs e)
        {
            Caja caja = new Caja(Globales.IdCaja);
            lblCaja.Text = "Caja " + caja.IdCaja.ToString() + " (" + caja.Datos.Descripcion + ") - " + Globales.user.Datos.Nombres;
            Tc = TiposCambiosBLL.TCCaja(Globales.IdCaja);
            if (Tc == null)
            {
                tcCambio.TabPages.RemoveAt(0);
                MessageBox.Show("No se ha capturado el tipo de cambio del día de hoy", "Tipo de cambio del día", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lblCaja.Text += " - [VENTA " + Tc.TCVenta.ToString("#0.00") + "][COMPRA " + Tc.TCCompra.ToString("#0.00") + "]";
                //dpFecha.Value = Tc.Fecha;
                //tbxVenta.Value = Tc.TCVenta;
                //tbxCompra.Value = Tc.TCCompra;
            }
            dgvTransacciones.DataSource = TransaccionesBLL.ObtenerPorCaja(Globales.IdCaja);            
        }

        #region CAMBIO DIVISAS
        private void tbxDolares_ValueChanged(object sender, EventArgs e)
        {
            decimal tc;
            if (rbVenta.Checked)
            {
                tc = Tc.TCVenta;
                if (((Control)sender).Name == "tbxEntregar")
                    tbxCobrar.Value = tc * tbxEntregar.Value;
                else
                    tbxEntregar.Value = (tc == 0 ? 0 : tbxCobrar.Value / tc);
            }
            else
            {
                tc = Tc.TCCompra;
                if (((Control)sender).Name == "tbxEntregar")
                    tbxCobrar.Value = (tc == 0 ? 0 : tbxEntregar.Value / tc);
                else
                    tbxEntregar.Value = tc * tbxCobrar.Value;
            }
            tbxCambio.Value = tbxPagoCon.Value - tbxCobrar.Value;
        }

        private void rbVenta_CheckedChanged(object sender, EventArgs e)
        {
            tbxEntregar.Value = 0;
            tbxPagoCon.Value = 0;
            if (rbVenta.Checked)
            {
                rbVenta.Image = CasaCambio.Properties.Resources.Pesos_150;
                rbCompra.Image = CasaCambio.Properties.Resources.dollar_100;
                tbxEntregar.ForeColor = Color.Green;
                tbxCobrar.ForeColor = Color.Black;
                lblEntregar1.ForeColor = Color.Green;
                lblEntregar2.ForeColor = Color.Green;
                lblCobrar1.ForeColor = Color.Black;
                lblCobrar2.ForeColor = Color.Black;
                lblPago2.Visible = lblPago1.Visible = tbxPagoCon.Visible = true;
                lblCambio1.Visible = lblCambio2.Visible = tbxCambio.Visible = true;
                btnTransDivisas.Image = CasaCambio.Properties.Resources.Pesos_150;
                btnTransDivisas.Text = "VENTA DOLARES";
                btnTransDivisas.ForeColor = Color.Green;
                lblEntregar2.Text = "Dolares";
                lblCobrar2.Text = "Pesos";
                tbxEntregar.Focus();
            }
            else
            {
                rbVenta.Image = CasaCambio.Properties.Resources.Pesos_100;
                rbCompra.Image = CasaCambio.Properties.Resources.dollar_150;
                tbxEntregar.ForeColor = Color.Black;
                tbxCobrar.ForeColor = Color.Green;
                lblEntregar1.ForeColor = lblEntregar2.ForeColor =Color.Black;
                lblCobrar1.ForeColor = lblCobrar2.ForeColor= Color.Green;
                btnTransDivisas.Image = CasaCambio.Properties.Resources.dollar_150;
                btnTransDivisas.Text = "COMPRA DOLARES";
                btnTransDivisas.ForeColor = Color.Black;
                lblEntregar2.Text = "Pesos";
                lblCobrar2.Text = "Dolares";
                lblPago2.Visible = lblPago1.Visible = tbxPagoCon.Visible = false;
                lblCambio1.Visible = lblCambio2.Visible = tbxCambio.Visible = false;
                tbxCobrar.Focus();
            }
            rbCompra.Left = rbVenta.Left + rbVenta.Width + 2;
            
        }

        private void btnTransDivisas_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (!ValidarCambioDivisas())
                return;
            res = MessageBox.Show("Esta a punto de efectuar la siguiente transacción:\n" +
                "CAMBIO DE DIVISAS (" + (rbVenta.Checked?"VENTA DE DOLARES)":"COMPRA DE DOLARES)") +
                "\nENTREGAR al cliente: $" + tbxEntregar.Value.ToString("#0.00") + (rbVenta.Checked ? " DOLARES" : " PESOS") +
                "\nRECIBIR del cliente: $" + tbxCobrar.Value.ToString("#0.00") + (rbVenta.Checked ? " PESOS" : " DOLARES") +
                "\nDesea continuar?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;
            int Folio=0;
            if (rbVenta.Checked)
                Folio = TransaccionesBLL.VentaDolares(Globales.IdCaja, Globales.user.IdUsuario, tbxEntregar.Value, tbxCobrar.Value, string.Empty,tbxPagoCon.Value);
            else
                Folio = TransaccionesBLL.CompraDolares(Globales.IdCaja, Globales.user.IdUsuario, tbxEntregar.Value, tbxCobrar.Value, string.Empty);
            if (Folio == 0)
                return;
            tbxEntregar.Value = 0;
            tbxCobrar.Value = 0;
            tbxPagoCon.Value = 0;
            dgvTransacciones.DataSource = TransaccionesBLL.ObtenerPorCaja(Globales.IdCaja);
            res=MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000") +
                "\nDesea imprimir el recibo?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
                ImprimirTicket(Folio);


        }

        bool ValidarCambioDivisas()
        {
            string err=string.Empty;
            if (tbxEntregar.Value == 0 || tbxCobrar.Value == 0)
                err += " - No se puede realizar una operación de $0.00\n";
            Caja caja = new Caja(Globales.IdCaja);
            if (!caja.IsNull())
            {
                if (rbVenta.Checked)
                {
                    if (tbxEntregar.Value > caja.Datos.InventarioDolares)
                        err += " - La caja no cuenta con la cantidad de dolares suficientes";
                    if ((Math.Round(tbxEntregar.Value, 0) - tbxEntregar.Value) != 0)
                    {
                        err += "No se permiten centavos de dolar, por favor redondee los dolares";
                        tbxEntregar.Focus();
                    }

                }
                if (!rbVenta.Checked)
                {
                    if (tbxCobrar.Value > caja.Datos.InventarioPesos)
                        err += " - La caja no cuenta con la cantidad de pesos suficientes";
                    if ((Math.Round(tbxCobrar.Value, 0) - tbxCobrar.Value) != 0)
                    {
                        err += "No se permiten centavos de dolar, por favor redondee los dolares";
                        tbxCobrar.Focus();
                    }
                }
                caja = null;
            }else
                err += " - No se pudo obtener la información de la caja";            
            if (err != string.Empty)
            {
                MessageBox.Show(err, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private void tbxEntregar_Enter(object sender, EventArgs e)
        {
            NumericUpDown control = (NumericUpDown)sender;
            control.Select(0,control.Value.ToString().Length + 3);
        }
        #endregion

        #region CHEQUES
        private void btnTransChq_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (!ValidarCambioChq())
                return;
            res = MessageBox.Show("Esta a punto de efectuar la siguiente transacción:\n" +
                "CAMBIO DE CHEQUE" +
                "\nEntregar al cliente: $" + this.tbxCantidad.Value.ToString("#0.00") +
                "\nDesea continuar?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;
            int Folio = 0;
            Folio = ChequesBLL.CambiarCheque(Globales.IdCaja, Globales.user.IdUsuario, tbxCantidad.Value, string.Empty,int.Parse(tbxComision.Value.ToString()),null,"",tbxChq.Text.Trim(),tbxCheque.Value);
            if (Folio == 0)
                return;
            tbxComision.Value = 10;
            tbxCheque.Value = 0;
            tbxCantidad.Value = 0;
            tbxChq.Lines[0] = "Banco:";
            tbxChq.Lines[1] = "No:";
            tbxChq.Lines[2] = "Fecha:";            
            cbxPrestamo_SelectedIndexChanged(null, null);
            dgvTransacciones.DataSource = TransaccionesBLL.ObtenerPorCaja(Globales.IdCaja);
            res = MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000") +
                "\nDesea imprimir el recibo?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res==DialogResult.Yes)
                ImprimirTicket(Folio);
        }

        bool ValidarCambioChq()
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

        private void tbxCheque_ValueChanged(object sender, EventArgs e)
        {
            decimal valor = tbxCheque.Value * ((100 - tbxComision.Value) / 100);
            if (valor != tbxCantidad.Value)
            {
                tbxCantidad.Value = valor;
                tbxComChq.Value = tbxCheque.Value - valor;
            }
        }
        
        private void btnVerChq_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("Revise los siguientes puntos para verificar la validez del cheque\n.");
            msg.AppendLine(" - Checar los sellos mediente uso de ultravioleta");
            msg.AppendLine(" - Checar que el cheque corresponda al nombre de la persona que lo\n" +
                           "   está cambiando mediante la credencial de elector (sacar copia)");
            msg.AppendLine(" - Que el cheque sea empresarial (ejemplo, Empresa S.A. de C.V., \n" +
                           "   S.A. de R.L. , etc.) ó gubernamental (Gobierno del Estado de Sonora)");
            msg.AppendLine(" - Checar que los últimos digitos del No. del Cheque sea un número\n" +
                           "   grande (Ejemplo, 0014 incorrecto, 1050 correcto");
            msg.AppendLine(" - Que el beneficiario sea el mismo que trae el cheque o que venga\n" +
                           "   endozado a su nombre");
            msg.AppendLine(" - QUE EL CHEQUE NO CUENTE CON NINGUN TIPO DE SELLO COMO: ABONO EN CUENTA DEL BENEFICIARIO, NO NEGOCIABLE NI RAYAS CRUZADAS");
            
            MessageBox.Show(msg.ToString(), "Verificar Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region PRESTAMOS
        private void btnTranPrestamo_Click(object sender, EventArgs e)
        {
            DialogResult res;
            bool conmulta=false;
            decimal multa = 0;
            if (cbxPrestamo.SelectedValue == null)
                return;
            Prestamo p = PrestamosBLL.ObtenerPorId((int)cbxPrestamo.SelectedValue);
            if (p.Datos.Estatus == (int)EstatusPrestamo.Terminado ||
                p.Datos.Estatus == (int)EstatusPrestamo.Cancelado)
            {
                MessageBox.Show("El préstamo ya no está activo");
                CargarPrestamos();
            }
            if ((tbxPago.Value < p.Datos.PagoMinimo))
            {
                conmulta=true;
                multa=p.Datos.Multa;
                MessageBox.Show("El pago no supera el mínimo requerido, se le cobrará la multa");                                
            }
            res = MessageBox.Show("Esta a punto de efectuar la siguiente transacción:\n"+
                "PAGO DE PRESTAMO\nPago del cliente: $" + tbxPago.Value.ToString("#0.00") + 
                "\nDesea continuar?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;
            int Folio = 0;            
            Folio=PrestamosBLL.RealizarPago(p, tbxPago.Value, multa, conmulta, Globales.IdCaja, Globales.user.IdUsuario, null,tbxPresPagoCon.Value);
            if (Folio == 0)
                return;
            dgvTransacciones.DataSource = TransaccionesBLL.ObtenerPorCaja(Globales.IdCaja);
            res = MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000") +
                "\nDesea imprimir el recibo?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
                ImprimirTicket(Folio);            
            cbxPrestamo_SelectedIndexChanged(null, null);
        }

        private void cbxPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTranPrestamo.Enabled = true;
            tbxPresPagoCon.Value = 0;
            if (cbxPrestamo.SelectedValue != null)
            {
                Prestamo p = PrestamosBLL.ObtenerPorId((int)cbxPrestamo.SelectedValue);
                tbxPago.Maximum = 9999999;
                tbxPago.Value = p.Datos.PagoMinimo;
                tbxPresEstatus.Text = ((EstatusPrestamo)p.Datos.Estatus).ToString();
                tbxPresCa.Text = p.Datos.Capital.ToString();
                tbxPresCi.Text = p.Datos.Cantidad.ToString();
                tbxPresFc.Text = p.Datos.FechaCorte.ToShortDateString();
                tbxPresI.Text = p.Datos.Interes.ToString();
                tbxPresM.Text = p.Datos.Multa.ToString();
                tbxPresPm.Text = p.Datos.PagoMinimo.ToString();                
                switch (p.Datos.Estatus)
                {
                    case (int)EstatusPrestamo.Curso:
                        tbxPago.Maximum = tbxPago.Value; break;
                    case (int)EstatusPrestamo.Vencido:
                        tbxPago.Maximum = tbxPago.Value; break;
                }
            }
            else
            {
                tbxPago.Value = 0;
                tbxPresPagoCon.Value = 0;
            }  
          
        }

        void CargarPrestamos()
        {
            SicobDataSet.CatalogosDataTable dt2 = CatalogosBLL.PrestamosActivos();
            cbxPrestamo.DisplayMember = "Descripcion";
            cbxPrestamo.ValueMember = "Id";
            cbxPrestamo.DataSource = dt2.DefaultView;
        }

        private void tbxPago_ValueChanged(object sender, EventArgs e)
        {
            tbxPresCambio.Value = tbxPresPagoCon.Value - tbxPago.Value;
        }

        private void btnPresMov_Click(object sender, EventArgs e)
        {
            frmPrestamos frm = new frmPrestamos();
            frm.idprestamo = (int)cbxPrestamo.SelectedValue;
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }
        #endregion

        #region IMPRIMIR
        private void ImprimirTicket(int folio)
        {
            Transaccion t = TransaccionesBLL.Obtener(folio);
            Caja caja = new Caja(Globales.IdCaja);
            TipoTransaccion tipo;
            if (t == null || caja.IsNull())
            {
                MessageBox.Show("Nose pudo obtener la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tipo = (TipoTransaccion)t.Datos.IdTipo;
            if (tipo != TipoTransaccion.CambioCheque && tipo != TipoTransaccion.CompraDll && tipo != TipoTransaccion.EntradaPrestamo &&
                tipo != TipoTransaccion.VentaDll && tipo !=TipoTransaccion.Gasto)
            {
                t = null;
                caja = null;
                return;
            }
            string logo = Application.StartupPath + "\\Imagenes\\Logotipos\\" + caja.Sucursal.Datos.Logo;
            ReportDocument rpt= new ReportDocument();
            rpt.Load("Reportes\\Ticket2.rpt");
            rpt.SetParameterValue("SUCURSAL", caja.Sucursal.Datos.RazonSocial);
            rpt.SetParameterValue("RFC", caja.Sucursal.Datos.RFC);
            rpt.SetParameterValue("DIRECCION", caja.Sucursal.Datos.Direccion);
            rpt.SetParameterValue("CABECERA", caja.Sucursal.Datos.Cabecera);
            rpt.SetParameterValue("FOLIO", t.Folio.ToString("00000"));
            rpt.SetParameterValue("FECHA", t.Datos.Fecha);
            rpt.SetParameterValue("PIE", caja.Sucursal.Datos.Pie);
            rpt.SetParameterValue("Logo", logo);            
            string concepto,titulo1,titulo2,firma;
            decimal tc,pago,total,cantidad,vuelto;
            switch (tipo)
            {
                case TipoTransaccion.VentaDll:
                case TipoTransaccion.CompraDll:
                    
                    if(tipo == TipoTransaccion.VentaDll)
                    {
                        concepto="Venta de dolares";
                        cantidad= t.Datos.CargosDLL;
                        titulo1="T.C. Venta";
                        tc=t.Datos.TCVenta;
                        total=t.Datos.AbonosMXN;
                    }
                    else
                    {
                        concepto="Compra de dolares";
                        cantidad= t.Datos.AbonosDLL;
                        titulo1="T.C. Compra";
                        tc=t.Datos.TCCompra;
                        total=t.Datos.CargosMXN;
                    }
                    titulo2="Pago con";
                    pago=t.Datos.PagoCliente;
                    vuelto = t.Datos.VueltoCliente;
                    rpt.SetParameterValue("CONCEPTO", concepto);
                    rpt.SetParameterValue("CANTIDAD", cantidad);
                    rpt.SetParameterValue("Titulo1", titulo1);
                    rpt.SetParameterValue("TC", tc);
                    rpt.SetParameterValue("Titulo2", titulo2);
                    rpt.SetParameterValue("Pago", pago);
                    rpt.SetParameterValue("TOTAL", total);
                    rpt.SetParameterValue("Vuelto", vuelto);
                    rpt.SetParameterValue("Firma", "");
                    break;
                case TipoTransaccion.CambioCheque:
                    cantidad = t.Datos.PagoCliente - t.Datos.VueltoCliente;
                    rpt.SetParameterValue("CONCEPTO", "Comisión cambio cheque" );
                    rpt.SetParameterValue("CANTIDAD",cantidad);
                    rpt.SetParameterValue("Titulo1", "comisión %");
                    rpt.SetParameterValue("TC", t.Datos.ChqComision);
                    rpt.SetParameterValue("Titulo2", "Cantidad del chq.");
                    rpt.SetParameterValue("Pago", t.Datos.PagoCliente);
                    rpt.SetParameterValue("TOTAL", cantidad);
                    rpt.SetParameterValue("Vuelto", t.Datos.VueltoCliente);
                    rpt.SetParameterValue("Firma", "");
                    break;
                case TipoTransaccion.EntradaPrestamo:
                    rpt.SetParameterValue("CONCEPTO", "Pago préstamo");
                    rpt.SetParameterValue("CANTIDAD", t.Datos.AbonosMXN);
                    rpt.SetParameterValue("Titulo1", "");
                    rpt.SetParameterValue("TC", 0);
                    rpt.SetParameterValue("Titulo2", "Pago con");
                    rpt.SetParameterValue("Pago", t.Datos.PagoCliente);
                   rpt.SetParameterValue("TOTAL", t.Datos.AbonosMXN);
                   rpt.SetParameterValue("Vuelto", t.Datos.VueltoCliente);
                   rpt.SetParameterValue("Firma", "");
                   break;
                case TipoTransaccion.Gasto:
                   rpt.SetParameterValue("CONCEPTO", "Gasto");
                   rpt.SetParameterValue("CANTIDAD", t.Datos.CargosMXN);
                   rpt.SetParameterValue("Titulo1", "");
                   rpt.SetParameterValue("TC", 0);
                   rpt.SetParameterValue("Titulo2", "Pago con");
                   rpt.SetParameterValue("Pago", t.Datos.PagoCliente);
                   rpt.SetParameterValue("TOTAL", t.Datos.CargosMXN);
                   rpt.SetParameterValue("Vuelto", t.Datos.VueltoCliente);
                   rpt.SetParameterValue("Firma", "Recibo");
                   break;
            }
            if (!Properties.Settings.Default.TicketPantalla)
            {
                rpt.PrintOptions.PrinterName = Properties.Settings.Default.Impresora;
                rpt.PrintToPrinter(Properties.Settings.Default.NoCopias, false, 1, 2);
                rpt.Dispose();
                rpt = null;
            }
            else
            {
                frmReporte frm = new frmReporte(rpt);
                //frm.CrViewer1.PrintReport();
                frm.ShowDialog();
                rpt.Dispose();
                rpt = null;
                frm.Dispose();
                frm = null;
            }            
            
        }

        private void dgvTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int folio = int.Parse(dgvTransacciones.Rows[e.RowIndex].Cells[0].Value.ToString());
            DialogResult res;
            res = MessageBox.Show("Desea imprimir el recibo " + folio.ToString("00000") + "?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                ImprimirTicket(folio);
            }

        }
        #endregion

        #region GASTOS
        private void btnPagar_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (tbxConcepto.Text.Trim() == string.Empty || tbxGasto.Value == 0)
            {
                MessageBox.Show("Debe introducir un concepto y una cantidad", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            res = MessageBox.Show("Esta a punto de efectuar la siguiente transacción:\n" +
                "GASTO" +
                "\nCONCEPTO: " + tbxConcepto.Text +
                "\nCANTIDAD: $" + tbxGasto.Value +
                "\nDesea continuar?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;
            int Folio = 0;
            Folio = TransaccionesBLL.Insertar((int)TipoTransaccion.Gasto,Globales.IdCaja, Globales.user.IdUsuario, tbxGasto.Value, 0,0,0, tbxConcepto.Text,null,0,0);
            if (Folio == 0)
                return;
            tbxConcepto.Text = string.Empty;
            tbxGasto.Value = 0;
            dgvTransacciones.DataSource = TransaccionesBLL.ObtenerPorCaja(Globales.IdCaja);
            res = MessageBox.Show("La transacción se guardo con el Folio " + Folio.ToString("00000") +
                "\nDesea imprimir el recibo?", "Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
                ImprimirTicket(Folio);

        }
        #endregion       

        

        
        

    }
}
