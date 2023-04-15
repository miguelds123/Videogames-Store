using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    public class Videojuego
    {
        public int ID { set; get; }
        public string NOMBRE { set; get; }
        public int CANTIDAD_INVENTARIO { set; get; }
        public int DESCUENTO { set; get; }
        public int ID_CATEGORIA { set; get; }
        public double PRECIO_COLONES { set; get; }
        public double PRECIO_DOLARES { set; get; }
        public string DESCRIPCION { set; get; }
        public DateTime FECHA_SALIDA { set; get; }
        public double NOTA { set; get; }

    }
}
