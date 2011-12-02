using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;
using DAL;
namespace BLL
{
    public static class ChequesBLL
    {
        public static SicobDataSet.ChequesDataTable Obtener(EstatusCheque est, DateTime? FechaIni, DateTime? FechaFin,int? Idcaja)
        {
            return AppProvider.Cheques.Obtener((int)est, FechaIni, FechaFin,Idcaja);
        }

        public static SicobDataSet.ChequesDataTable Obtener(EstatusCheque est)
        {
            return AppProvider.Cheques.Obtener((int)est, null, null, null);
        }

        public static SicobDataSet.ChequesDataTable Obtener(EstatusCheque est, int Idcaja)
        {
            return AppProvider.Cheques.Obtener((int)est, null, null, Idcaja);
        }

        public static int Insertar(int Folio, int? IdCliente, string Endozo, string DatosCheques)
        {
            return AppProvider.Cheques.Insertar(Folio, IdCliente, Endozo, DatosCheques);
        }

        public static int ActualizarEstatus(int IdChq, EstatusCheque Estatus)
        {
            return AppProvider.Cheques.Actualizar(IdChq, (int)Estatus);
        }

        public static int CambiarCheque(int idcaja, string idusuario, decimal CargosMXN,string Obs, int PctComision, int? idcliente,string Endozo,string DatosChq,decimal Cantidad)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                int folio = TransaccionesBLL.Insertar((int)TipoTransaccion.CambioCheque, idcaja, idusuario, CargosMXN, 0, 0, 0, Obs, PctComision,Cantidad,CargosMXN);
                Insertar(folio, idcliente, Endozo, DatosChq);
                scope.Complete();
                return folio;
            }
            
        }
    }
}
