using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLListaDeseos que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla ListaDeseos de la base de datos
    /// </summary>

    class BLLListaDeseos : IBLLListaDeseos
    {
        /// <summary>
        /// Método que elimina un determinado campo en la tabla ListaDeseos   
        /// </summary>
        /// <param name="pIdCliente">string que contiene el id cliente del campo a eliminar</param>
        /// <param name="pIdProducto">string que contiene el id producto del campo a eliminar</param>

        public void DeleteListaDeseos(string pIdCliente, string pIdProducto)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            _DALListaDeseos.DeleteListaDeseos(pIdCliente, pIdProducto);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla ListaDeseos de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos ListaDeseos con la informacion de cada uno de 
        /// los campos de la tabla ListaDeseos</returns>

        public List<ListaDeseos> GetAllListaDeseos()
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetAllListaDeseos();
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase ListaDeseos con la informacion 
        /// que contiene el campo de la base de datos que coinicide con los id de los
        /// parametros
        /// </summary>
        /// <param name="pIdCliente">string que contiene el id cliente a buscar
        /// en la base de datos</param>
        /// <param name="pIdProducto">string que contiene el id producto a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase ListaDeseos con la informacion de la tabla 
        /// ListaDeseos cuyos campos id hayan coincidido con el parametro</returns>

        public ListaDeseos GetListaDeseos(string pIdCliente, string pIdProducto)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetListaDeseos(pIdCliente, pIdProducto);
        }

        /// <summary>
        /// Metodo que retorna lista de objetos de la clase ListaDeseos con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id cliente a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase ListaDeseos con la informacion de la tabla 
        /// ListaDeseos cuyos campos id hayan coincidido con el parametro</returns>

        public List<ListaDeseos> GetListaDeseosByIdCliente(string pId)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetListaDeseosByIdCliente(pId);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase ListaDeseos con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id producto a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase ListaDeseos con la informacion de la tabla 
        /// ListaDeseos cuyos campos id hayan coincidido con el parametro</returns>

        public List<ListaDeseos> GetListaDeseosByIdProducto(string pId)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            return _DALListaDeseos.GetListaDeseosByIdProducto(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase ListaDeseos
        /// como un campo de la tabla ListaDeseos en la base de datos
        /// </summary>
        /// <param name="pListaDeseos">instancia de la clase ListaDeseos que sera almacenada
        /// en la base de datos</param>

        public void SaveListaDeseos(ListaDeseos pListaDeseos)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            _DALListaDeseos.SaveListaDeseos(pListaDeseos);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla ListaDeseos en la base de datos con la
        /// informacion que contiene la instancia de la clase ListaDeseos en el parametro
        /// </summary>
        /// <param name="pListaDeseos">instancia de la clase ListaDeseos cuya informacion
        /// se utilizara para actualizar un campo en la tabla ListaDeseos</param>

        public void UpdateListaDeseos(ListaDeseos pListaDeseos)
        {
            IDAListaDeseos _DALListaDeseos = new DALListaDeseos();

            _DALListaDeseos.UpdateListaDeseos(pListaDeseos);
        }
    }
}
