using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class BLLLogin : IBLLLogin
    {
        IDALLogin _DALLogin= new DALLogin();

        public void DeleteUsuario(string pId)
        {
            _DALLogin.DeleteUsuario(pId);
        }

        public List<Usuario> GetAllUsuario()
        {
            return _DALLogin.GetAllUsuario();
        }

        public Usuario GetUsuarioByFilter(string pDescripcion)
        {
            return _DALLogin.GetUsuarioByFilter(pDescripcion);
        }

        public bool Login(string pUsuario, string pContrasena)
        {
            return _DALLogin.Login(pUsuario, pContrasena);
        }

        public void SaveUsuario(Usuario pUsuario)
        {
            _DALLogin.SaveUsuario(pUsuario);
        }

        public void UpdateUsuario(Usuario pUsuario)
        {
            _DALLogin.UpdateUsuario(pUsuario);
        }
    }
}
