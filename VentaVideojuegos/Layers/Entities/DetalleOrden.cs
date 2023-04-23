using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase DetalleOrden que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla DetalleOrden en la base de datos
    /// </summary>

    public class DetalleOrden
    {
        public int IdOrden { get; set; }

        public int IdDetalle { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public double Total { get; set; }
    }
}
