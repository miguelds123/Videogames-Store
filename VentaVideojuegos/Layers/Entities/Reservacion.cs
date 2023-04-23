using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase Reservacion que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Reservacion en la base de datos
    /// </summary>

    public class Reservacion
    {
        public int ID { get; set; }

        public int IdCliente { get; set; }

        public int IdProducto { get; set; }

        public double Adelanto { get; set; }
    }
}
