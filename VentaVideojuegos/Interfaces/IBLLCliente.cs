using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Interfaces
{
    interface IBLLCliente
    {
        List<Cliente> GetClienteByFilter(string pDescripcion);
        Cliente GetClienteById(string pId);
        List<Cliente> GetAllCliente();
        Cliente SaveCliente(Cliente pCliente);
        Cliente UpdateCliente(Cliente pCliente);
        bool DeleteCliente(string pId);
    }
}
