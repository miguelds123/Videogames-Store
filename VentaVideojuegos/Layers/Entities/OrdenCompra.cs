using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase OrdenCompra que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla OrdenCompra en la base de datos
    /// </summary>

    public class OrdenCompra
    {
        public int ID { get; set; }

        public DateTime FechaOrden { get; set; }

        public int IdCliente { get; set; }

        public double Total { get; set; }

        public double TotalDolares { get; set; }

        public double SubTotal { get; set; }


    }
}
