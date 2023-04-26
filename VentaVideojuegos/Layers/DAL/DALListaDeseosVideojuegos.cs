using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase DALListaDeseosVideojuego que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla ListaDeseosVideojuego de la base de datos
    /// </summary>

    class DALListaDeseosVideojuegos
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALListaDeseosVideojuegos()
        {
            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla ListaDeseosVideojuego   
        /// </summary>
        /// <param name="pIdCliente">string que contiene el id cliente del campo a eliminar</param>
        /// <param name="pIdProducto">string que contiene el id producto del campo a eliminar</param>

        public void DeleteListaDeseosVideojuego(string pIdCliente, string pIdProducto)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_LISTA_DESEOS_VIDEOJUEGO_ByID";
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pIdCliente));
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", Convert.ToInt64(pIdProducto));

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
        /// en la tabla ListaDeseosVideojuegos de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos ListaDeseos con la informacion de cada uno de 
        /// los campos de la tabla ListaDeseosVideojuegos</returns>

        public List<ListaDeseos> GetAllListaDeseosVideojuego()
        {
            DataSet ds = null;
            List<ListaDeseos> lista = new List<ListaDeseos>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_LISTA_DESEOS_VIDEOJUEGO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ListaDeseos listaDeseos = new ListaDeseos()
                        {
                            IdCliente = (int)dr["ID_CLIENTE"],
                            IdProducto = (int)dr["ID_PRODUCTO"]
                        };
                        lista.Add(listaDeseos);
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
            DataSet ds = null;
            ListaDeseos listaDeseos = null;
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pIdCliente));
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", Convert.ToInt64(pIdProducto));
                    command.CommandText = "PA_SELECT_LISTA_DESEOS_VIDEOJUEGO";
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    listaDeseos = new ListaDeseos()
                    {
                        IdCliente = (int)dr["ID_CLIENTE"],
                        IdProducto = (int)dr["ID_PRODUCTO"]
                    };
                }
                return listaDeseos;
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
            DataSet ds = null;
            ListaDeseos listaDeseos = null;
            List<ListaDeseos> lista = new List<ListaDeseos>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_LISTA_DESEOS_VIDEOJUEGO_ByIdCliente";
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt32(pId));

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaDeseos = new ListaDeseos()
                        {
                            IdCliente = (int)dr["ID_CLIENTE"],
                            IdProducto = (int)dr["ID_PRODUCTO"]
                        };
                        lista.Add(listaDeseos);
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
            DataSet ds = null;
            ListaDeseos listaDeseos = null;
            List<ListaDeseos> lista = new List<ListaDeseos>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_LISTA_DESEOS_VIDEOJUEGO_ByIdProducto";
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", Convert.ToInt64(pId));
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        listaDeseos = new ListaDeseos()
                        {
                            IdCliente = (int)dr["ID_CLIENTE"],
                            IdProducto = (int)dr["ID_PRODUCTO"]
                        };
                        lista.Add(listaDeseos);
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
        /// Metodo que almacena la informacion de una instancia de la clase ListaDeseos
        /// como un campo de la tabla ListaDeseosVideojuego en la base de datos
        /// </summary>
        /// <param name="pListaDeseos">instancia de la clase ListaDeseos que sera almacenada
        /// en la base de datos</param>

        public void SaveListaDeseosVideojuegos(ListaDeseos pListaDeseos)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_LISTA_DESEOS_VIDEOJUEGO";
                    command.Parameters.AddWithValue(@"ID_CLIENTE", pListaDeseos.IdCliente);
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", pListaDeseos.IdProducto);

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
        /// Metodo que actualiza un campo de la tabla ListaDeseos en la base de datos con la
        /// informacion que contiene la instancia de la clase ListaDeseosVideojuego en el parametro
        /// </summary>
        /// <param name="pListaDeseos">instancia de la clase ListaDeseos cuya informacion
        /// se utilizara para actualizar un campo en la tabla ListaDeseos</param>

        public void UpdateListaDeseosVideojuego(ListaDeseos pListaDeseos)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_LISTA_DESEOS_VIDEOJUEGO";
                    command.Parameters.AddWithValue(@"ID_CLIENTE", pListaDeseos.IdCliente);
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", pListaDeseos.IdProducto);

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
    }
}
