using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLVideojuego que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Videojuego de la base de datos
    /// </summary>

    class BLLVideojuego
    {
        /// <summary>
        /// Metodo que se utiliza para actualizar el Estado de un campo de la tabla 
        /// Videojuego en la base de datos
        /// </summary>
        /// <param name="pID">string que contiene el id del campo que se va a 
        /// actualizar en la base de datos</param>

        public void BorradoLogico(int pID)
        {
            DALVideojuego _DALVideojuego= new DALVideojuego();

            _DALVideojuego.BorradoLogico(pID);
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Videojuego   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteVideojuego(double pId)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            _DALVideojuego.DeleteVideojuego(pId);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Videojuego de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Videojuego con la informacion de cada uno de 
        /// los campos de la tabla Videojuego</returns>

        public List<Videojuego> GetAllVideojuego()
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            return _DALVideojuego.GetAllVideojuego();
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Videojuego con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Videojuego con la informacion de la tabla 
        /// Videojuego cuyo campo id haya coincidido con el parametro</returns>

        public Videojuego GetVideojuegoById(double pId)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            return _DALVideojuego.GetVideojuegoById(pId);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Videojuego
        /// como un campo de la tabla Videojuego en la base de datos
        /// </summary>
        /// <param name="pVideojuego">instancia de la clase Videojuego que sera almacenada
        /// en la base de datos</param>

        public void SaveVideojuego(Videojuego pVideojuego)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            _DALVideojuego.SaveVideojuego(pVideojuego);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Videojuego en la base de datos con la
        /// informacion que contiene la instancia de la clase Videojuego en el parametro
        /// </summary>
        /// <param name="pVideojuego">instancia de la clase Videojuego cuya informacion
        /// se utilizara para actualizar un campo en la tabla Videojuego</param>

        public void UpdateVideojuego(Videojuego pVideojuego)
        {
            DALVideojuego _DALVideojuego = new DALVideojuego();

            _DALVideojuego.UpdateVideojuego(pVideojuego);
        }
    }
}
