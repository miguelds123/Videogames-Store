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
    /// <summary>
    /// Clase DALProducto que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Producto de la base de datos
    /// </summary>

    class DALProducto : IDALProducto
    {
        private Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALProducto()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Metodo que se utiliza para actualizar el Estado de un campo de la tabla 
        /// Producto en la base de datos
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
                    command.CommandText = "PA_BORRADO_LOGICO_PRODUCTO";
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
        /// Método que elimina un determinado campo en la tabla Producto   
        /// </summary>
        /// <param name="pId">string que contiene el id del campo a eliminar</param>

        public void DeleteProducto(double pId)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_PRODUCTO_ByID";
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
        /// en la tabla Producto de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Producto con la informacion de cada uno de 
        /// los campos de la tabla Producto</returns>

        public List<Producto> GetAllProducto()
        {
            DataSet ds = null;
            List<Producto> lista = new List<Producto>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_PRODUCTO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Producto producto = new Producto();
                        producto.ID = (int)dr["ID"];
                        producto.Descripcion = dr["DESCRIPCION"].ToString();
                        producto.CantidadInventario = (int)dr["CANTIDAD_INVENTARIO"];
                        producto.Descuento = Convert.ToDouble(dr["DESCUENTO"].ToString());
                        producto.IdCategoria = (int)dr["ID_CATEGORIA"];
                        producto.PrecioColones = Convert.ToDouble(dr["PRECIO_COLONES"].ToString());
                        producto.PrecioDolares = Convert.ToDouble(dr["PRECIO_DOLARES"].ToString());
                        producto.Imagen = (byte[])dr["IMAGEN"];
                        producto.Estado = (int)dr["ESTADO"];
                        lista.Add(producto);
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
        /// Método que retorna una lista de objetos Producto, con la informacion que 
        /// contiene la tabla Producto en la base de datos siempre y cuando, el campo
        /// descripcion coincida con el parametro
        /// </summary>
        /// <param name="pDescripcion">string que contiene la descripcion a buscar
        /// en la base de datos</param>
        /// <returns>Una lista de objetos Producto con la informacion de la tabla 
        /// Producto cuyo campo descripcion haya coincidido con el parametro</returns>

        public List<Producto> GetProductoByFilter(string pDescripcion)
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand();
            List<Producto> lista = new List<Producto>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"filtro", pDescripcion);
                    command.CommandText = "PA_SELECT_PRODUCTO_ByDescripcion";
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Producto producto = new Producto()
                        {
                            ID = (int)dr["ID"],
                            Descripcion = dr["DESCRIPCION"].ToString(),
                            CantidadInventario = (int)dr["CANTIDAD_INVENTARIO"],
                            Descuento = Convert.ToDouble(dr["DESCUENTO"].ToString()),
                            IdCategoria = (int)dr["ID_CATEGORIA"],
                            PrecioColones = Convert.ToDouble(dr["PRECIO_COLONES"].ToString()),
                            PrecioDolares = Convert.ToDouble(dr["PRECIO_DOLARES"].ToString()),
                            Imagen = (byte[])dr["IMAGEN"],
                            Estado = (int)dr["ESTADO"]
                        };
                        lista.Add(producto);
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
        /// Metodo que retorna una instancia de la clase Producto con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pId">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase Producto con la informacion de la tabla 
        /// Producto cuyo campo id haya coincidido con el parametro</returns>

        public Producto GetProductoById(double pId)
        {
            DataSet ds = null;
            Producto producto = null;
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_PRODUCTO_ByID";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr= ds.Tables[0].Rows[0];
                    producto = new Producto()
                    {
                        ID = (int)dr["ID"],
                        Descripcion = dr["DESCRIPCION"].ToString(),
                        CantidadInventario = (int)dr["CANTIDAD_INVENTARIO"],
                        Descuento = Convert.ToDouble(dr["DESCUENTO"].ToString()),
                        IdCategoria = (int)dr["ID_CATEGORIA"],
                        PrecioColones = Convert.ToDouble(dr["PRECIO_COLONES"].ToString()),
                        PrecioDolares = Convert.ToDouble(dr["PRECIO_DOLARES"].ToString()),
                        Imagen = (byte[])dr["IMAGEN"],
                        Estado = (int)dr["ESTADO"]
                    };
                }
                return producto;
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
        /// Metodo que almacena la informacion de una instancia de la clase Producto
        /// como un campo de la tabla Producto en la base de datos
        /// </summary>
        /// <param name="pProducto">instancia de la clase Producto que sera almacenada
        /// en la base de datos</param>

        public void SaveProducto(Producto pProducto)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_INSERT_PRODUCTO";
                    command.Parameters.AddWithValue(@"ID", pProducto.ID);
                    command.Parameters.AddWithValue(@"DESCRIPCION", pProducto.Descripcion);
                    command.Parameters.AddWithValue(@"CANTIDAD_INVENTARIO", pProducto.CantidadInventario);
                    command.Parameters.AddWithValue(@"DESCUENTO", pProducto.Descuento);
                    command.Parameters.AddWithValue(@"ID_CATEGORIA", pProducto.IdCategoria);
                    command.Parameters.AddWithValue(@"PRECIO_COLONES", pProducto.PrecioColones);
                    command.Parameters.AddWithValue(@"PRECIO_DOLARES", pProducto.PrecioDolares);
                    command.Parameters.AddWithValue(@"IMAGEN", pProducto.Imagen);
                    command.Parameters.AddWithValue(@"ESTADO", pProducto.Estado);

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
        /// Metodo que actualiza un campo de la tabla Producto en la base de datos con la
        /// informacion que contiene la instancia de la clase Producto en el parametro
        /// </summary>
        /// <param name="pProducto">instancia de la clase Producto cuya informacion
        /// se utilizara para actualizar un campo en la tabla Producto</param>

        public void UpdateProducto(Producto pProducto)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_PRODUCTO";
                    command.Parameters.AddWithValue(@"ID", pProducto.ID);
                    command.Parameters.AddWithValue(@"DESCRIPCION", pProducto.Descripcion);
                    command.Parameters.AddWithValue(@"CANTIDAD_INVENTARIO", pProducto.CantidadInventario);
                    command.Parameters.AddWithValue(@"DESCUENTO", pProducto.Descuento);
                    command.Parameters.AddWithValue(@"ID_CATEGORIA", pProducto.IdCategoria);
                    command.Parameters.AddWithValue(@"PRECIO_COLONES", pProducto.PrecioColones);
                    command.Parameters.AddWithValue(@"PRECIO_DOLARES", pProducto.PrecioDolares);
                    command.Parameters.AddWithValue(@"IMAGEN", pProducto.Imagen);
                    command.Parameters.AddWithValue(@"ESTADO", pProducto.Estado);

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
