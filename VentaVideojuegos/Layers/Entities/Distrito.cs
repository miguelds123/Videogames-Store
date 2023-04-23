using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.Entities
{
    /// <summary>
    /// Clase Distrito que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Distrito en la base de datos
    /// </summary>

    class Distrito
    {
        public int Id { get; set; }

        public int IdDistrito { get; set; }

        public int IdProvincia { get; set; }

        public string Descripcion { get; set; }
    }
}
