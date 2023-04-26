using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLCorreo que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Correo de la base de datos
    /// </summary>

    class BLLCorreo : IBLLCorreo
    {
        /// <summary>
        /// Método que elimina un determinado campo en la tabla Correo   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteCorreo(string pId, string pCorreo)
        {
            IDALCorreo _DALCorreo= new DALCorreo();

            _DALCorreo.DeleteCorreo(pId, pCorreo);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Correo de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Correo con la informacion de cada uno de 
        /// los campos de la tabla Correo</returns>

        public List<Correo> GetAllCorreo()
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            return _DALCorreo.GetAllCorreo();
        }

        /// <summary>
        /// Método que retorna una lista de objetos Correo, con la informacion que 
        /// contiene la tabla Correo en la base de datos siempre y cuando, el campo
        /// correo coincida con el parametro
        /// </summary>
        /// <param name="pCorreo">string que contiene el correo a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos Correo con la informacion de la tabla 
        /// Correo cuyo campo correo haya coincidido con el parametro</returns>

        public List<Correo> GetCorreoByFilter(string pCorreo)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            return _DALCorreo.GetCorreoByFilter(pCorreo);
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Correo con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase Correo con la informacion de la tabla 
        /// Correo cuyo campo id haya coincidido con el parametro</returns>

        public List<Correo> GetCorreoByIdCliente(string pId)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            return _DALCorreo.GetCorreoByIdCliente(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Correo
        /// como un campo de la tabla Correo en la base de datos
        /// </summary>
        /// <param name="correo">instancia de la clase Correo que sera almacenada
        /// en la base de datos</param>

        public void SaveCorreo(Correo correo)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            _DALCorreo.SaveCorreo(correo);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Correo en la base de datos con la
        /// informacion que contiene la instancia de la clase Correo en el parametro
        /// </summary>
        /// <param name="correo">instancia de la clase Correo cuya informacion
        /// se utilizara para actualizar un campo en la tabla Correo</param>
        /// <param name="pCorreoViejo">string que contiene el correo que se desea
        /// actualizar</param>
        /// <param name="pIdClienteViejo">string que contiene el id del cliente que se desea
        /// actualizar</param>

        public void UpdateCorreo(Correo correo, string pCorreoViejo, string pIdClienteViejo)
        {
            IDALCorreo _DALCorreo = new DALCorreo();

            _DALCorreo.UpdateCorreo(correo, pCorreoViejo, pIdClienteViejo);
        }
    }
}
