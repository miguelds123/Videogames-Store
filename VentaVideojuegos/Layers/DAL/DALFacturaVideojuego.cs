using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos.Layers.DAL
{
    /// <summary>
    /// Clase DALFacturaVideojuego que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla OrdenCompraVideojuego y DetalleVideojuego de la base de datos
    /// </summary>

    class DALFacturaVideojuego
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALFacturaVideojuego()
        {
            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Metodo que obtiene de la base de datos el numero actual de la secuencia 
        /// NoFactura
        /// </summary>
        /// <returns>un int con el numero actual en el que se encuentra la secuencia</returns>

        public int GetCurrentNumeroFactura()
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
                    command.CommandText = "GetCurrentNumeroFactura";

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

        /// <summary>
        /// Metodo que obtiene de la base de datos el siguiente numero de la secuencia 
        /// NoFactura
        /// </summary>
        /// <returns>un int con el siguiente numero en el que se encuentra la secuencia</returns>

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

        /// <summary>
        /// Metodo que almacena la informacion de una instancia de la clase OrdenCompraDTO
        /// como campos de las tablas OrdenCompraVideojuego y DetalleVideojuego en la base de datos
        /// </summary>
        /// <param name="pOrdenCompraDTO">instancia de la clase OrdenCompraDTO que sera almacenada
        /// en la base de datos</param>

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
                    cmdFacturaEncabezado.CommandText = "InsertarEncabezadoVideojuego";
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"ID", pOrdenCompraDTO.ID);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"FECHA_ORDEN", pOrdenCompraDTO.FechaOrden);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"ID_CLIENTE", pOrdenCompraDTO.IdCliente);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"TOTAL", pOrdenCompraDTO.Total);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"SUBTOTAL", pOrdenCompraDTO.SubTotal);
                    cmdFacturaEncabezado.Parameters.AddWithValue(@"TOTAL_DOLARES", pOrdenCompraDTO.TotalDolares);

                    db.ExecuteNonQuery(cmdFacturaEncabezado);

                    //recorre la lista de DetalleOrden en OrdenCompraDTO para agregarlos uno por uno
                    // a la base de datos

                    foreach (DetalleOrden detalleOrden in pOrdenCompraDTO.listaDetalles)
                    {
                        cmdFacturaDetalle = new SqlCommand();

                        cmdFacturaDetalle.Parameters.AddWithValue(@"ID_ORDEN", detalleOrden.IdOrden);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"ID_DETALLE", detalleOrden.IdDetalle);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"ID_PRODUCTO", detalleOrden.IdProducto);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"CANTIDAD", detalleOrden.Cantidad);
                        cmdFacturaDetalle.Parameters.AddWithValue(@"TOTAL_DETALLE", detalleOrden.Total);

                        cmdFacturaDetalle.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdFacturaDetalle.CommandText = "InsertarDetalleVideojuego";
                        db.ExecuteNonQuery(cmdFacturaDetalle);

                        //rebaja la cantidad de inventario en base a la cantidad de producto que se
                        //compraron

                        cmdProducto = new SqlCommand();

                        cmdProducto.Parameters.AddWithValue(@"ID", detalleOrden.IdProducto);
                        cmdProducto.Parameters.AddWithValue(@"CANTIDAD", detalleOrden.Cantidad);

                        cmdProducto.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdProducto.CommandText = "RestarCantidadVideojuego";
                        db.ExecuteNonQuery(cmdProducto);
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

        /// <summary>
        /// Metodo que retorna una instancia de la clase OrdenCompraDTO con la informacion 
        /// que contiene el campo de la base de datos que coinicide con el id del
        /// parametro
        /// </summary>
        /// <param name="pNumeroFactura">string que contiene el id a buscar
        /// en la base de datos</param>
        /// <returns>Una instacia de la clase OrdenCompraDTO con la informacion de las tablas
        /// OrdenCompraVideojuego y DetalleVideojuego cuyos campos id hayan coincidido con el parametro</returns>

        public OrdenCompraDTO GetFactura(double pNumeroFactura)
        {
            OrdenCompraDTO ordenCompraDTO = new OrdenCompraDTO();
            DataSet ds = null;
            IDALCliente _DALCliente = new DALCliente();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GetFacturaVideojuego";
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
                        SubTotal = (double)dr["SUBTOTAL"],
                        TotalDolares= (double)dr["TOTAL_DOLARES"]
                    };

                    foreach (var item in ds.Tables[0].Rows)
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
    }
}
