using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLTelefono que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Telefono de la base de datos
    /// </summary>

    class BLLTelefono : IBLLTelefono
    {
        /// <summary>
        /// Método que elimina un determinado campo en la tabla Telefono   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteTelefono(string pId, string pTelefono)
        {
            IDALTelefono _DALTelefono= new DALTelefono();

            _DALTelefono.DeleteTelefono(pId, pTelefono);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Telefono de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Telefono con la informacion de cada uno de 
        /// los campos de la tabla Telefono</returns>

        public List<Telefono> GetAllTelefono()
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.GetAllTelefono();
        }

        /// <summary>
        /// Método que retorna una lista de objetos Telefono, con la informacion que 
        /// contiene la tabla Telefono en la base de datos siempre y cuando, el campo
        /// telefono coincida con el parametro
        /// </summary>
        /// <param name="pNumeroTelefono">string que contiene el telefono a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos Telefono con la informacion de la tabla 
        /// Telefono cuyo campo telefono haya coincidido con el parametro</returns>

        public List<Telefono> GetTelefonoByFilter(string pNumeroTelefono)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.GetTelefonoByFilter(pNumeroTelefono);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Telefono con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase Telefono con la informacion de la tabla 
        /// Telefono cuyo campo id haya coincidido con el parametro</returns>

        public List<Telefono> GetTelefonoByIdCliente(string pId)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            return _DALTelefono.GetTelefonoByIdCliente(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Telefono
        /// como un campo de la tabla Telefono en la base de datos
        /// </summary>
        /// <param name="pTelefono">instancia de la clase Telefono que sera almacenada
        /// en la base de datos</param>

        public void SaveTelefono(Telefono pTelefono)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            _DALTelefono.SaveTelefono(pTelefono);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Telefono en la base de datos con la
        /// informacion que contiene la instancia de la clase Telefono en el parametro
        /// </summary>
        /// <param name="pTelefono">instancia de la clase Telefono cuya informacion
        /// se utilizara para actualizar un campo en la tabla Telefono</param>
        /// <param name="pTelefonoViejo">string que contiene el telefono que se desea
        /// actualizar</param>
        /// <param name="pIdClienteViejo">string que contiene el id del cliente que se desea
        /// actualizar</param>

        public void UpdateTelefono(Telefono pTelefono, string pTelefonoViejo, string pIdClienteViejo)
        {
            IDALTelefono _DALTelefono = new DALTelefono();

            _DALTelefono.UpdateTelefono(pTelefono, pTelefonoViejo, pIdClienteViejo);
        }
    }
}
