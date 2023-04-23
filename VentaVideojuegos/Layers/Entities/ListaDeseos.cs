using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase ListaDeseos que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla ListaDeseos en la base de datos
    /// </summary>

    public class ListaDeseos
    {
        public int IdCliente { get; set; }

        public int IdProducto { get; set; }
    }
}
