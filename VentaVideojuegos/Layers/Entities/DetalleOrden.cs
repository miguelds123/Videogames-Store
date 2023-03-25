using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    public class DetalleOrden
    {
        public int IdOrden { get; set; }

        public int IdDetalle { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public double Total { get; set; }
    }
}
