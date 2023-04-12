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
    class DALProducto : IDALProducto
    {
        private Usuario _Usuario = new Usuario();
        public DALProducto()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

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
