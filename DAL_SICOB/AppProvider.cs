using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SiiConsola;
namespace DAL
{
    public static class AppProvider
    {
        public static string CadenaConexion = Properties.Settings.Default.SICOBConnectionString;

        public static RespuestaExterna EstablecerConexion(string conn)
        {
            RespuestaExterna respuesta = new RespuestaExterna();
            try
            {
                string conndesc = SiiConsola.SoporteComun.Decrypt(conn);
                //conndesc = conn;
                TiposCambios.Connection.ConnectionString = conndesc;                
                TiposCambios.Obtener();
                conn = conndesc;
            }
            catch (SqlException sqle)
            {
                TiposCambios.Connection.ConnectionString = CadenaConexion;
                respuesta.Completo = false;
                respuesta.Valor = false;
                respuesta.MensajeError = sqle.Message;
                return respuesta;
            }
            CadenaConexion = conn;
            TiposCambios.Connection.ConnectionString = conn;
            Cajas.Connection.ConnectionString = conn;
            Transacciones.Connection.ConnectionString = conn;
            Cheques.Connection.ConnectionString = conn;
            Clientes.Connection.ConnectionString = conn;
            Catalogos.Connection.ConnectionString = conn;
            Prestamos.Connection.ConnectionString = conn;
            Movimientos.Connection.ConnectionString = conn;
            Usuarios.Connection.ConnectionString = conn;
            DiasFestivos.Connection.ConnectionString = conn;
            Sucursales.Connection.ConnectionString = conn;
            Utilidades.Connection.ConnectionString = conn;
            respuesta.Completo = true;
            respuesta.Valor = true;
            return respuesta; ;
        }

        private static SicobDataSetTableAdapters.TiposCambioTableAdapter _TiposCambios = new DAL.SicobDataSetTableAdapters.TiposCambioTableAdapter();

        public static SicobDataSetTableAdapters.TiposCambioTableAdapter TiposCambios
        {
            get { return _TiposCambios; }
        }

        private static SicobDataSetTableAdapters.CajasTableAdapter _Cajas = new DAL.SicobDataSetTableAdapters.CajasTableAdapter();

        public static SicobDataSetTableAdapters.CajasTableAdapter Cajas
        {
            get { return AppProvider._Cajas; }
            set { AppProvider._Cajas = value; }
        }

        private static SicobDataSetTableAdapters.TransaccionesTableAdapter _Transacciones = new DAL.SicobDataSetTableAdapters.TransaccionesTableAdapter();

        public static SicobDataSetTableAdapters.TransaccionesTableAdapter Transacciones
        {
            get { return AppProvider._Transacciones; }
            set { AppProvider._Transacciones = value; }
        }


        private static SicobDataSetTableAdapters.ChequesTableAdapter _Cheques = new DAL.SicobDataSetTableAdapters.ChequesTableAdapter();

        public static SicobDataSetTableAdapters.ChequesTableAdapter Cheques
        {
            get { return AppProvider._Cheques; }
            set { AppProvider._Cheques = value; }
        }

        private static SicobDataSetTableAdapters.ClientesTableAdapter _Clientes = new DAL.SicobDataSetTableAdapters.ClientesTableAdapter();

        public static SicobDataSetTableAdapters.ClientesTableAdapter Clientes
        {
            get { return AppProvider._Clientes; }
            set { AppProvider._Clientes = value; }
        }

        private static SicobDataSetTableAdapters.CatalogosTableAdapter _Catalogos = new DAL.SicobDataSetTableAdapters.CatalogosTableAdapter();

        public static SicobDataSetTableAdapters.CatalogosTableAdapter Catalogos
        {
            get { return AppProvider._Catalogos; }
            set { AppProvider._Catalogos = value; }
        }

        private static SicobDataSetTableAdapters.PrestamosTableAdapter _Prestamos = new DAL.SicobDataSetTableAdapters.PrestamosTableAdapter();

        public static SicobDataSetTableAdapters.PrestamosTableAdapter Prestamos
        {
            get { return AppProvider._Prestamos; }
            set { AppProvider._Prestamos = value; }
        }

        private static SicobDataSetTableAdapters.PrestamosMoviminetosTableAdapter _Movimientos = new DAL.SicobDataSetTableAdapters.PrestamosMoviminetosTableAdapter();

        public static SicobDataSetTableAdapters.PrestamosMoviminetosTableAdapter Movimientos
        {
            get { return AppProvider._Movimientos; }
            set { AppProvider._Movimientos = value; }
        }

        private static SicobDataSetTableAdapters.UsuariosTableAdapter _Usuarios = new DAL.SicobDataSetTableAdapters.UsuariosTableAdapter();

        public static SicobDataSetTableAdapters.UsuariosTableAdapter Usuarios
        {
            get { return AppProvider._Usuarios; }
            set { AppProvider._Usuarios = value; }
        }

        private static SicobDataSetTableAdapters.DiasFestivosTableAdapter _DiasFestivos = new DAL.SicobDataSetTableAdapters.DiasFestivosTableAdapter();

        public static SicobDataSetTableAdapters.DiasFestivosTableAdapter DiasFestivos
        {
            get { return AppProvider._DiasFestivos; }
            set { AppProvider._DiasFestivos = value; }
        }

        private static SicobDataSetTableAdapters.SucursalesTableAdapter _Sucursales = new DAL.SicobDataSetTableAdapters.SucursalesTableAdapter();

        public static SicobDataSetTableAdapters.SucursalesTableAdapter Sucursales
        {
            get { return AppProvider._Sucursales; }
            set { AppProvider._Sucursales = value; }
        }

        private static SicobDataSetTableAdapters.UtilidadesTableAdapter _Utilidades = new DAL.SicobDataSetTableAdapters.UtilidadesTableAdapter();

        public static SicobDataSetTableAdapters.UtilidadesTableAdapter Utilidades
        {
            get { return AppProvider._Utilidades; }
            set { AppProvider._Utilidades = value; }
        }


    }

    public class RespuestaExterna
    {
        public bool Completo;
        public object Valor;
        public string MensajeError;        

        public RespuestaExterna()
        {
         
        }
    }
}
