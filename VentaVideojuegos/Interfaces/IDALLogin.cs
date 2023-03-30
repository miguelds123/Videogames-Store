using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IDALLogin
    {
        bool Login(string pUsuario, string pContrasena);
        Usuario GetUsuarioByFilter(string pDescripcion);
        List<Cliente> GetAllCliente();
        void SaveCliente(Cliente pCliente);
        void UpdateCliente(Cliente pCliente);
        void DeleteCliente(string pId);
    }
}
