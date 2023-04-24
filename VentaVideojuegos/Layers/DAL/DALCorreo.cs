using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Interfaces;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase DALCorreo que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Correo de la base de datos
    /// </summary>

    class DALCorreo : IDALCorreo
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALCorreo()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Correo   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteCorreo(string pId, string pCorreo)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_CORREO_ByID";
                    command.Parameters.AddWithValue(@"CORREO", pCorreo);
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pId));

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
        /// en la tabla Correo de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Correo con la informacion de cada uno de 
        /// los campos de la tabla Correo</returns>

        public List<Correo> GetAllCorreo()
        {
            DataSet ds = null;
            List<Correo> lista = new List<Correo>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_CORREO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Correo correo = new Correo()
                        {
                            CorreoElectronico = dr["CORREO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(correo);
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
            DataSet ds = null;
            List<Correo> lista = new List<Correo>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"CORREO", pCorreo);
                    command.CommandText = "PA_SELECT_CORREO_Filter";
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Correo correo = new Correo()
                        {
                            CorreoElectronico = dr["CORREO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(correo);
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
        /// Metodo que retorna una instancia de la clase Correo con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Correo con la informacion de la tabla 
        /// Correo cuyo campo id haya coincidido con el parametro</returns>

        public List<Correo> GetCorreoByIdCliente(string pId)
        {
            DataSet ds = null;
            List<Correo> lista = new List<Correo>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_CORREO_ByID";
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pId));

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Correo correo = new Correo()
                        {
                            CorreoElectronico = dr["CORREO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(correo);
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
        /// Metodo que almacena la informacion de una instancia de la clase Correo
        /// como un campo de la tabla Correo en la base de datos
        /// </summary>
        /// <param name="correo">instancia de la clase Correo que sera almacenada
        /// en la base de datos</param>

        public void SaveCorreo(Correo correo)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_CORREO";
                    command.Parameters.AddWithValue(@"CORREO", correo.CorreoElectronico);
                    command.Parameters.AddWithValue(@"ID_CLIENTE", correo.IdCliente);

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
        /// Metodo que actualiza un campo de la tabla Correo en la base de datos con la
        /// informacion que contiene la instancia de la clase Correo en el parametro
        /// </summary>
        /// <param name="correo">instancia de la clase Correo cuya informacion
        /// se utilizara para actualizar un campo en la tabla Cliente</param>
        /// <param name="pCorreoViejo">string que contiene el correo que se desea
        /// actualizar</param>
        /// <param name="pIdClienteViejo">string que contiene el id del cliente que se desea
        /// actualizar</param>

        public void UpdateCorreo(Correo correo, string pCorreoViejo, string pIdClienteViejo)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_CORREO";
                    command.Parameters.AddWithValue(@"CORREO_VIEJO", pCorreoViejo);
                    command.Parameters.AddWithValue(@"ID_CLIENTE_VIEJO", Convert.ToInt64(pIdClienteViejo));
                    command.Parameters.AddWithValue(@"CORREO_NUEVO", correo.CorreoElectronico);
                    command.Parameters.AddWithValue(@"ID_CLIENTE_NUEVO", correo.IdCliente);

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
