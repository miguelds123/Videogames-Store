using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IBLLTelefono
    {
        List<Telefono> GetTelefonoByFilter(string pNumeroTelefono);
        List<Telefono> GetTelefonoByIdCliente(string pId);
        List<Telefono> GetAllTelefono();
        void SaveTelefono(Telefono pTelefono);
        void UpdateTelefono(Telefono pTelefono, string pTelefonoViejo, string pIdClienteViejo);
        void DeleteTelefono(string pId, string pTelefono);
    }
}
