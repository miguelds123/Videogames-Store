using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase BLLLogin que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Usuario y con ella permitir a los usuarios 
    /// del programa iniciar sesion con su cuenta
    /// </summary>

    class BLLLogin : IBLLLogin
    {
        IDALLogin _DALLogin= new DALLogin();

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Usuario   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteUsuario(string pId)
        {
            _DALLogin.DeleteUsuario(pId);
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Usuario de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Usuario con la informacion de cada uno de 
        /// los campos de la tabla Usuario</returns>

        public List<Usuario> GetAllUsuario()
        {
            return _DALLogin.GetAllUsuario();
        }

        /// <summary>
        /// Metodo que retorna una instancia de la clase Usuario con la informacion 
        /// que contiene el campo de la base de datos que coinicide con la descripcion 
        /// del parametro
        /// </summary>
        /// <param name="pDescripcion">string que contiene la descripcion del usuario 
        /// a buscar en la base de datos</param>
        /// <returns>Una instancia de la clase Usaurio con la informacion de la tabla 
        /// Usuario cuyo campo descripcion haya coincidido con el parametro</returns>

        public Usuario GetUsuarioByFilter(string pDescripcion)
        {
            return _DALLogin.GetUsuarioByFilter(pDescripcion);
        }

        /// <summary>
        /// Metodo que permite a los usuarios iniciar sesion con su usuario y 
        /// contraseña
        /// </summary>
        /// <param name="pUsuario">string que contiene el usuario</param>
        /// <param name="pContrasena">string que contiene la contraseña</param>
        /// <returns>Un valor booleano que indica si el usuario y la contraseña
        /// fueron encontrados en la base de datos</returns>

        public bool Login(string pUsuario, string pContrasena)
        {
            return _DALLogin.Login(pUsuario, pContrasena);
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Usuario
        /// como un campo de la tabla Usuario en la base de datos
        /// </summary>
        /// <param name="pUsuario">instancia de la clase Usuario que sera almacenada
        /// en la base de datos</param>

        public void SaveUsuario(Usuario pUsuario)
        {
            _DALLogin.SaveUsuario(pUsuario);
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Usuario en la base de datos con la
        /// informacion que contiene la instancia de la clase Usuario en el parametro
        /// </summary>
        /// <param name="pUsuario">instancia de la clase Usuario cuya informacion
        /// se utilizara para actualizar un campo en la tabla Usuario</param>

        public void UpdateUsuario(Usuario pUsuario)
        {
            _DALLogin.UpdateUsuario(pUsuario);
        }
    }
}
