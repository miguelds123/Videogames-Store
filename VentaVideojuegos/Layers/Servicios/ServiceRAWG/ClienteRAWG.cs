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
        public async Task<RAWGJuego> ObtenerJuego(string nombre, string rawgkey)
        {
            return await ManejadorRAWG.RespuestaRAWG(nombre, rawgkey);
        }
    }
}
