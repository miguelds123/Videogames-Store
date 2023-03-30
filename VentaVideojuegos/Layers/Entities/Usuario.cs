using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class Usuario
    {
        public int ID { get; set; }
        public string Login { set; get; }
        public string Password { set; get; }

        public int IdCategoria { get; set; }
    }
}
