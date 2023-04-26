using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLFactura que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla OrdenCompra y Detalle de la base de datos
    /// </summary>

    class BLLFactura : IBLLFactura
    {
        /// <summary>
        /// Metodo que obtiene de la base de datos el numero actual de la secuencia 
        /// NoFactura
        /// </summary>
        /// <returns>un int con el numero actual en el que se encuentra la secuencia</returns>

        public int GetCurrentNumeroFactura()
        {
            IDALFactura _DALFactura= new DALFactura();

            return _DALFactura.GetCurrentNumeroFactura();
        }

        /// <summary>
        /// Metodo que obtiene de la base de datos el siguiente numero de la secuencia 
        /// NoFactura
        /// </summary>
        /// <returns>un int con el siguiente numero en el que se encuentra la secuencia</returns>

        public int GetNextNumeroFactura()
        {
            IDALFactura _DALFactura = new DALFactura();

            return _DALFactura.GetNextNumeroFactura();
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase OrdenCompraDTO
        /// como campos de las tablas Orden Compra y Detalle en la base de datos
        /// </summary>
        /// <param name="pOrdenCompraDTO">instancia de la clase OrdenCompraDTO que sera almacenada
        /// en la base de datos</param>

        public void SaveFactura(OrdenCompraDTO pOrdenCompra)
        {
            IDALFactura _DALFactura = new DALFactura();
            IBLLProducto _BLLProducto= new BLLProducto();

            foreach (DetalleOrden detalle in pOrdenCompra.listaDetalles)
            {
                _BLLProducto.AvabilityStock(detalle.IdProducto, detalle.Cantidad);
            }

            _DALFactura.SaveFactura(pOrdenCompra);
        }
    }
}
