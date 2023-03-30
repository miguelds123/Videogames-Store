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
    class DALListaDeseos : IDAListaDeseos
    {
        Usuario _Usuario = new Usuario();
        public DALListaDeseos()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }

        public bool DeleteListaDeseos(string pIdCliente, string pIdProducto)
        {
            double rows = 0;

            string sql = @"Delete from PRODUCTO where ID_CLIENTE = @IdCliente and ID_PRODUCTO = @IdProducto";
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pIdCliente));
                command.Parameters.AddWithValue(@"IdProducto", Convert.ToInt64(pIdProducto));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                return rows > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return false;
            }
        }

        public List<ListaDeseos> GetAllListaDeseos()
        {
            DataSet ds = null;
            List<ListaDeseos> lista = new List<ListaDeseos>();
            SqlCommand command = new SqlCommand();

            string sql = @"Select * from LISTA_DESEOS";

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
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

        public ListaDeseos GetListaDeseos(string pIdCliente, string pIdProducto)
        {
            DataSet ds = null;
            ListaDeseos listaDeseos = null;
            string sql = @"Select * from LISTA_DESEOS where ID_CLIENTE = @IdCliente and 
            ID_PRODUCTO = @IdProducto ";
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pIdCliente));
                command.Parameters.AddWithValue(@"IdProducto", Convert.ToInt64(pIdProducto));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
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

        public List<ListaDeseos> GetListaDeseosByIdCliente(string pId)
        {
            DataSet ds = null;
            ListaDeseos listaDeseos = null;
            List<ListaDeseos> lista = new List<ListaDeseos>();
            string sql = @"Select * from LISTA_DESEOS where ID_CLIENTE = @IdCliente";
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pId));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
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

        public List<ListaDeseos> GetListaDeseosByIdProducto(string pId)
        {
            DataSet ds = null;
            ListaDeseos listaDeseos = null;
            List<ListaDeseos> lista = new List<ListaDeseos>();
            string sql = @"Select * from LISTA_DESEOS where ID_PRODUCTO = @IdProducto";
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue(@"IdProducto", Convert.ToInt64(pId));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
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

        public ListaDeseos SaveListaDeseos(ListaDeseos pListaDeseos)
        {
            ListaDeseos listaDeseos = null;
            string sql = @"Insert into LISTA_DESEOS values (@ID_CLIENTE, @ID_PRODUCTO)";

            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID_CLIENTE", pListaDeseos.IdCliente);
                command.Parameters.AddWithValue(@"ID_PRODUCTO", pListaDeseos.IdProducto);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    listaDeseos = GetListaDeseos(pListaDeseos.IdCliente.ToString(), 
                        pListaDeseos.IdProducto.ToString());
                }
                return listaDeseos;
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

        public ListaDeseos UpdateListaDeseos(ListaDeseos pListaDeseos)
        {
            ListaDeseos listaDeseos = null;
            string sql = @"Update LISTA_DESEOS SET ID_CLIENTE = @ID_CLIENTE, 
            ID_PRODUCTO = @ID_PRODUCTO";

            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID_CLIENTE", pListaDeseos.IdCliente);
                command.Parameters.AddWithValue(@"ID_PRODUCTO", pListaDeseos.IdProducto);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    listaDeseos = GetListaDeseos(pListaDeseos.IdCliente.ToString(),
                        pListaDeseos.IdProducto.ToString());
                }
                return listaDeseos;
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
