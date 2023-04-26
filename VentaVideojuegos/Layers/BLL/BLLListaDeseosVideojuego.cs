using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.BLL
{
    /// <summary>
    /// Clase BLLListaDeseosVideojuego que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla ListaDeseosVideojuego de la base de datos
    /// </summary>

    class BLLListaDeseosVideojuego
    {
        /// <summary>
        /// Método que elimina un determinado campo en la tabla ListaDeseosVideojuego   
        /// </summary>
        /// <param name="pIdCliente">string que contiene el id cliente del campo a eliminar</param>
        /// <param name="pIdProducto">string que contiene el id producto del campo a eliminar</param>

        public void DeleteListaDeseosVideojuego(string pIdCliente, string pIdProducto)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego= new DALListaDeseosVideojuegos();

            _DALListaDeseosVideojuego.DeleteListaDeseosVideojuego(pIdCliente, pIdProducto);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla ListaDeseosVideojuegos de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos ListaDeseos con la informacion de cada uno de 
        /// los campos de la tabla ListaDeseosVideojuegos</returns>

        public List<ListaDeseos> GetAllListaDeseosVideojuego()
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetAllListaDeseosVideojuego();
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
        /// ListaDeseosVideojuegos cuyos campos id hayan coincidido con el parametro</returns>

        public ListaDeseos GetListaDeseosVideojuego(string pIdCliente, string pIdProducto)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetListaDeseosVideojuego(pIdCliente, pIdProducto);
        }

        /// <summary>
        /// Metodo que retorna una lista de objetos de la clase ListaDeseos con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id cliente a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase ListaDeseos con la informacion de la tabla 
        /// ListaDeseosVideojuegos cuyos campos id hayan coincidido con el parametro</returns>

        public List<ListaDeseos> GetListaDeseosVideojuegoByIdCliente(string pId)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetListaDeseosVideojuegoByIdCliente(pId);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase ListaDeseos con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id producto a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase ListaDeseos con la informacion de la tabla 
        /// ListaDeseosVideojuegos cuyos campos id hayan coincidido con el parametro</returns>

        public List<ListaDeseos> GetListaDeseosVideojuegoByIdProducto(string pId)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            return _DALListaDeseosVideojuego.GetListaDeseosVideojuegoByIdProducto(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase ListaDeseos
        /// como un campo de la tabla ListaDeseosVideojuego en la base de datos
        /// </summary>
        /// <param name="pListaDeseos">instancia de la clase ListaDeseos que sera almacenada
        /// en la base de datos</param>

        public void SaveListaDeseosVideojuegos(ListaDeseos pListaDeseos)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            _DALListaDeseosVideojuego.SaveListaDeseosVideojuegos(pListaDeseos);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla ListaDeseos en la base de datos con la
        /// informacion que contiene la instancia de la clase ListaDeseosVideojuego en el parametro
        /// </summary>
        /// <param name="pListaDeseos">instancia de la clase ListaDeseos cuya informacion
        /// se utilizara para actualizar un campo en la tabla ListaDeseos</param>

        public void UpdateListaDeseosVideojuego(ListaDeseos pListaDeseos)
        {
            DALListaDeseosVideojuegos _DALListaDeseosVideojuego = new DALListaDeseosVideojuegos();

            _DALListaDeseosVideojuego.UpdateListaDeseosVideojuego(pListaDeseos);
        }
    }
}
