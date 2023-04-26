using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLProducto que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Producto de la base de datos
    /// </summary>

    class BLLProducto : IBLLProducto
    {
        public Producto AvabilityStock(double pId, double pCantidadSolicitada)
        {
            IDALProducto _DALProducto= new DALProducto();
            Producto producto= _DALProducto.GetProductoById(pId);

            if (producto.CantidadInventario < pCantidadSolicitada)
            {
                throw new Exception($"No hay cantidad suficiente en inventario para el producto {producto.ID} {producto.Descripcion}, cantidad disponible: {producto.CantidadInventario}");
            }
            else
            {
                return producto;
            }
        }

        /// <summary>
        /// Metodo que se utiliza para actualizar el Estado de un campo de la tabla 
        /// Producto en la base de datos
        /// </summary>
        /// <param name="pID">string que contiene el id del campo que se va a 
        /// actualizar en la base de datos</param>

        public void BorradoLogico(int pID)
        {
            IDALProducto _DALProducto = new DALProducto();

            _DALProducto.BorradoLogico(pID);
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Producto   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteProducto(double pId)
        {
            IDALProducto _DALProducto= new DALProducto();

            _DALProducto.DeleteProducto(pId);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Producto de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Producto con la informacion de cada uno de 
        /// los campos de la tabla Producto</returns>

        public List<Producto> GetAllProducto()
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.GetAllProducto();
        }

        /// <summary>
        /// Método que retorna una lista de objetos Producto, con la informacion que 
        /// contiene la tabla Producto en la base de datos siempre y cuando, el campo
        /// descripcion coincida con el parametro
        /// </summary>
        /// <param name="pDescripcion">string que contiene la descripcion a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos Producto con la informacion de la tabla 
        /// Producto cuyo campo descripcion haya coincidido con el parametro</returns>

        public List<Producto> GetProductoByFilter(string pDescripcion)
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.GetProductoByFilter(pDescripcion);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Producto con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Producto con la informacion de la tabla 
        /// Producto cuyo campo id haya coincidido con el parametro</returns>

        public Producto GetProductoById(double pId)
        {
            IDALProducto _DALProducto = new DALProducto();

            return _DALProducto.GetProductoById(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Producto
        /// como un campo de la tabla Producto en la base de datos
        /// </summary>
        /// <param name="pProducto">instancia de la clase Producto que sera almacenada
        /// en la base de datos</param>

        public void SaveProducto(Producto pProducto)
        {
            IDALProducto _DALProducto = new DALProducto();

            _DALProducto.SaveProducto(pProducto);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Producto en la base de datos con la
        /// informacion que contiene la instancia de la clase Producto en el parametro
        /// </summary>
        /// <param name="pProducto">instancia de la clase Producto cuya informacion
        /// se utilizara para actualizar un campo en la tabla Producto</param>

        public void UpdateProducto(Producto pProducto)
        {
            IDALProducto _DALProducto = new DALProducto();

            _DALProducto.UpdateProducto(pProducto);
        }
    }
}
