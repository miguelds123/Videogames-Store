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
    class DALProducto : IDALProducto
    {
        private Usuario _Usuario = new Usuario();
        public DALProducto()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public bool DeleteProducto(double pId)
        {
            double rows = 0;

            string sql = @"Delete from PRODUCTO where ID = @IdProducto";
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue(@"IdProducto", Convert.ToInt64(pId));
                command.CommandText= sql;
                command.CommandType= CommandType.Text;

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

        public List<Producto> GetAllProducto()
        {
            DataSet ds = null;
            List<Producto> lista = new List<Producto>();
            SqlCommand command = new SqlCommand();

            string sql = @"Select * from PRODUCTO";

            try
            {
                command.CommandText = sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
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
                            Descuento = (double)dr["DESCUENTO"],
                            IdCategoria = (int)dr["ID_CATEGORIA"],
                            PrecioColones = (double)dr["PRECIO_COLONES"],
                            PrecioDolares = (double)dr["PRECIO_DOLARES"],
                            Imagen= (byte[])dr["IMAGEN"]
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

        public List<Producto> GetProductoByFilter(string pDescripcion)
        {
            DataSet ds = null;
            SqlCommand command = new SqlCommand();
            List<Producto> lista = new List<Producto>();

            string sql = @"Select from PRODUCTO where DESCRIPCION like @DescripcionProducto";

            try
            {
                command.Parameters.AddWithValue(@"DescripcionProducto", pDescripcion);
                command.CommandText= sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
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
                            Descuento = (double)dr["DESCUENTO"],
                            IdCategoria = (int)dr["ID_CATEGORIA"],
                            PrecioColones = (double)dr["PRECIO_COLONES"],
                            PrecioDolares = (double)dr["PRECIO_DOLARES"],
                            Imagen= (byte[])dr["IMAGEN"]
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
            string sql = @"Select * from PRODUCTO where ID = @IdProducto";
            SqlCommand command = new SqlCommand();

            try
            {
                command.Parameters.AddWithValue(@"IdProducto", Convert.ToInt64(pId));
                command.CommandText= sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr= ds.Tables[0].Rows[0];
                    producto = new Producto()
                    {
                        ID = (int)dr["ID"],
                        Descripcion = dr["DESCRIPCION"].ToString(),
                        CantidadInventario = (int)dr["CANTIDAD_INVENTARIO"],
                        Descuento = (double)dr["DESCUENTO"],
                        IdCategoria = (int)dr["ID_CATEGORIA"],
                        PrecioColones = (double)dr["PRECIO_COLONES"],
                        PrecioDolares = (double)dr["PRECIO_DOLARES"],
                        Imagen = (byte[])dr["IMAGEN"]
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

        public Producto SaveProducto(Producto pProducto)
        {
            Producto producto = null;
            string sql = @"Insert into PRODUCTO values (@ID, @DESCRIPCION, @CANTIDAD_INVENTARIO,
            @DESCUENTO, @ID_CATEGORIA, @PRECIO_COLONES, @PRECIO_DOLARES, @IMAGEN)";

            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID", pProducto.ID);
                command.Parameters.AddWithValue(@"DESCRIPCION", pProducto.Descripcion);
                command.Parameters.AddWithValue(@"CANTIDAD_INVENTARIO", pProducto.CantidadInventario);
                command.Parameters.AddWithValue(@"DESCUENTO", pProducto.Descuento);
                command.Parameters.AddWithValue(@"ID_CATEGORIA", pProducto.IdCategoria);
                command.Parameters.AddWithValue(@"PRECIO_COLONES", pProducto.PrecioColones);
                command.Parameters.AddWithValue(@"PRECIO_DOLARES", pProducto.PrecioDolares);
                command.Parameters.AddWithValue(@"IMAGEN", pProducto.Imagen);
                command.CommandText = sql;
                command.CommandType= CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    producto= GetProductoById(pProducto.ID);
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

        public Producto UpdateProducto(Producto pProducto)
        {
            Producto producto = null;
            string sql = @"Update PRODUCTO SET ID = @ID, DESCRIPCION = @DESCRIPCION, 
            CANTIDAD_INVENTARIO = @CANTIDAD_INVENTARIO, DESCUENTO = @DESCUENTO, 
            ID_CATEGORIA = @ID_CATEGORIA, PRECIO_COLONES = @PRECIO_COLONES, 
            PRECIO_DOLARES = @PRECIO_DOLARES, IMAGEN = @IMAGEN where ID = @ID";

            SqlCommand command = new SqlCommand();
            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"ID", pProducto.ID);
                command.Parameters.AddWithValue(@"DESCRIPCION", pProducto.Descripcion);
                command.Parameters.AddWithValue(@"CANTIDAD_INVENTARIO", pProducto.CantidadInventario);
                command.Parameters.AddWithValue(@"DESCUENTO", pProducto.Descuento);
                command.Parameters.AddWithValue(@"ID_CATEGORIA", pProducto.IdCategoria);
                command.Parameters.AddWithValue(@"PRECIO_COLONES", pProducto.PrecioColones);
                command.Parameters.AddWithValue(@"PRECIO_DOLARES", pProducto.PrecioDolares);
                command.Parameters.AddWithValue(@"IMAGEN", pProducto.Imagen);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    producto = GetProductoById(pProducto.ID);
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
    }
}
