using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IDAListaDeseos
    {
        List<ListaDeseos> GetListaDeseosByIdProducto(string pId);
        List<ListaDeseos> GetListaDeseosByIdCliente(string pId);
        ListaDeseos GetListaDeseos(string pIdCliente, string pIdProducto);
        List<ListaDeseos> GetAllListaDeseos();
        ListaDeseos SaveListaDeseos(ListaDeseos pListaDeseos);
        ListaDeseos UpdateListaDeseos(ListaDeseos pListaDeseos);
        bool DeleteListaDeseos(string pIdCliente, string pIdProducto);
    }
}
