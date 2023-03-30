using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IBLLCliente
    {
        List<Cliente> GetClienteByFilter(string pDescripcion);
        Cliente GetClienteById(string pId);
        List<Cliente> GetAllCliente();
        void SaveCliente(Cliente pCliente);
        void UpdateCliente(Cliente pCliente);
        void DeleteCliente(string pId);
    }
}
