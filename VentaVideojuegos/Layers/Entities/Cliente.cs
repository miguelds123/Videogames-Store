using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{

    /// <summary>
    /// Clase Cliente que contiene las propiedades necesarias para almacenar el contenido
    /// de la tabla Cliente en la base de datos
    /// </summary>

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

        public int Estado { get; set; }


    }
}
