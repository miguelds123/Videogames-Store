using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Layers.DAL;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLFacturaVideojuego que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla OrdenCompraVideojuego y DetalleVideojuego de la base de datos
    /// </summary>

    class BLLFacturaVideojuego
    {
        /// <summary>
        /// Metodo que obtiene de la base de datos el numero actual de la secuencia 
        /// NoFactura
        /// </summary>
        /// <returns>un int con el numero actual en el que se encuentra la secuencia</returns>

        public int GetCurrentNumeroFactura()
        {
            DALFacturaVideojuego _DALFacturaVideojuego= new DALFacturaVideojuego();

            return _DALFacturaVideojuego.GetCurrentNumeroFactura();
        }

        /// <summary>
        /// Metodo que obtiene de la base de datos el siguiente numero de la secuencia 
        /// NoFactura
        /// </summary>
        /// <returns>un int con el siguiente numero en el que se encuentra la secuencia</returns>

        public int GetNextNumeroFactura()
        {
            DALFacturaVideojuego _DALFacturaVideojuego = new DALFacturaVideojuego();

            return _DALFacturaVideojuego.GetNextNumeroFactura();
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase OrdenCompraDTO
        /// como campos de las tablas OrdenCompraVideojuego y DetalleVideojuego en la base de datos
        /// </summary>
        /// <param name="pOrdenCompraDTO">instancia de la clase OrdenCompraDTO que sera almacenada
        /// en la base de datos</param>

        public void SaveFactura(OrdenCompraDTO pOrdenCompraDTO)
        {
            DALFacturaVideojuego _DALFacturaVideojuego = new DALFacturaVideojuego();

            _DALFacturaVideojuego.SaveFactura(pOrdenCompraDTO);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase OrdenCompraDTO con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pNumeroFactura">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase OrdenCompraDTO con la informacion de las tablas
        /// OrdenCompraVideojuego y DetalleVideojuego cuyos campos id hayan coincidido con el parametro</returns>

        private OrdenCompraDTO GetFactura(double pNumeroFactura)
        {
            DALFacturaVideojuego _DALFacturaVideojuego = new DALFacturaVideojuego();

            return _DALFacturaVideojuego.GetFactura(pNumeroFactura);
        }
    }
}
