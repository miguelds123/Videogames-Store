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
    }
}
