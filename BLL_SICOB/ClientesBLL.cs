using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public static class ClientesBLL
    {
        public static Cliente ObtenerPorId(int idcliente)
        {
            Cliente c = null;
            c = new Cliente(idcliente);
            if (c.Datos == null)
                c = null;
            return c;
        }

        public static bool GuardarCliente(Cliente c)
        {
            return (AppProvider.Clientes.Update(c.Datos) > 0);
        }        
    }

    public class Cliente
    {
        private SicobDataSet.ClientesDataTable _dtClientes;
        private int IdCliente;
        public SicobDataSet.ClientesRow Datos
        {
            get { return _dtClientes.FindByIdCliente(IdCliente); }
        }

        public Cliente(int idcliente)
        {
            _dtClientes = AppProvider.Clientes.ObtenerPorId(idcliente);
            this.IdCliente = idcliente;
        }

        public Cliente()
        {
            _dtClientes = new SicobDataSet.ClientesDataTable();
            _dtClientes.AddClientesRow("", "", "", "", "", "");
            IdCliente = (int)_dtClientes.Rows[0][0];
        }

        public void Dispose()
        {
            if (_dtClientes != null)
                _dtClientes.Dispose();
            _dtClientes = null;
        }
    }
}
