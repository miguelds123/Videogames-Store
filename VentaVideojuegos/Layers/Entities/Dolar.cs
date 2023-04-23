using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase Dolar que contiene las propiedades necesarias para almacenar el contenido
    /// del servicio ServiceBCCR
    /// </summary>

    class Dolar
    {
        public string Codigo { get; set; }

        public DateTime Fecha { get; set; }

        public double Monto { get; set; }
    }
}
