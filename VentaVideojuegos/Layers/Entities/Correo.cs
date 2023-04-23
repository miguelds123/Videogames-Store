using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase Correo que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Correo en la base de datos
    /// </summary>

    public class Correo
    {
        public string CorreoElectronico { get; set; }

        public int IdCliente { get; set; }
    }
}
