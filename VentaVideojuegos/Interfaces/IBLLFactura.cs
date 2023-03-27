﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    interface IBLLFactura
    {
        OrdenCompraDTO SaveFactura(OrdenCompraDTO pOrdenCompra);
        int GetNextNumeroFactura();

        int GetCurrentNumeroFactura();
    }
}
