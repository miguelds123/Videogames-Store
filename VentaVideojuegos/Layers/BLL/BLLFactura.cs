using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos
{
    class BLLFactura : IBLLFactura
    {
        public int GetCurrentNumeroFactura()
        {
            IDALFactura _DALFactura= new DALFactura();

            return _DALFactura.GetCurrentNumeroFactura();
        }

        public int GetNextNumeroFactura()
        {
            IDALFactura _DALFactura = new DALFactura();

            return _DALFactura.GetNextNumeroFactura();
        }

        public OrdenCompraDTO SaveFactura(OrdenCompraDTO pOrdenCompra)
        {
            IDALFactura _DALFactura = new DALFactura();
            IBLLProducto _BLLProducto= new BLLProducto();

            foreach (DetalleOrden detalle in pOrdenCompra.listaDetalles)
            {
                _BLLProducto.AvabilityStock(detalle.IdProducto, detalle.Cantidad);
            }

            return _DALFactura.SaveFactura(pOrdenCompra);
        }
    }
}
