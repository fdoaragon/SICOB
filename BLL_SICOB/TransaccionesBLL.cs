using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public static class TransaccionesBLL
    {
        public static SicobDataSet.TransaccionesDataTable Obtener(int? Folio,DateTime? FechaIni,DateTime? FechaFin,int? IdTipo,int? IdCaja, string IdUsuario,int? IdEstatus,int? idsucursal)
        {
            return AppProvider.Transacciones.Obtener(Folio,FechaIni,FechaFin,IdTipo,IdCaja,IdUsuario,IdEstatus,idsucursal);
        }

        public static Transaccion Obtener(int Folio)
        {
            SicobDataSet.TransaccionesDataTable dt = Obtener(Folio, null, null, null, null, null, null,null);
            if (dt.Rows.Count == 0)
                return null;
            Transaccion t = new Transaccion(Folio, dt);
            return t;
        }

        public static SicobDataSet.TransaccionesDataTable ObtenerPorCaja(int IdCaja)
        {
            return Obtener(null, DateTime.Today, null, null, IdCaja, null, null,null);
        }

        public static int Insertar(int IdTipo, int IdCaja, string Idusuario, decimal CargoMXN, decimal AbonoMXN, decimal CargoDLL, decimal AbonoDLL, string Observacion, int? ChqComision, decimal PagoCliente, decimal Vuelto)
        {
            return (int)AppProvider.Transacciones.Insertar(IdTipo, IdCaja, Idusuario, CargoMXN, AbonoMXN, CargoDLL, AbonoDLL, Observacion, ChqComision, false,PagoCliente,Vuelto);
        }

        public static int Insertar(int IdTipo, int IdCaja,string Idusuario, decimal CargoMXN, decimal AbonoMXN,decimal CargoDLL,decimal AbonoDLL,string Observacion,int? ChqComision,bool? MarcaAdmin)
        {
            return (int)AppProvider.Transacciones.Insertar(IdTipo, IdCaja, Idusuario, CargoMXN, AbonoMXN, CargoDLL, AbonoDLL, Observacion, ChqComision,MarcaAdmin,null,null);
        }

        public static int VentaDolares(int IdCaja, string IdUsuario, decimal CargoDLL, decimal AbonoMXN, string Obervacion,decimal PagoCliente)
        {
            return Insertar((int)TipoTransaccion.VentaDll, IdCaja, IdUsuario, 0, AbonoMXN, CargoDLL, 0, Obervacion, null,PagoCliente,PagoCliente - AbonoMXN);
        }

        public static int CompraDolares(int IdCaja, string IdUsuario, decimal CargoMXN, decimal AbonoDLL, string Obervacion)
        {
            return Insertar((int)TipoTransaccion.CompraDll, IdCaja, IdUsuario,CargoMXN, 0, 0, AbonoDLL, Obervacion, null, AbonoDLL,0);
        }

        public static SicobDataSet.TransaccionesDataTable Corte(int idcaja)
        {
            return AppProvider.Transacciones.ObtenerCorte(idcaja);
        }
    }

    public class Transaccion
    {
        private SicobDataSet.TransaccionesDataTable dt;
        private int _Folio;

        public int Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }
        public SicobDataSet.TransaccionesRow Datos
        {
            get { return dt.FindByFolio(Folio); }
        }
        public Transaccion(int folio, SicobDataSet.TransaccionesDataTable Tabla)
        {
            Folio = folio;
            dt = Tabla;
        }

    }
}
