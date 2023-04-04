using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IBLLListaDeseos
    {
        List<ListaDeseos> GetListaDeseosByIdProducto(string pId);
        List<ListaDeseos> GetListaDeseosByIdCliente(string pId);
        ListaDeseos GetListaDeseos(string pIdCliente, string pIdProducto);
        List<ListaDeseos> GetAllListaDeseos();
        void SaveListaDeseos(ListaDeseos pListaDeseos);
        void UpdateListaDeseos(ListaDeseos pListaDeseos);
        void DeleteListaDeseos(string pIdCliente, string pIdProducto);
    }
}
