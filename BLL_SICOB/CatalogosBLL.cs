using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public static class CatalogosBLL
    {
        public static SicobDataSet.CatalogosDataTable Clientes()
        {
            return AppProvider.Catalogos.ObtenerClientes();
        }

        public static SicobDataSet.CatalogosDataTable Prestamos()
        {
            return AppProvider.Catalogos.ObtenerPrestamos(null);
        }

        public static SicobDataSet.CatalogosDataTable PrestamosActivos()
        {
            return AppProvider.Catalogos.ObtenerPrestamos(true);
        }

        public static SicobDataSet.CatalogosDataTable EstatusCheque()
        {
            return AppProvider.Catalogos.ObtenerEstatusCheques();
        }

        public static SicobDataSet.CatalogosDataTable EstatusPrestamo()
        {
            return AppProvider.Catalogos.ObtenerEstatusPrestamos();
        }

        public static SicobDataSet.CatalogosDataTable TiposMovimiento()
        {
            return AppProvider.Catalogos.ObtenerTiposMovimientos();
        }

        public static SicobDataSet.CatalogosDataTable TiposTransaccion()
        {
            return AppProvider.Catalogos.ObtenerTiposTransacciones();
        }

        public static SicobDataSet.CatalogosDataTable Sucursales()
        {
            return AppProvider.Catalogos.ObtenerSucursales();
        }

        public static SicobDataSet.CatalogosDataTable Cajas()
        {
            return AppProvider.Catalogos.ObtenerCajas();
        }

        public static SicobDataSet.DiasFestivosDataTable DiasFestivos()
        {
            return AppProvider.DiasFestivos.Obtener();
        }

        public static bool DiasFestivosGuardar(SicobDataSet.DiasFestivosDataTable dt)
        {
            return (AppProvider.DiasFestivos.Update(dt) > 0);
        }
    }
}
