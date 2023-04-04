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
    class DALCliente : IDALCliente
    {
        Usuario _Usuario = new Usuario();
        public DALCliente()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }
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
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return;
            }
        }

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

                        lista.Add(cliente);
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return null;
            }
        }

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

                        lista.Add(cliente);
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return null;
            }
        }

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
                    }
                }
                return cliente;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return null;
            }
        }

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

                    db.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return;
            }
        }

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

                    db.ExecuteNonQuery(command);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return;
            }
        }
    }
}
