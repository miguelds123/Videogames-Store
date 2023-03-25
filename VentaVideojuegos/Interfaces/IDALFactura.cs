using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Interfaces
{
    interface IDALFactura
    {
        OrdenCompraDTO SaveFactura(OrdenCompraDTO pOrdenCompra);
        int GetNextNumeroFactura();

        int GetCurrentNumeroFactura();
    }
}
