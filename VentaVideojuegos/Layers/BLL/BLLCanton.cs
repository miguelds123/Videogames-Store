using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Layers.DAL;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLCanton que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Canton de la base de datos
    /// </summary>

    class BLLCanton : IBLLCanton
    {
        /// <summary>
        /// Método que retorna toda la informacion contenida en la tabla Canton de la 
        /// base de datos
        /// </summary>
        /// <returns>Una lista de objetos con toda la informacion contenida
        /// en la tabla Canton de la base de datos</returns>

        public List<Canton> GetAllCanton()
        {
            IDALCanton _DALCanton= new DALCanton();

            return _DALCanton.GetAllCanton();
        }
    }
}
