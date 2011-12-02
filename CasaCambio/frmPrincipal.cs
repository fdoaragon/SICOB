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
//using WordLector;
//using Microsoft.Office.Interop.Word;

namespace CasaCambio
{
    public partial class frmPrincipal : Form
    {
        //private int childFormNumber = 0;
        private frmTiposCambio ventanaTc;
        private frmCambio ventanaOp;
        private frmClientes ventanaCli;
        private frmPrestamos ventanaPre;
        private frmPrestamosVencidos ventanaVen;
        private frmInventarios ventanaInv;
        private frmCortesCaja ventanaCor;
        private frmUsuarios ventanausr;
        private frmDiasFestivos ventanaDia;
        private frmSucursales ventanaSuc;
        private frmCheques ventanaChq;

        public frmPrincipal()
        {
            InitializeComponent();
            this.Text = "SICOB " + Application.ProductVersion + "  Menú Principal";
            notifyIcon1.Click += new EventHandler(notifyIcon1_Click);
        }

        void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }

        private bool VerificarConexion()
        {
            RespuestaExterna respuesta = new RespuestaExterna();
            respuesta.Completo = false;
            while (!respuesta.Completo)
            {
                respuesta = DAL.AppProvider.EstablecerConexion(Properties.Settings.Default.CadenaConexion);
                if (!respuesta.Completo)
                {
                    DialogResult res = MessageBox.Show("No se pudo establecer la conexión con la base de datos\n" + respuesta.MensajeError + "\nDesea cambiar los parámetros?", "Conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes)
                    {
                        string value = "contraseña";
                        if (Globales.InputBox("Contraseña del sistema", "Contraseña del sistema:", ref value, true) == DialogResult.OK)
                        {
                            //if (SiiConsola.SoporteComun.Encrypt(value) == Properties.Settings.Default.Sistema)
                            if (true)
                            {
                                Globales.user = new Usuario();
                                Globales.user.IdUsuario = "admin";
                                frmConfig frm = new frmConfig();
                                frm.ShowDialog();
                                frm.Dispose();
                                frm = null;                                
                            }
                        }
                        else return false;
                    }
                    else
                        return false;
                }                
            }
            return true;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (!VerificarConexion())
            {
                Application.Exit();
                return;
            }
            backgroundWorker2.RunWorkerAsync();           
            frmLogin log = new frmLogin();
            log.ShowDialog();
            log.Close();
            log = null;
            if(Globales.user!=null)
                backgroundWorker1.RunWorkerAsync();
            

        }

        #region FORMULARIOS DISPOSE
        void ventanaTc_Disposed(object sender, EventArgs e)
        {
            ventanaTc = null;
        }

        void ventanaOp_Disposed(object sender, EventArgs e)
        {
            ventanaOp = null;
        }

        void ventanaCli_Disposed(object sender, EventArgs e)
        {
            ventanaCli = null;
        }        

        void ventanaPre_Disposed(object sender, EventArgs e)
        {
            ventanaPre = null;
        }

        void ventanaVen_Disposed(object sender, EventArgs e)
        {
            ventanaVen = null;
        }

        void ventanaInv_Disposed(object sender, EventArgs e)
        {
            ventanaInv = null;
        }

        void ventanaCor_Disposed(object sender, EventArgs e)
        {
            ventanaCor = null;
        }

        void ventanausr_Disposed(object sender, EventArgs e)
        {
            ventanausr = null;
        }                       

        void ventanaDia_Disposed(object sender, EventArgs e)
        {
            ventanaDia = null;
        }        

        void ventanaSuc_Disposed(object sender, EventArgs e)
        {
            ventanaSuc = null;
        }

        void ventanaChq_Disposed(object sender, EventArgs e)
        {
            ventanaChq = null;
        }
        #endregion

        #region MENU
        private void menuItem2_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            Globales.user = null;
            log.ShowDialog();
            log.Close();
            log = null;
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            if (ventanaOp == null)
            {
                ventanaOp = new frmCambio();
                //ventanaOp.Parent = this;
                //ventanaOp.MdiParent = this;
                //ventanaOp.StartPosition = FormStartPosition.Manual;
                //ventanaOp.Left = 0;
                //ventanaOp.Top = 0;
                ventanaOp.Disposed += new EventHandler(ventanaOp_Disposed);
            }
            ventanaOp.Show();
            ventanaOp.Focus();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            
            if (ventanaCor == null)
            {
                ventanaCor = new frmCortesCaja();
                ventanaCor.MdiParent = this;
                ventanaCor.Disposed += new EventHandler(ventanaCor_Disposed);
            }
            ventanaCor.Show();
            ventanaCor.Focus(); 
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ventanaInv == null)
            {
                ventanaInv = new frmInventarios();
                ventanaInv.MdiParent = this;
                ventanaInv.Disposed += new EventHandler(ventanaInv_Disposed);
            }
            ventanaInv.Show();
            ventanaInv.Focus();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ventanaSuc == null)
            {
                ventanaSuc = new frmSucursales();
                ventanaSuc.MdiParent = this;
                ventanaSuc.Disposed += new EventHandler(ventanaSuc_Disposed);
            }
            ventanaSuc.Show();
            ventanaSuc.Focus();
        }        

        private void menuItem9_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ventanaVen == null)
            {
                ventanaVen = new frmPrestamosVencidos();
                ventanaVen.MdiParent = this;
                ventanaVen.Disposed += new EventHandler(ventanaVen_Disposed);
            }
            ventanaVen.Show();
            ventanaVen.Focus();
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ventanaCli == null)
            {
                ventanaCli = new frmClientes();
                ventanaCli.MdiParent = this;
                ventanaCli.Disposed += new EventHandler(ventanaCli_Disposed);
            }
            ventanaCli.Show();
            ventanaCli.Focus();
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ventanaDia == null)
            {
                ventanaDia = new frmDiasFestivos();
                ventanaDia.MdiParent = this;
                ventanaDia.Disposed += new EventHandler(ventanaDia_Disposed);
            }
            ventanaDia.Show();
            ventanaDia.Focus();
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ventanausr == null)
            {
                ventanausr = new frmUsuarios();
                ventanausr.MdiParent = this;
                ventanausr.Disposed += new EventHandler(ventanausr_Disposed);
            }
            ventanausr.Show();
            ventanausr.Focus();
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ventanaChq == null)
            {
                ventanaChq = new frmCheques();
                ventanaChq.MdiParent = this;
                ventanaChq.Disposed += new EventHandler(ventanaChq_Disposed);
            }
            ventanaChq.Show();
            ventanaChq.Focus();
        }

        private void menuItem18_Click(object sender, EventArgs e)
        {
            if (Globales.user.Datos.IdSucursal != 0)
            {
                MessageBox.Show("No tiene los privilegios suficientes para ver ésta pantalla", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
            frm.Dispose();
            frm = null;
        }
        
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SicobDataSet.ChequesDataTable dt;
            while (true)
            {
                if (Globales.user.Datos.IdSucursal == 0)
                {
                    dt = ChequesBLL.Obtener(EstatusCheque.Pendiente);
                    if (dt.Rows.Count > 0)
                    {
                        notifyIcon1.Text = this.Text;
                        notifyIcon1.ShowBalloonTip(10000, "Cheques Pendientes", "Existen cheques pendientes de cobro", ToolTipIcon.Warning);
                    }
                }
                
                System.Threading.Thread.Sleep(900000);
                
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dia = DateTime.Today;
            TimeSpan d= new TimeSpan(1,0,0,0);
            while (true)
            {
                dia = DateTime.Today.Subtract(d);                
                //solo la caja 3 que es la caja fuerte o servidor y media noche o a medio día
                if (Globales.IdCaja==3 && (DateTime.Now.Hour%3==0))
                {
                    PrestamosBLL.Cortar(dia);
                    notifyIcon1.ShowBalloonTip(10000, "Cortes de Prestamos", "Se realizaron los cortes de prestamo para el día de ayer", ToolTipIcon.Info);                    
                }
                System.Threading.Thread.Sleep(1800000);//cada media hora

            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Desea cerrar la aplicación?","Cerrar",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
                e.Cancel=true;

        }       

    }
}
