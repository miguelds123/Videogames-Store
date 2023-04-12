using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    public class Videojuego
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public int CantidadInventario { get; set; }

        public double Descuento { get; set; }

        public int IdCategoria { get; set; }

        public double PrecioColones { get; set; }

        public double PrecioDolares { get; set; }

        public byte[] Imagen { set; get; }

        public int Estado { get; set; }


    }
}
