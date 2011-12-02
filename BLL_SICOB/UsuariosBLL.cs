using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public static class UsuariosBLL
    {
        public static SicobDataSet.UsuariosDataTable Obtener()
        {
            return AppProvider.Usuarios.Obtener();
        }

        public static bool Guardar(Usuario u)
        {
            return (AppProvider.Usuarios.Update(u.Datos) > 0);
        }

        public static bool Guardar(SicobDataSet.UsuariosDataTable dt)
        {
            return (AppProvider.Usuarios.Update(dt) > 0);
        }
    }

    public class Usuario
    {
        private string _IdUsuario;
        private SicobDataSet.UsuariosDataTable dtDatos;
        public SicobDataSet.UsuariosRow Datos
        {
            get { return dtDatos.FindByIdUsuario(IdUsuario); }
        }

        public string IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        private bool _Nuevo;

        public bool Nuevo
        {
            get { return _Nuevo; }
            set { _Nuevo = value; }
        }

        public Usuario(string idusuario)
        {
            dtDatos = AppProvider.Usuarios.ObtenerPorId(idusuario);
            _Nuevo = false;
            if (dtDatos.Rows.Count == 0)
            {
                dtDatos.AddUsuariosRow(idusuario, "", "", 0, 0, "");
                _Nuevo = true;
            }
            this.IdUsuario = idusuario;
        }

        public Usuario()
        {            
        }

        public void Dispose()
        {
            dtDatos.Dispose();
            dtDatos = null;
        }
    }
}
