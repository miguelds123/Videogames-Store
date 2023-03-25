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
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public bool DeleteCliente(string pId)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Delete from CLIENTE where (ID = @IdCliente)";
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pId));
                command.CommandText= sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                    retorno = true;

                return retorno;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return false;
            }
        }

        public List<Cliente> GetAllCliente()
        {
            DataSet ds = null;
            List<Cliente> lista = new List<Cliente>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Select * from CLIENTE";
                command.CommandText= sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
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
                        cliente.IdDistrito = (int)dr["ID_DISTRITO"];
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
                string sql = @"Select * from CLIENTE where NOMBRE + APELLIDO1 + APELLIDO2 like @filtro";
                command.Parameters.AddWithValue(@"filtro", pDescripcion);
                command.CommandText= sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
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
                        cliente.IdDistrito = (int)dr["ID_DISTRITO"];
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
                string sql = @"select * from CLIENTE where ID = @IdCliente";
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pId));
                command.CommandText= sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
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
                        cliente.IdDistrito = (int)dr["ID_DISTRITO"];
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

        public Cliente SaveCliente(Cliente pCliente)
        {
            Cliente cliente = new Cliente();
            SqlCommand command = new SqlCommand();

            string sql = @"Insert into CLIENTE values (@ID, @APELLIDO2, @APELLIDO1, @NOMBRE,
            @DIRECCION, @ID_DISTRITO, @ID_PROVINCIA, @ID_CANTON, @CODIGO_POSTAL, @COMENTARIO)";

            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID", pCliente.ID);
                command.Parameters.AddWithValue(@"APELLIDO2", pCliente.Apellido2);
                command.Parameters.AddWithValue(@"APELLIDO1", pCliente.Apellido1);
                command.Parameters.AddWithValue(@"NOMBRE", pCliente.Nombre);
                command.Parameters.AddWithValue(@"DIRECCION", pCliente.Direccion);
                command.Parameters.AddWithValue(@"ID_DISTRITO", pCliente.IdDistrito);
                command.Parameters.AddWithValue(@"ID_PROVINCIA", pCliente.IdProvincia);
                command.Parameters.AddWithValue(@"ID_CANTON", pCliente.IdCanton);
                command.Parameters.AddWithValue(@"CODIGO_POSTAL", pCliente.CodigoPostal);
                command.Parameters.AddWithValue(@"COMENTARIO", pCliente.Comentario);

                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    cliente = this.GetClienteById(pCliente.ID.ToString());
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

        public Cliente UpdateCliente(Cliente pCliente)
        {
            Cliente cliente = new Cliente();
            SqlCommand command = new SqlCommand();

            string sql = @"Update CLIENTE Set ID = @ID, APELLIDO2 = @APELLIDO2, 
            APELLIDO1 = @APELLIDO1, NOMBRE = @NOMBRE, DIRECCION = @DIRECCION, 
            ID_DISTRITO = @ID_DISTRITO, ID_PROVINCIA = @ID_PROVINCIA, ID_CANTON = @ID_CANTON, 
            CODIGO_POSTAL = @CODIGO_POSTAL, COMENTARIO = @COMENTARIO where (ID = @ID)";

            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID", pCliente.ID);
                command.Parameters.AddWithValue(@"APELLIDO2", pCliente.Apellido2);
                command.Parameters.AddWithValue(@"APELLIDO1", pCliente.Apellido1);
                command.Parameters.AddWithValue(@"NOMBRE", pCliente.Nombre);
                command.Parameters.AddWithValue(@"DIRECCION", pCliente.Direccion);
                command.Parameters.AddWithValue(@"ID_DISTRITO", pCliente.IdDistrito);
                command.Parameters.AddWithValue(@"ID_PROVINCIA", pCliente.IdProvincia);
                command.Parameters.AddWithValue(@"ID_CANTON", pCliente.IdCanton);
                command.Parameters.AddWithValue(@"CODIGO_POSTAL", pCliente.CodigoPostal);
                command.Parameters.AddWithValue(@"COMENTARIO", pCliente.Comentario);

                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    cliente = this.GetClienteById(pCliente.ID.ToString());
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
    }
}
