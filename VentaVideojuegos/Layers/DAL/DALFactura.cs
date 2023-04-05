using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Interfaces;
using VentaVideojuegos.Properties;

namespace VentaVideojuegos
{
    class DALFactura : IDALFactura
    {
        Usuario _Usuario = new Usuario();
        public DALFactura()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }

        public int GetCurrentNumeroFactura()
        {
            DataSet ds = null;
            SqlCommand command= new SqlCommand();
            int numeroFactura = 0;

            DataTable dt = null;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GetCurrentNumeroFactura";

                    ds = db.ExecuteDataSet(command);
                }

                dt = ds.Tables[0];

                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return 0;
            }
        }

        public int GetNextNumeroFactura()
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
                    command.CommandText = "GetNextNumeroFactura";

                    ds = db.ExecuteDataSet(command);
                }

                dt = ds.Tables[0];

                numeroFactura = int.Parse(dt.Rows[0][0].ToString());
                return numeroFactura;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return 0;
            }
        }

        public void SaveFactura(OrdenCompraDTO pOrdenCompraDTO)
        {
            OrdenCompraDTO ordenCompraDTO = null;

            SqlCommand cmdFacturaEncabezado = new SqlCommand();
            SqlCommand cmdFacturaDetalle = new SqlCommand();
            SqlCommand cmdProducto = new SqlCommand();
            double rows = 0;

            //agrega a la base de datos la orden de compra

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    cmdFacturaEncabezado.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdFacturaEncabezado.CommandText = "InsertarEncabezado";
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"ID", pOrdenCompraDTO.ID);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"FECHA_ORDEN", pOrdenCompraDTO.FechaOrden);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"ID_CLIENTE", pOrdenCompraDTO.IdCliente);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"TOTAL", pOrdenCompraDTO.Total);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"SUBTOTAL", pOrdenCompraDTO.SubTotal);

                    db.ExecuteNonQuery(cmdFacturaEncabezado);

                    //recorre la lista de DetalleOrden en OrdenCompraDTO para agregarlos uno por uno
                    // a la base de datos

                    foreach (DetalleOrden detalleOrden in pOrdenCompraDTO.listaDetalles)
                    {
                        cmdFacturaDetalle.Parameters.AddWithValue(@"ID_ORDEN", detalleOrden.IdOrden);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"ID_DETALLE", detalleOrden.IdDetalle);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"ID_PRODUCTO", detalleOrden.IdProducto);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"CANTIDAD", detalleOrden.Cantidad);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"TOTAL_DETALLE", detalleOrden.Total);

                        cmdFacturaDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdFacturaDetalle.CommandText = "InsertarDetalle";
                        db.ExecuteNonQuery(cmdFacturaDetalle);

                        //rebaja la cantidad de inventario en base a la cantidad de producto que se
                        //compraron

                        cmdProducto.Parameters.AddWithValue(@"ID", detalleOrden.IdProducto);
                        cmdProducto.Parameters.AddWithValue(@"CANTIDAD", detalleOrden.Cantidad);

                        cmdProducto.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdProducto.CommandText = "RestarCantidadProductos";
                        db.ExecuteNonQuery(cmdProducto);
                    }
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

        private OrdenCompraDTO GetFactura(double pNumeroFactura)
        {
            OrdenCompraDTO ordenCompraDTO= new OrdenCompraDTO();
            DataSet ds = null;
            IDALCliente _DALCliente = new DALCliente();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GetFactura";
                    command.Parameters.AddWithValue(@"IdOrdenCompra", pNumeroFactura);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    ordenCompraDTO = new OrdenCompraDTO()
                    {
                        ID = (int)dr["ID"],
                        FechaOrden = (DateTime)dr["FECHA_ORDEN"],
                        IdCliente = (int)dr["ID_CLIENTE"],
                        Total = (double)dr["TOTAL"],
                        SubTotal = (double)dr["SUBTOTAL"]
                    };

                    foreach(var item in ds.Tables[0].Rows)
                    {
                        DetalleOrden detalleOrden = new DetalleOrden();
                        detalleOrden.IdOrden = (int)dr["ID_ORDEN"];
                        detalleOrden.IdDetalle = (int)dr["ID_DETALLE"];
                        detalleOrden.IdProducto = (int)dr["ID_PRODUCTO"];
                        detalleOrden.Cantidad = (int)dr["CANTIDAD"];
                        detalleOrden.Total = (double)dr["TOTAL_DETALLE"];

                        ordenCompraDTO.listaDetalles.Add(detalleOrden);
                    }
                }
                return ordenCompraDTO;
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
