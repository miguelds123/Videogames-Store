using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IDALCorreo
    {
        List<Correo> GetCorreoByFilter(string pCorreo);
        List<Correo> GetCorreoByIdCliente(string pId);
        List<Correo> GetAllCorreo();
        void SaveCorreo(Correo correo);
        void UpdateCorreo(Correo correo, string pCorreoViejo, string pIdClienteViejo);
        void DeleteCorreo(string pId, string pCorreo);
    }
}
