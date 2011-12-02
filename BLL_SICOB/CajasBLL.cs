using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public static class CajasBLL
    {
        public static SicobDataSet.CajasDataTable ObtenerPorSucursal(int idsucursal)
        {
            return DAL.AppProvider.Cajas.ObtenerPorSucursal(idsucursal);
        }

        public static bool Guardar(SicobDataSet.CajasDataTable dt)
        {
            return (AppProvider.Cajas.Update(dt) > 0);
        }

        public static bool Insertar(int idsucursal,string descripcion)
        {
            return (AppProvider.Cajas.Insertar(idsucursal, descripcion)>0);
        }

        public static bool Eliminar(int idcaja)
        {
            return (AppProvider.Cajas.Eliminar(idcaja) > 0);
        }

        public static bool Actualizar(int idcaja, string descripcion)
        {
            return (AppProvider.Cajas.Actualizar(idcaja, descripcion) > 0);
        }
    }

    public class Caja
    {
        private SicobDataSet.CajasDataTable dt;
        private int _IdCaja;
        public int IdCaja
        {
            get { return _IdCaja; }
            set { _IdCaja = value; }
        }
        public SicobDataSet.CajasRow Datos
        {
            get { return dt.FindByIdCaja(IdCaja); }
        }

        private Sucursal _Sucursal;
        public Sucursal Sucursal
        {
            get { return _Sucursal; }
            set { _Sucursal = value; }
        }

        public bool IsNull()
        {
            return (dt == null);
        }

        /// <summary>
        /// Obtiene y crea una caja a partir de su id
        /// </summary>
        /// <param name="idcaja"></param>
        public Caja(int idcaja)
        {
            dt = AppProvider.Cajas.ObtenerPorId(idcaja);
            this.IdCaja = idcaja;
            if (Datos != null)
            {
                Sucursal = new Sucursal(Datos.IdSucursal);
            }
            else
            {
                dt.Dispose();
                dt = null;
            }
        }


        /// <summary>
        /// Crea una nueva caja
        /// </summary>
        /// <param name="idcaja"></param>
        /// <param name="descripcion"></param>
        /// <param name="idsucursal"></param>
        public Caja(int idcaja,string descripcion,int idsucursal)
        {
            dt = new SicobDataSet.CajasDataTable();
            dt.AddCajasRow(idcaja, idsucursal, descripcion, 0, 0, "");
            IdCaja = idcaja;
        }

    }

    
}
