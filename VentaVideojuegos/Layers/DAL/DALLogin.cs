using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase DALLogin que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Usuario y con ella permitir a los usuarios 
    /// del programa iniciar sesion con su cuenta
    /// </summary>

    internal class DALLogin : IDALLogin
    {
        Usuario _UsuarioBD = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALLogin()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _UsuarioBD.Login = "sa";
            _UsuarioBD.Password = "123456";
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Usuario   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteUsuario(string pId)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_USUARIO";
                    command.Parameters.AddWithValue("USUARIO", pId);

                    db.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Usuario de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Usuario con la informacion de cada uno de 
        /// los campos de la tabla Usuario</returns>

        public List<Usuario> GetAllUsuario()
        {
            DataSet ds = null;
            List<Usuario> lista = new List<Usuario>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_USUARIO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Login= dr["USUARIO"].ToString();
                        usuario.Password = dr["PASSWORD"].ToString();
                        usuario.IdCategoria = (int)dr["ID_CATEGORIA"];
                        usuario.IMAGEN = (byte[])dr["IMAGEN"];

                        lista.Add(usuario);
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return null;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return null;
            }
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
            DataSet ds = null;
            Usuario usuario = new Usuario();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"USUARIO", pDescripcion);
                    command.CommandText = "PA_SELECT_USUARIO_ByUsuario";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        usuario.Login = dr["USUARIO"].ToString();
                        usuario.Password = dr["PASSWORD"].ToString();
                        usuario.IdCategoria = (int)dr["ID_CATEGORIA"];
                        usuario.IMAGEN = (byte[])dr["IMAGEN"];
                    }
                }
                return usuario;
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return null;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return null;
            }
        }

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Usuario
        /// como un campo de la tabla Usuario en la base de datos
        /// </summary>
        /// <param name="pUsuario">instancia de la clase Usuario que sera almacenada
        /// en la base de datos</param>

        public void SaveUsuario(Usuario pUsuario)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_USUARIO";
                    command.Parameters.AddWithValue(@"USUARIO", pUsuario.Login);
                    command.Parameters.AddWithValue(@"PASSWORD", pUsuario.Password);
                    command.Parameters.AddWithValue(@"ID_CATEGORIA", pUsuario.IdCategoria);
                    command.Parameters.AddWithValue(@"IMAGEN", pUsuario.IMAGEN);

                    db.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Usuario en la base de datos con la
        /// informacion que contiene la instancia de la clase Usuario en el parametro
        /// </summary>
        /// <param name="pUsuario">instancia de la clase Usuario cuya informacion
        /// se utilizara para actualizar un campo en la tabla Usuario</param>

        public void UpdateUsuario(Usuario pUsuario)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_USUARIO";
                    command.Parameters.AddWithValue(@"USUARIO", pUsuario.Login);
                    command.Parameters.AddWithValue(@"PASSWORD", pUsuario.Password);
                    command.Parameters.AddWithValue(@"ID_CATEGORIA", pUsuario.IdCategoria);
                    command.Parameters.AddWithValue(@"IMAGEN", pUsuario.IMAGEN);

                    db.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
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
            List<Usuario> lista= new List<Usuario>();
            bool resultado= false;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {
                    lista = GetAllUsuario();

                    foreach (Usuario usuario in lista)
                    {
                        if (usuario.Login.Equals(pUsuario) && usuario.Password.Equals(pContrasena))
                        {
                            resultado = true;
                        }
                    }
                }

                return resultado;
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return false;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return false;
            }
        }
    }
}
