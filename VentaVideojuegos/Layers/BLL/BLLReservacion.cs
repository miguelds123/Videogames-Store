using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.BLL
{
    /// <summary>
    /// Clase BLLReservacion que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Reservacion de la base de datos
    /// </summary>

    class BLLReservacion : IBLLReservacion
    {
        /// <summary>
        /// Método que elimina un determinado campo en la tabla Reservacion   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteReservacion(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            _DALReservacion.DeleteReservacion(pId);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Reservacion de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Reservacion con la informacion de cada uno de 
        /// los campos de la tabla Reservacion</returns>

        public List<Reservacion> GetAllReservacion()
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetAllReservacion();
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Reservacion con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Reservacion con la informacion de la tabla 
        /// Reservacion cuyo campo id haya coincidido con el parametro</returns>

        public Reservacion GetReservacionById(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetReservacionById(pId);
        }

        /// <summary>
        /// Metodo que retorna lista de objetos de la clase Reservacion con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos de la clase Reservacion con la informacion de la tabla 
        /// Reservacion cuyo campo id haya coincidido con el parametro</returns>

        public List<Reservacion> GetReservacionByIdCliente(string pId)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetReservacionByIdCliente(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Reservacion
        /// como un campo de la tabla Reservacion en la base de datos
        /// </summary>
        /// <param name="pReservacion">instancia de la clase Reservacion que sera almacenada
        /// en la base de datos</param>

        public void SaveReservacion(Reservacion pReservacion)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            _DALReservacion.SaveReservacion(pReservacion);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Reservacion en la base de datos con la
        /// informacion que contiene la instancia de la clase Reservacion en el parametro
        /// </summary>
        /// <param name="pReservacion">instancia de la clase Reservacion cuya informacion
        /// se utilizara para actualizar un campo en la tabla Reservacion</param>

        public void UpdateReservacion(Reservacion pReservacion)
        {
            IDALReservacion _DALReservacion = new DALReservacion();

            _DALReservacion.UpdateReservacion(pReservacion);
        }

        /// <summary>
        /// Metodo que obtiene de la base de datos el numero actual de la secuencia 
        /// NoReservacion
        /// </summary>
        /// <returns>un int con el numero actual en el que se encuentra la secuencia</returns>

        public int GetCurrentNumeroReservacion()
        {
            DALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetCurrentNumeroReservacion();
        }

        /// <summary>
        /// Metodo que obtiene de la base de datos el siguiente numero de la secuencia 
        /// NoReservacion
        /// </summary>
        /// <returns>un int con el siguiente numero en el que se encuentra la secuencia</returns>

        public int GetNextNumeroReservacion()
        {
            DALReservacion _DALReservacion = new DALReservacion();

            return _DALReservacion.GetNextNumeroReservacion();
        }
    }
}
