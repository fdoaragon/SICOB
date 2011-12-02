using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public static class SucursalesBLL
    {
        public static bool Guardar(Sucursal sucursal)
        {
            return (AppProvider.Sucursales.Update(sucursal.Datos) > 0);
        }

        public static bool Eliminar(int idsucursal)
        {
            return (AppProvider.Sucursales.Eliminar(idsucursal) > 0);
        }
    }

    public class Sucursal
    {
        private SicobDataSet.SucursalesDataTable dt;
        private int _IdSucursal;
        public int IdSucursal
        {
            get { return _IdSucursal; }
            set { _IdSucursal = value; }
        }
        public SicobDataSet.SucursalesRow Datos
        {
            get{ return dt.FindByIdSucursal(IdSucursal);}
        }

        public bool IsNull()
        {
            return (dt == null);
        }

        /// <summary>
        /// Obtiene y crea la sucursal a partir de su id
        /// </summary>
        /// <param name="idsucursal"></param>
        public Sucursal(int idsucursal)
        {
            dt = AppProvider.Sucursales.ObtenerPorId(idsucursal);
            IdSucursal = idsucursal;
            if (Datos == null)
            {
                dt.Dispose();
                dt = null;
            }
        }

        /// <summary>
        /// Crea una nueva sucursal
        /// </summary>
        /// <param name="idsucursal"></param>
        /// <param name="descripcion"></param>
        /// <param name="rfc"></param>
        /// <param name="direccion"></param>
        /// <param name="cabecera"></param>
        /// <param name="pie"></param>
        /// <param name="razon"></param>
        /// <param name="logo"></param>
        /// <param name="tcventa"></param>
        /// <param name="tccompra"></param>
        public Sucursal(int idsucursal,string descripcion,string rfc,string direccion,string cabecera, string pie, string razon,string logo,decimal tcventa,decimal tccompra)
        {
            dt = new SicobDataSet.SucursalesDataTable();
            dt.AddSucursalesRow(idsucursal, descripcion, rfc, direccion, cabecera, pie, razon, logo, tcventa, tccompra);
            IdSucursal = idsucursal;
        }

        public Sucursal()
        {
            dt = new SicobDataSet.SucursalesDataTable();
            dt.AddSucursalesRow(-1,"","","","","","","",0,0);
            IdSucursal = -1;
        }
    }
}
