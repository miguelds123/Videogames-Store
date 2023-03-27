using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.Entities
{
    class Distrito
    {
        public int Id { get; set; }

        public int IdDistrito { get; set; }

        public int IdProvincia { get; set; }

        public string Descripcion { get; set; }
    }
}
