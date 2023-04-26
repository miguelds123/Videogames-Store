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
    /// Clase DALVideojuego que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Videojuego de la base de datos
    /// </summary>

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

        /// <summary>
        /// Metodo que se utiliza para actualizar el Estado de un campo de la tabla 
        /// Videojuego en la base de datos
        /// </summary>
        /// <param name="pID">string que contiene el id del campo que se va a 
        /// actualizar en la base de datos</param>

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

        /// <summary>
        /// Método que elimina un determinado campo en la tabla Videojuego   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

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

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Videojuego de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Videojuego con la informacion de cada uno de 
        /// los campos de la tabla Videojuego</returns>

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

        /// <summary>
        /// Metodo que retorna una instancia de la clase Videojuego con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Videojuego con la informacion de la tabla 
        /// Videojuego cuyo campo id haya coincidido con el parametro</returns>

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

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase Videojuego
        /// como un campo de la tabla Videojuego en la base de datos
        /// </summary>
        /// <param name="pVideojuego">instancia de la clase Videojuego que sera almacenada
        /// en la base de datos</param>

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

        /// <summary>
        /// Metodo que actualiza un campo de la tabla Videojuego en la base de datos con la
        /// informacion que contiene la instancia de la clase Videojuego en el parametro
        /// </summary>
        /// <param name="pVideojuego">instancia de la clase Videojuego cuya informacion
        /// se utilizara para actualizar un campo en la tabla Videojuego</param>

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
