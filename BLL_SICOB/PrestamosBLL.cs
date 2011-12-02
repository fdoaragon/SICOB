using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Transactions;

namespace BLL
{
    public static class PrestamosBLL
    {
        public static Prestamo ObtenerPorId(int idprestamo)
        {
            Prestamo p = null;
            p = new Prestamo(idprestamo);
            if (p.Datos == null)
                p = null;
            return p;
        }

        public static bool Guardar(Prestamo p)
        {
            return (AppProvider.Prestamos.Update(p.Datos) > 0);
        }

        public static int RealizarPago(Prestamo p, decimal pago, decimal multa, bool conmulta,int idcaja,string idusuario,string Obs,decimal pagocliente)
        {
            decimal capital;
            using (TransactionScope scope= new TransactionScope())
            {
                capital= p.Datos.Capital + (conmulta?multa:0) - pago;
                int folio = TransaccionesBLL.Insertar((int)TipoTransaccion.EntradaPrestamo,idcaja,idusuario,0,pago,0,0,Obs,null,pagocliente,pagocliente-pago);
                TipoMovimiento mov = TipoMovimiento.Pago;
                if (p.Datos.Estatus == (int)mov) mov = TipoMovimiento.PagoCapital;
                AppProvider.Movimientos.Insertar(p.Datos.IdPrestamo,capital,p.Datos.Capital,0,(conmulta?multa:0),pago,(int)mov,folio,Obs);
                p.Datos.Estatus = (int)EstatusPrestamo.Pagado;
                p.Datos.Capital = capital;
                p.Datos.PagoMinimo = 0;
                if (capital <= 0)
                    p.Datos.Estatus = (int)EstatusPrestamo.Terminado;
                Guardar(p);
                scope.Complete();
                return folio;
            }
        }

        public static bool AplicarAjuste(Prestamo p,decimal pago, decimal multa,string obs)
        {
            decimal capital;
            using (TransactionScope scope = new TransactionScope())
            {
                capital = p.Datos.Capital + multa - pago;
                TipoMovimiento mov = TipoMovimiento.Descuento;
                if (multa - pago > 0) mov = TipoMovimiento.Ajuste;
                AppProvider.Movimientos.Insertar(p.Datos.IdPrestamo, capital, p.Datos.Capital, 0, multa, pago, (int)mov, null, obs);
                p.Datos.Capital = capital;                
                if (capital <= 0)
                    p.Datos.Estatus = (int)EstatusPrestamo.Terminado;
                Guardar(p);
                scope.Complete();
                return true;
            }
        }

        public static int EntregarPrestamo(int idprestamo, decimal cantidad, int interes,int idcaja, string idusuario,string Obs)
        {
            decimal capital,interes2;
            double i;
            i=((interes/100.0));
            interes2 = cantidad * (Convert.ToDecimal(i));
            capital = cantidad + interes2;
            capital = Math.Round(capital, 2);
            using (TransactionScope scope = new TransactionScope())
            {
                int folio = TransaccionesBLL.Insertar((int)TipoTransaccion.SalidaPrestamo, idcaja, idusuario, cantidad, 0, 0, 0, Obs, null,0,0);
                AppProvider.Movimientos.Insertar(idprestamo, capital, cantidad, interes2, 0, 0, (int)TipoMovimiento.EntregaPrestamo, folio,Obs);
                scope.Complete();
                return folio;
            }
        }
        
        public static SicobDataSet.PrestamosDataTable Obtener(DateTime? Fechapago, EstatusPrestamo? Estatus)
        {
            int? est=null;
            if(Estatus.HasValue)
                est=(int)Estatus.Value;
            return AppProvider.Prestamos.Obtener(Fechapago, est);
        }

        public static bool Cortar(DateTime FechaPago)
        {
            return (AppProvider.Prestamos.Cortar(FechaPago) > 0);
        }
    }

    public class Prestamo
    {
        private SicobDataSet.PrestamosDataTable _dtPrestamos;
        private int idPrestamo;
        public SicobDataSet.PrestamosRow Datos
        {
            get { return _dtPrestamos.FindByIdPrestamo(idPrestamo); }
        }
        private SicobDataSet.PrestamosMoviminetosDataTable _Movimientos;

        public SicobDataSet.PrestamosMoviminetosDataTable Movimientos
        {
            get { return _Movimientos; }
            set { _Movimientos = value; }
        }


        public Prestamo(int idprestamo)
        {
            _dtPrestamos = AppProvider.Prestamos.ObtenerPorId(idprestamo);
            this.idPrestamo = idprestamo;
            Movimientos = AppProvider.Movimientos.Obtener(idprestamo, null, null);
        }

        public Prestamo()
        {
            _dtPrestamos = new SicobDataSet.PrestamosDataTable();
            _dtPrestamos.AddPrestamosRow(-1, DateTime.Today, 1, 1, 1, 1, DateTime.Today, DateTime.Today, (int)EstatusPrestamo.Creado,0,0,false,false,DateTime.Today,"");
            idPrestamo = (int)_dtPrestamos.Rows[0][0];
        }

        public void Dispose()
        {
            if (_dtPrestamos != null)
                _dtPrestamos.Dispose();
            _dtPrestamos = null;
            if (_Movimientos != null)
                _Movimientos.Dispose();
            _Movimientos = null;
        }

    }
}
