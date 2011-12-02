using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public static class TiposCambiosBLL
    {
        public static SicobDataSet.TiposCambioDataTable Obtener()
        {
            return DAL.AppProvider.TiposCambios.Obtener();            
        }

        public static bool Actualizar(DateTime Fecha, decimal TCVenta, decimal TCCompra)
        {
            int res = DAL.AppProvider.TiposCambios.Actualizar(Fecha,TCVenta,TCCompra);
            return (res > 0);
        }

        public static TipoCambio TipoCambioDelDia()
        {
            SicobDataSet.TiposCambioDataTable dt = DAL.AppProvider.TiposCambios.TipoCambioDelDia();
            if (dt.Rows.Count == 0)
                return null;
            TipoCambio tc = new TipoCambio(dt[0]);            
            dt.Dispose();
            dt = null;
            return tc;
        }

        public static TipoCambio TCSucursal(int idsuacursal)
        {
            SicobDataSet.TiposCambioDataTable dt = DAL.AppProvider.TiposCambios.ObtenerPorSucursal(idsuacursal);
            if (dt.Rows.Count == 0)
                return null;
            TipoCambio tc = new TipoCambio(dt[0]);
            dt.Dispose();
            dt = null;
            return tc;
        }

        public static TipoCambio TCCaja(int idcaja)
        {
            SicobDataSet.TiposCambioDataTable dt = DAL.AppProvider.TiposCambios.ObtenerPorCaja(idcaja);
            if (dt.Rows.Count == 0)
                return null;
            TipoCambio tc = new TipoCambio(dt[0]);
            dt.Dispose();
            dt = null;
            return tc;
        }
    }

    public class TipoCambio
    {
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private decimal _TCVenta;

        public decimal TCVenta
        {
            get { return _TCVenta; }
            set { _TCVenta = value; }
        }
        private decimal _TCCompra;

        public decimal TCCompra
        {
            get { return _TCCompra; }
            set { _TCCompra = value; }
        }

        public TipoCambio() { }
        public TipoCambio(DateTime Fecha, decimal TCVenta, decimal TCCompra)
        {
            this.Fecha = Fecha;
            this.TCVenta = TCVenta;
            this.TCCompra = TCCompra;
        }
        public TipoCambio(SicobDataSet.TiposCambioRow TC)
        {
            Fecha = TC.Fecha;
            TCVenta = TC.TCVenta;
            TCCompra = TC.TCCompra;
        }
    }
}
