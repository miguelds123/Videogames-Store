using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Properties;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase DALReservacion que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Reservacion de la base de datos
    /// </summary>

    class DALReservacion : IDALReservacion
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALReservacion()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Reservacion   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteReservacion(string pId)
        {
            Reservacion reservacion= null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reservacion = GetReservacionById(pId);

                    commandReservacion.CommandType = System.Data.CommandType.StoredProcedure;
                    commandReservacion.CommandText = "PA_DELETE_RESERVACION_ByID";
                    commandReservacion.Parameters.AddWithValue("@ID", Convert.ToInt64(pId));
                    listaCommands.Add(commandReservacion);

                    commandProducto.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProducto.CommandText = "PA_AUMENTAR_CANTIDAD_PRODUCTO";
                    commandProducto.Parameters.AddWithValue("@ID", Convert.ToInt64(pId));
                    listaCommands.Add(commandProducto);

                    foreach (SqlCommand command in listaCommands)
                    {
                        db.ExecuteNonQuery(command);
                    }
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
        /// en la tabla Reservacion de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Reservacion con la informacion de cada uno de 
        /// los campos de la tabla Reservacion</returns>

        public List<Reservacion> GetAllReservacion()
        {
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_RESERVACION_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Reservacion reservacion = new Reservacion()
                        {
                            ID = (int)dr["ID"],
                            IdCliente = (int)dr["ID_CLIENTE"],
                            IdProducto = (int)dr["ID_PRODUCTO"],
                            Adelanto = (double)dr["ADELANTO"]
                        };
                        lista.Add(reservacion);
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
            DataSet ds = null;
            Reservacion reservacion = null;
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_RESERVACION_ByID";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        reservacion = new Reservacion()
                        {
                            ID = (int)dr["ID"],
                            IdCliente = (int)dr["ID_CLIENTE"],
                            IdProducto = (int)dr["ID_PRODUCTO"],
                            Adelanto = (double)dr["ADELANTO"]
                        };
                    }
                }
                return reservacion;
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
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_RESERVACION_ByIdCliente";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Reservacion reservacion = new Reservacion()
                        {
                            ID = (int)dr["ID"],
                            IdCliente = (int)dr["ID_CLIENTE"],
                            IdProducto = (int)dr["ID_PRODUCTO"],
                            Adelanto = (double)dr["ADELANTO"]
                        };
                        lista.Add(reservacion);
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
        /// Metodo que almacena la informacion de una instancia de la clase Reservacion
        /// como un campo de la tabla Reservacion en la base de datos
        /// </summary>
        /// <param name="pReservacion">instancia de la clase Reservacion que sera almacenada
        /// en la base de datos</param>

        public void SaveReservacion(Reservacion pReservacion)
        {
            Reservacion reservacion= null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //realiza el insert de la reservacion

                    commandReservacion.CommandType = System.Data.CommandType.StoredProcedure;
                    commandReservacion.CommandText = "PA_INSERT_RESERVACION";
                    commandReservacion.Parameters.AddWithValue(@"ID", pReservacion.ID);
                    commandReservacion.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                    commandReservacion.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                    commandReservacion.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);
                    listaCommands.Add(commandReservacion);

                    //rebaja la cantidad de inventario en base a la cantidad de producto que se
                    //compraron

                    commandProducto.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProducto.CommandText = "PA_DISMINUIR_CANTIDAD_PRODUCTO";
                    commandProducto.Parameters.AddWithValue("@ID", pReservacion.IdProducto);
                    listaCommands.Add(commandProducto);

                    foreach (SqlCommand command in listaCommands)
                    {
                        db.ExecuteNonQuery(command);
                    }
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
        /// Metodo que actualiza un campo de la tabla Reservacion en la base de datos con la
        /// informacion que contiene la instancia de la clase Reservacion en el parametro
        /// </summary>
        /// <param name="pReservacion">instancia de la clase Reservacion cuya informacion
        /// se utilizara para actualizar un campo en la tabla Reservacion</param>

        public void UpdateReservacion(Reservacion pReservacion)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_RESERVACION";
                    command.Parameters.AddWithValue(@"ID", pReservacion.ID);
                    command.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                    command.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);

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
        /// Metodo que obtiene de la base de datos el numero actual de la secuencia 
        /// NoReservacion
        /// </summary>
        /// <returns>un int con el numero actual en el que se encuentra la secuencia</returns>

        public int GetCurrentNumeroReservacion()
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand();
            int numeroFactura = 0;

            DataTable dt = null;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GetCurrentNumeroReservacion";

                    ds = db.ExecuteDataSet(command);
                }

                dt = ds.Tables[0];

                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return 0;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return 0;
            }
        }

        /// <summary>
        /// Metodo que obtiene de la base de datos el siguiente numero de la secuencia 
        /// NoReservacion
        /// </summary>
        /// <returns>un int con el siguiente numero en el que se encuentra la secuencia</returns>

        public int GetNextNumeroReservacion()
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand();

            int numeroFactura = 0;

            DataTable dt = null;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GetNextNumeroReservacion";

                    ds = db.ExecuteDataSet(command);
                }

                dt = ds.Tables[0];

                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
            }
            catch (SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return 0;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return 0;
            }
        }
    }
}
