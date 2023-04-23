using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase ClienteRAWG que contiene los metodos necesarios para retornar toda la 
    /// informacion de un videojuego
    /// </summary>

    class ClienteRAWG
    {
        /// <summary>
        /// Método que retorna la informacion de un videojuego, consultado por medio 
        /// de su nombre
        /// </summary>
        /// <param name="nombre">nombre del videojuego a consultar</param>
        /// <param name="rawgkey">key necesario para tener acceso a la API RAWG</param>
        /// <returns>Toda la informacion del videojuego consultado, que se 
        /// encuenre almacenada en la API</returns>

        public RAWGJuego ObtenerJuego(string nombre, string rawgkey)
        {
            return ManejadorRAWG.RespuestaRAWGObjecto(nombre, rawgkey);
        }
    }
}
