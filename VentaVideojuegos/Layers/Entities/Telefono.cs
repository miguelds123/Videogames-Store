using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase Telefono que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Telefono en la base de datos
    /// </summary>

    public class Telefono
    {
        public string Numero { get; set; }

        public int IdCliente { get; set; }
    }
}
