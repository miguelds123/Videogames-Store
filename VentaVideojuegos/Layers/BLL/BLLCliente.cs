using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLCliente que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Cliente de la base de datos
    /// </summary>

    class BLLCliente : IBLLCliente
    {
        /// <summary>
        /// Metodo que se utiliza para actualizar el Estado de un campo de la tabla 
        /// Cliente en la base de datos
        /// </summary>
        /// <param name="pId">string que contiene el id del campo que se va a 
        /// actualizar en la base de datos</param>

        public void BorradoLogico(string pId)
        {
            IDALCliente _DALCliente = new DALCliente();

            _DALCliente.BorradoLogico(pId);
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Cliente   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteCliente(string pId)
        {
            IDALCliente _DALCliente= new DALCliente();

            _DALCliente.DeleteCliente(pId);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Cliente de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Cliente con la informacion de cada uno de 
        /// los campos de la tabla Cliente</returns>

        public List<Cliente> GetAllCliente()
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.GetAllCliente();
        }

        /// <summary>
        /// Método que retorna una lista de objetos Cliente, con la informacion que 
        /// contiene la tabla Cliente en la base de datos siempre y cuando, el campo
        /// descripcion coincida con el parametro
        /// </summary>
        /// <param name="pDescripcion">string que contiene la descripcion a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos Cliente con la informacion de la tabla 
        /// Cliente cuyo campo descripcion haya coincidido con el parametro</returns>

        public List<Cliente> GetClienteByFilter(string pDescripcion)
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.GetClienteByFilter(pDescripcion);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Cliente con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Cliente con la informacion de la tabla 
        /// Cliente cuyo campo id haya coincidido con el parametro</returns>

        public Cliente GetClienteById(string pId)
        {
            IDALCliente _DALCliente = new DALCliente();

            return _DALCliente.GetClienteById(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Cliente
        /// como un campo de la tabla Cliente en la base de datos
        /// </summary>
        /// <param name="pCliente">instancia de la clase Cliente que sera almacenada
        /// en la base de datos</param>

        public void SaveCliente(Cliente pCliente)
        {
            IDALCliente _DALCliente = new DALCliente();

            _DALCliente.SaveCliente(pCliente);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Cliente en la base de datos con la
        /// informacion que contiene la instancia de la clase Cliente en el parametro
        /// </summary>
        /// <param name="pCliente">instancia de la clase Cliente cuya informacion
        /// se utilizara para actualizar un campo en la tabla Cliente</param>

        public void UpdateCliente(Cliente pCliente)
        {
            IDALCliente _DALCliente = new DALCliente();

            _DALCliente.UpdateCliente(pCliente);
        }
    }
}
