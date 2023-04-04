using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    public class Cliente
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Direccion { get; set; }

        public int IdProvincia { get; set; }

        public int IdCanton { get; set; }

        public string CodigoPostal { get; set; }

        public string Comentario { get; set; }


    }
}
