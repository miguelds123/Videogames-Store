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
    class DALReservacion : IDALReservacion
    {
        Usuario _Usuario = new Usuario();
        public DALReservacion()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public bool DeleteReservacion(string pId)
        {
            bool retorno = false;
            double rows = 0d;
            Reservacion reservacion= null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                reservacion= GetReservacionById(pId);

                string sql = @"Delete from RESERVACION where ID = @IdReservacion";
                commandReservacion.Parameters.AddWithValue(@"IdReservacion", Convert.ToInt64(pId));
                commandReservacion.CommandText = sql;
                commandReservacion.CommandType = CommandType.Text;
                listaCommands.Add(commandReservacion);

                commandProducto.Parameters.AddWithValue(@"ID", reservacion.IdProducto);

                string sqlProducto = @"Update PRODUCTO 
                    SET CANTIDAD_INVENTARIO = CANTIDAD_INVENTARIO - 1
                    where ID = @ID";

                commandProducto.CommandText = sqlProducto;
                commandProducto.CommandType = CommandType.Text;
                listaCommands.Add(commandProducto);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                    retorno = true;

                return retorno;
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

        public List<Reservacion> GetAllReservacion()
        {
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Select * from RESERVACION";
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
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

        public Reservacion GetReservacionById(string pId)
        {
            DataSet ds = null;
            Reservacion reservacion = null;
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"select * from RESERVACION where ID = @IdReservacion";
                command.Parameters.AddWithValue(@"IdReservacion", Convert.ToInt64(pId));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
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

        public List<Reservacion> GetReservacionByIdCliente(string pId)
        {
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Select * from RESERVACION where ID_CLIENTE = @ID_CLIENTE";
                command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pId));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
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

        public Reservacion SaveReservacion(Reservacion pReservacion)
        {
            Reservacion reservacion= null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            string sql = @"Insert into RESERVACION values (@ID, @ID_CLIENTE, @ID_PRODUCTO, 
            @ADELANTO)";

            double rows = 0;

            try
            {
                //realiza el insert de la reservacion

                commandReservacion.Parameters.AddWithValue(@"ID", pReservacion.ID);
                commandReservacion.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                commandReservacion.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                commandReservacion.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);

                commandReservacion.CommandText = sql;
                listaCommands.Add(commandReservacion);

                //rebaja la cantidad de inventario en base a la cantidad de producto que se
                //compraron

                commandProducto.Parameters.AddWithValue(@"ID", reservacion.IdProducto);

                string sqlProducto = @"Update PRODUCTO 
                    SET CANTIDAD_INVENTARIO = CANTIDAD_INVENTARIO - 1
                    where ID = @ID";

                commandProducto.CommandText = sqlProducto;
                commandProducto.CommandType = CommandType.Text;
                listaCommands.Add(commandProducto);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                }

                if (rows == 0)
                {
                    throw new Exception("No se pudo salvar correctamente la reservacion");
                }
                else
                {
                    reservacion = GetReservacionById(pReservacion.ID.ToString());
                }

                return reservacion;
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

        public Reservacion UpdateReservacion(Reservacion pReservacion)
        {
            Reservacion reservacion = null;
            SqlCommand command = new SqlCommand();

            string sql = @"Update RESERVACION SET ID = @ID, ID_CLIENTE = @ID_CLIENTE, 
            ID_PRODUCTO = @ID_PRODUCTO, ADELANTO = @ADELANTO where ID = @ID";

            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID", pReservacion.ID);
                command.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                command.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                command.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);

                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    reservacion = this.GetReservacionById(pReservacion.ID.ToString());
                }

                return reservacion;
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
