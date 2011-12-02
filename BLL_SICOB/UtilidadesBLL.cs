using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace BLL
{
    public static class UtilidadesBLL
    {
        public static SicobDataSet.UtilidadesDataTable Resumen(DateTime? FechaIni, DateTime? FechaFin, int? IdSucursal, int? IdCaja)
        {
            return AppProvider.Utilidades.ResumenDeUtilidades(FechaIni, FechaFin, IdSucursal, IdCaja);
        }
    }
}
