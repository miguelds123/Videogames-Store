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
    class DALVideojuego
    {
        private Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALVideojuego()
        {
            _Usuario.Login = "sa";
            _Usuario.Password= "123456";
        }

        public void BorradoLogico(int pID)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_BORRADO_LOGICO_VIDEOJUEGO";
                    command.Parameters.AddWithValue("@ID", pID);

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

        public void DeleteVideojuego(double pId)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_VIDEOJUEGO_ByID";
                    command.Parameters.AddWithValue("@ID", Convert.ToInt64(pId));

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

        public List<Videojuego> GetAllVideojuego()
        {
            DataSet ds = null;
            List<Videojuego> lista = new List<Videojuego>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_VIDEOJUEGO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Videojuego videojuego= new Videojuego();
                        videojuego.ID = (int)dr["ID"];
                        videojuego.NOMBRE = dr["NOMBRE"].ToString();
                        videojuego.CANTIDAD_INVENTARIO = (int)dr["CANTIDAD_INVENTARIO"];
                        videojuego.DESCUENTO = (int)dr["DESCUENTO"];
                        videojuego.ID_CATEGORIA = (int)dr["ID_CATEGORIA"];
                        videojuego.PRECIO_COLONES = Convert.ToDouble(dr["PRECIO_COLONES"].ToString());
                        videojuego.PRECIO_DOLARES = Convert.ToDouble(dr["PRECIO_DOLARES"].ToString());
                        videojuego.Imagen = (byte[])dr["IMAGEN"];
                        videojuego.ESTADO = (int)dr["ESTADO"];
                        videojuego.DESCRIPCION = dr["DESCRIPCION"].ToString();
                        videojuego.FECHA_SALIDA = (DateTime)dr["FECHA_SALIDA"];
                        videojuego.NOTA= Double.Parse(dr["NOTA"].ToString()) ;
                        lista.Add(videojuego);
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

        public Videojuego GetVideojuegoById(double pId)
        {
            DataSet ds = null;
            Videojuego videojuego = null;
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_VIDEOJUEGO_ByID";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    videojuego = new Videojuego();
                    videojuego.ID = (int)dr["ID"];
                    videojuego.NOMBRE = dr["NOMBRE"].ToString();
                    videojuego.CANTIDAD_INVENTARIO = (int)dr["CANTIDAD_INVENTARIO"];
                    videojuego.DESCUENTO = (int)dr["DESCUENTO"];
                    videojuego.ID_CATEGORIA = (int)dr["ID_CATEGORIA"];
                    videojuego.PRECIO_COLONES = Convert.ToDouble(dr["PRECIO_COLONES"].ToString());
                    videojuego.PRECIO_DOLARES = Convert.ToDouble(dr["PRECIO_DOLARES"].ToString());
                    videojuego.Imagen = (byte[])dr["IMAGEN"];
                    videojuego.ESTADO = (int)dr["ESTADO"];
                    videojuego.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    videojuego.FECHA_SALIDA = (DateTime)dr["FECHA_SALIDA"];
                    videojuego.NOTA = Double.Parse(dr["NOTA"].ToString());
                }
                return videojuego;
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

        public void SaveVideojuego(Videojuego pVideojuego)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_VIDEOJUEGO";
                    command.Parameters.AddWithValue(@"ID", pVideojuego.ID);
                    command.Parameters.AddWithValue(@"NOMBRE", pVideojuego.NOMBRE);
                    command.Parameters.AddWithValue(@"CANTIDAD_INVENTARIO", pVideojuego.CANTIDAD_INVENTARIO);
                    command.Parameters.AddWithValue(@"DESCUENTO", pVideojuego.DESCUENTO);
                    command.Parameters.AddWithValue(@"ID_CATEGORIA", pVideojuego.ID_CATEGORIA);
                    command.Parameters.AddWithValue(@"PRECIO_COLONES", pVideojuego.PRECIO_COLONES);
                    command.Parameters.AddWithValue(@"PRECIO_DOLARES", pVideojuego.PRECIO_DOLARES);
                    command.Parameters.AddWithValue(@"IMAGEN", pVideojuego.Imagen);
                    command.Parameters.AddWithValue(@"ESTADO", pVideojuego.ESTADO);
                    command.Parameters.AddWithValue(@"DESCRIPCION", pVideojuego.DESCRIPCION);
                    command.Parameters.AddWithValue(@"FECHA_SALIDA", pVideojuego.FECHA_SALIDA);
                    command.Parameters.AddWithValue(@"NOTA", pVideojuego.NOTA);

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

        public void UpdateVideojuego(Videojuego pVideojuego)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_VIDEOJUEGO";
                    command.Parameters.AddWithValue(@"ID", pVideojuego.ID);
                    command.Parameters.AddWithValue(@"NOMBRE", pVideojuego.NOMBRE);
                    command.Parameters.AddWithValue(@"CANTIDAD_INVENTARIO", pVideojuego.CANTIDAD_INVENTARIO);
                    command.Parameters.AddWithValue(@"DESCUENTO", pVideojuego.DESCUENTO);
                    command.Parameters.AddWithValue(@"ID_CATEGORIA", pVideojuego.ID_CATEGORIA);
                    command.Parameters.AddWithValue(@"PRECIO_COLONES", pVideojuego.PRECIO_COLONES);
                    command.Parameters.AddWithValue(@"PRECIO_DOLARES", pVideojuego.PRECIO_DOLARES);
                    command.Parameters.AddWithValue(@"IMAGEN", pVideojuego.Imagen);
                    command.Parameters.AddWithValue(@"ESTADO", pVideojuego.ESTADO);
                    command.Parameters.AddWithValue(@"DESCRIPCION", pVideojuego.DESCRIPCION);
                    command.Parameters.AddWithValue(@"FECHA_SALIDA", pVideojuego.FECHA_SALIDA);
                    command.Parameters.AddWithValue(@"NOTA", pVideojuego.NOTA);

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
