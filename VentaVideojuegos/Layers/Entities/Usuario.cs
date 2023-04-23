using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase Usuario que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Usuario en la base de datos
    /// </summary>

    class Usuario
    {
        public string Login { set; get; }
        public string Password { set; get; }
        public int IdCategoria { get; set; }
        public byte[] IMAGEN { set; get; }

    }
}
