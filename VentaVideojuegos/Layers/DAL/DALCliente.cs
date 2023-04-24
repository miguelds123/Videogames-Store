using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Properties;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase DALCliente que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Cliente de la base de datos
    /// </summary>

    class DALCliente : IDALCliente
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALCliente()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Cliente   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteCliente(string pId)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_CLIENTE";
                    command.Parameters.AddWithValue("@ID", Convert.ToInt64(pId));

                    db.ExecuteNonQuery(command);
                }
            }
            catch(SqlException ex)
            {
                String message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
            catch(Exception ex)
            {
                string message = "Ocurrio un error en el programa: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Cliente de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Cliente con la informacion de cada uno de 
        /// los campos de la tabla Cliente</returns>

        public List<Cliente> GetAllCliente()
        {
            DataSet ds = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_CLIENTE_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Cliente cliente = new Cliente();
                        cliente.ID = (int)dr["ID"];
                        cliente.Nombre= dr["NOMBRE"].ToString();
                        cliente.Apellido1= dr["APELLIDO1"].ToString();
                        cliente.Apellido2 = dr["APELLIDO2"].ToString();
                        cliente.Direccion= dr["DIRECCION"].ToString();
                        cliente.IdProvincia = (int)dr["ID_PROVINCIA"];
                        cliente.IdCanton = (int)dr["ID_CANTON"];
                        cliente.CodigoPostal = dr["CODIGO_POSTAL"].ToString();
                        cliente.Comentario= dr["COMENTARIO"].ToString();
                        cliente.Estado = (int)dr["ESTADO"];

                        lista.Add(cliente);
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
        /// Método que retorna una lista de objetos Cliente, con la informacion que 
        /// contiene la tabla Cliente en la base de datos siempre y cuando, el campo
        /// descripcion coincida con el parametro
        /// </summary>
        /// <param name="pDescripcion">string que contiene la descripcion a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos Cliente con la informacion de la tabla 
        /// Cliente cuyo campo descripcion haya coincidido con el parametro</returns>

        public List<Cliente> GetClienteByFilter(string pDescripcion)
        {
            DataSet ds = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"filtro", pDescripcion);
                    command.CommandText = "PA_SELECT_CLIENTE_ByFilter";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Cliente cliente = new Cliente();
                        cliente.ID = (int)dr["ID"];
                        cliente.Nombre = dr["NOMBRE"].ToString();
                        cliente.Apellido1 = dr["APELLIDO1"].ToString();
                        cliente.Apellido2 = dr["APELLIDO2"].ToString();
                        cliente.Direccion = dr["DIRECCION"].ToString();
                        cliente.IdProvincia = (int)dr["ID_PROVINCIA"];
                        cliente.IdCanton = (int)dr["ID_CANTON"];
                        cliente.CodigoPostal = dr["CODIGO_POSTAL"].ToString();
                        cliente.Comentario = dr["COMENTARIO"].ToString();
                        cliente.Estado = (int)dr["ESTADO"];

                        lista.Add(cliente);
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
        /// Metodo que retorna una instancia de la clase Cliente con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Cliente con la informacion de la tabla 
        /// Cliente cuyo campo id haya coincidido con el parametro</returns>

        public Cliente GetClienteById(string pId)
        {
            DataSet ds = null;
            Cliente cliente = null;
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_CLIENTE_ByID";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        cliente= new Cliente();
                        cliente.ID = (int)dr["ID"];
                        cliente.Nombre = dr["NOMBRE"].ToString();
                        cliente.Apellido1 = dr["APELLIDO1"].ToString();
                        cliente.Apellido2 = dr["APELLIDO2"].ToString();
                        cliente.Direccion = dr["DIRECCION"].ToString();
                        cliente.IdProvincia = (int)dr["ID_PROVINCIA"];
                        cliente.IdCanton = (int)dr["ID_CANTON"];
                        cliente.CodigoPostal = dr["CODIGO_POSTAL"].ToString();
                        cliente.Comentario = dr["COMENTARIO"].ToString();
                        cliente.Estado = (int)dr["ESTADO"];
                    }
                }
                return cliente;
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
        /// Metodo que almacena la informacion de una instancia de la clase Cliente
        /// como un campo de la tabla Cliente en la base de datos
        /// </summary>
        /// <param name="pCliente">instancia de la clase Cliente que sera almacenada
        /// en la base de datos</param>

        public void SaveCliente(Cliente pCliente)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_CLIENTE";
                    command.Parameters.AddWithValue(@"ID", pCliente.ID);
                    command.Parameters.AddWithValue(@"APELLIDO2", pCliente.Apellido2);
                    command.Parameters.AddWithValue(@"APELLIDO1", pCliente.Apellido1);
                    command.Parameters.AddWithValue(@"NOMBRE", pCliente.Nombre);
                    command.Parameters.AddWithValue(@"DIRECCION", pCliente.Direccion);
                    command.Parameters.AddWithValue(@"ID_PROVINCIA", pCliente.IdProvincia);
                    command.Parameters.AddWithValue(@"ID_CANTON", pCliente.IdCanton);
                    command.Parameters.AddWithValue(@"CODIGO_POSTAL", pCliente.CodigoPostal);
                    command.Parameters.AddWithValue(@"COMENTARIO", pCliente.Comentario);
                    command.Parameters.AddWithValue(@"ESTADO", pCliente.Estado);

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
        /// Metodo que actualiza un campo de la tabla Cliente en la base de datos con la
        /// informacion que contiene la instancia de la clase Cliente en el parametro
        /// </summary>
        /// <param name="pCliente">instancia de la clase Cliente cuya informacion
        /// se utilizara para actualizar un campo en la tabla Cliente</param>

        public void UpdateCliente(Cliente pCliente)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_CLIENTE";
                    command.Parameters.AddWithValue(@"ID", pCliente.ID);
                    command.Parameters.AddWithValue(@"APELLIDO2", pCliente.Apellido2);
                    command.Parameters.AddWithValue(@"APELLIDO1", pCliente.Apellido1);
                    command.Parameters.AddWithValue(@"NOMBRE", pCliente.Nombre);
                    command.Parameters.AddWithValue(@"DIRECCION", pCliente.Direccion);
                    command.Parameters.AddWithValue(@"ID_PROVINCIA", pCliente.IdProvincia);
                    command.Parameters.AddWithValue(@"ID_CANTON", pCliente.IdCanton);
                    command.Parameters.AddWithValue(@"CODIGO_POSTAL", pCliente.CodigoPostal);
                    command.Parameters.AddWithValue(@"COMENTARIO", pCliente.Comentario);
                    command.Parameters.AddWithValue(@"ESTADO", pCliente.Estado);

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
        /// Metodo que se utiliza para actualizar el Estado de un campo de la tabla 
        /// Cliente en la base de datos
        /// </summary>
        /// <param name="pId">string que contiene el id del campo que se va a 
        /// actualizar en la base de datos</param>

        public void BorradoLogico(string pId)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_BORRADO_LOGICO";
                    command.Parameters.AddWithValue(@"ID", Convert.ToInt64(pId));

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
