using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    class DALReservacionVideojuego
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALReservacionVideojuego()
        {
            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        public void DeleteReservacionVideojuego(string pId)
        {
            Reservacion reservacion = null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reservacion = GetReservacionVideojuegoById(pId);

                    commandReservacion.CommandType = System.Data.CommandType.StoredProcedure;
                    commandReservacion.CommandText = "PA_DELETE_RESERVACION_VIDEOJUEGO_ByID";
                    commandReservacion.Parameters.AddWithValue("@ID", Convert.ToInt64(pId));
                    listaCommands.Add(commandReservacion);

                    commandProducto.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProducto.CommandText = "PA_AUMENTAR_CANTIDAD_VIDEOJUEGO";
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

        public List<Reservacion> GetAllReservacionVideojuego()
        {
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_RESERVACION_VIDEOJUEGO_All";

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

        public Reservacion GetReservacionVideojuegoById(string pId)
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
                    command.CommandText = "PA_SELECT_RESERVACION_VIDEOJUEGO_ByID";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
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

        public List<Reservacion> GetReservacionVideojuegoByIdCliente(string pId)
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
                    command.CommandText = "PA_SELECT_RESERVACION_VIDEOJUEGO_ByIdCliente";

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

        public void SaveReservacion(Reservacion pReservacion)
        {
            Reservacion reservacion = null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //realiza el insert de la reservacion

                    commandReservacion.CommandType = System.Data.CommandType.StoredProcedure;
                    commandReservacion.CommandText = "PA_INSERT_RESERVACION_VIDEOJUEGO";
                    commandReservacion.Parameters.AddWithValue(@"ID", pReservacion.ID);
                    commandReservacion.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                    commandReservacion.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                    commandReservacion.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);
                    listaCommands.Add(commandReservacion);

                    //rebaja la cantidad de inventario en base a la cantidad de producto que se
                    //compraron

                    commandProducto.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProducto.CommandText = "PA_DISMINUIR_CANTIDAD_VIDEOJUEGO";
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

        public void UpdateReservacion(Reservacion pReservacion)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_VIDEOJUEGO";
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
