using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IDALTelefono
    {
        List<Telefono> GetTelefonoByFilter(string pNumeroTelefono);
        List<Telefono> GetTelefonoByIdCliente(string pId);
        List<Telefono> GetAllTelefono();
        Telefono SaveTelefono(Telefono pTelefono);
        Telefono UpdateTelefono(Telefono pTelefono);
        bool DeleteTelefono(string pId, string pTelefono);
    }
}
