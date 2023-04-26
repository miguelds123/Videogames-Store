using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLProvincia que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Provincia de la base de datos
    /// </summary>

    class BLLProvincia : IBLLProvincia
    {
        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Provincia de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Provincia con la informacion de cada uno de 
        /// los campos de la tabla Provincia</returns>

        public List<Provincia> GetAllProvincia()
        {
            IDALProvincia _DALProvincia=  new DALProvincia();

            return _DALProvincia.GetAllProvincia();
        }
    }
}
