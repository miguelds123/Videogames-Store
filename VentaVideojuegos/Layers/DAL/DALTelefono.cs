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
    /// Clase DALTelefono que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Telefono de la base de datos
    /// </summary>

    class DALTelefono : IDALTelefono
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALTelefono()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Telefono   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteTelefono(string pId, string pTelefono)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_TELEFONO";
                    command.Parameters.AddWithValue(@"TELEFONO", pTelefono);
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt32(pId));

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
        /// en la tabla Telefono de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Telefono con la informacion de cada uno de 
        /// los campos de la tabla Telefono</returns>

        public List<Telefono> GetAllTelefono()
        {
            DataSet ds = null;
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_TELEFONO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono()
                        {
                            Numero = dr["TELEFONO"].ToString(),
                            IdCliente= (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(telefono);
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
            DataSet ds = null;
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"TELEFONO", pNumeroTelefono);
                    command.CommandText = "PA_SELECT_TELEFONO_ByFilter";
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono()
                        {
                            Numero = dr["TELEFONO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(telefono);
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
            DataSet ds = null;
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_TELEFONO_ByID";
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pId));

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono()
                        {
                            Numero = dr["TELEFONO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(telefono);
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
        /// Metodo que almacena la informacion de una instancia de la clase Telefono
        /// como un campo de la tabla Telefono en la base de datos
        /// </summary>
        /// <param name="pTelefono">instancia de la clase Telefono que sera almacenada
        /// en la base de datos</param>

        public void SaveTelefono(Telefono pTelefono)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_TELEFONO";
                    command.Parameters.AddWithValue(@"TELEFONO", pTelefono.Numero);
                    command.Parameters.AddWithValue(@"ID_CLIENTE", pTelefono.IdCliente);

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
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_TELEFONO";
                    command.Parameters.AddWithValue(@"TelefonoNuevo", pTelefono.Numero);
                    command.Parameters.AddWithValue(@"IdClienteNuevo", pTelefono.IdCliente);
                    command.Parameters.AddWithValue(@"TelefonoViejo", pTelefonoViejo);
                    command.Parameters.AddWithValue(@"IdClienteViejo", Convert.ToInt64(pIdClienteViejo));

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
