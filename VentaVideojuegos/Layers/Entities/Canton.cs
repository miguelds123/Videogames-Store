using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{

    /// <summary>
    /// Clase Canton que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Canton en la base de datos
    /// </summary>

    class Canton
    {
        public int Id { get; set; }

        public int IdProvincia { get; set; }

        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
