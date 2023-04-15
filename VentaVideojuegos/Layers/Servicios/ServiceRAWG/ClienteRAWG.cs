using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    class ClienteRAWG
    {
        public RAWGJuego ObtenerJuego(string nombre, string rawgkey)
        {
            return ManejadorRAWG.RespuestaRAWGObjecto(nombre, rawgkey);
        }
    }
}
