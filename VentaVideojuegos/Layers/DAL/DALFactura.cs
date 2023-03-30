﻿using System;
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
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;

            string sql = @"Select current_value from sys.sequences where name = 'SequenceNoFactura'";

            DataTable dt = null;

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    //ds = db.ExecuteReader(command, "query");
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
            IDbCommand command = new SqlCommand();
            int numeroFactura = 0;

            string sql = @"SELECT NEXT VALUE FOR SequenceNoFactura";

            DataTable dt = null;

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    //ds = db.ExecuteReader(command, "query");
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

        public OrdenCompraDTO SaveFactura(OrdenCompraDTO pOrdenCompraDTO)
        {
            OrdenCompraDTO ordenCompraDTO = null;
            string sqlEncabezado = "";
            string sqlDetalle = "";
            string sqlProducto = "";

            SqlCommand cmdFacturaEncabezado = new SqlCommand();
            SqlCommand cmdFacturaDetalle = new SqlCommand();
            SqlCommand cmdProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();
            double rows = 0;

            //agrega a la base de datos la orden de compra

            sqlEncabezado = @"Insert into ORDEN_COMPRA values (@ID, @FECHA_ORDEN, @ID_CLIENTE, 
            @TOTAL, @SUBTOTAL)";

            try
            {
                cmdFacturaEncabezado.Parameters.AddWithValue(@"ID", pOrdenCompraDTO.ID);
                cmdFacturaEncabezado.Parameters.AddWithValue(@"FECHA_ORDEN", pOrdenCompraDTO.FechaOrden);
                cmdFacturaEncabezado.Parameters.AddWithValue(@"ID_CLIENTE", pOrdenCompraDTO.IdCliente);
                cmdFacturaEncabezado.Parameters.AddWithValue(@"TOTAL", pOrdenCompraDTO.Total);
                cmdFacturaEncabezado.Parameters.AddWithValue(@"SUBTOTAL", pOrdenCompraDTO.SubTotal);
                cmdFacturaEncabezado.CommandText= sqlEncabezado;
                cmdFacturaEncabezado.CommandType= CommandType.Text;

                listaCommands.Add(cmdFacturaEncabezado);

                //recorre la lista de DetalleOrden en OrdenCompraDTO para agregarlos uno por uno
                // a la base de datos

                sqlDetalle = @"Insert into DETALLE values (@ID_ORDEN, @ID_DETALLE, @ID_PRODUCTO, 
                @CANTIDAD, @TOTAL_DETALLE )";

                foreach(DetalleOrden detalleOrden in pOrdenCompraDTO.listaDetalles)
                {
                    cmdFacturaDetalle.Parameters.AddWithValue(@"ID_ORDEN", detalleOrden.IdOrden);
                    cmdFacturaDetalle.Parameters.AddWithValue(@"ID_DETALLE", detalleOrden.IdDetalle);
                    cmdFacturaDetalle.Parameters.AddWithValue(@"ID_PRODUCTO", detalleOrden.IdProducto);
                    cmdFacturaDetalle.Parameters.AddWithValue(@"CANTIDAD", detalleOrden.Cantidad);
                    cmdFacturaDetalle.Parameters.AddWithValue(@"TOTAL_DETALLE", detalleOrden.Total);

                    cmdFacturaDetalle.CommandText= sqlDetalle;
                    cmdFacturaDetalle.CommandType= CommandType.Text;
                    listaCommands.Add(cmdFacturaDetalle);

                    //rebaja la cantidad de inventario en base a la cantidad de producto que se
                    //compraron

                    cmdProducto.Parameters.AddWithValue(@"ID", detalleOrden.IdProducto);
                    cmdProducto.Parameters.AddWithValue(@"CANTIDAD", detalleOrden.Cantidad);

                    sqlProducto = @"Update PRODUCTO 
                    SET CANTIDAD_INVENTARIO = CANTIDAD_INVENTARIO - @CANTIDAD
                    where ID = @ID";

                    cmdProducto.CommandText= sqlProducto;
                    cmdProducto.CommandType= CommandType.Text;
                    listaCommands.Add(cmdProducto);
                }
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //rows = db.ExecuteNonQuery(listaCommands, IsolationLevel.ReadCommitted);
                }

                if (rows == 0)
                {
                    throw new Exception("No se pudo salvar correctamente la factura");
                }
                else
                {
                    ordenCompraDTO = GetFactura(pOrdenCompraDTO.ID);
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

        private OrdenCompraDTO GetFactura(double pNumeroFactura)
        {
            OrdenCompraDTO ordenCompraDTO= new OrdenCompraDTO();
            DataSet ds = null;
            IDALCliente _DALCliente = new DALCliente();
            SqlCommand command = new SqlCommand();

            string sql = @"Select ORDEN_COMPRA.ID, ORDEN_COMPRA.FECHA_ORDEN, ORDEN_COMPRA.ID_CLIENTE, ORDEN_COMPRA.TOTAL, ORDEN_COMPRA.SUBTOTAL,
            DETALLE.ID_ORDEN, DETALLE.ID_DETALLE, DETALLE.ID_PRODUCTO, DETALLE.CANTIDAD, 
            DETALLE.TOTAL_DETALLE
            from ORDEN_COMPRA INNER JOIN DETALLE ON ORDEN_COMPRA.ID = DETALLE.ID_ORDEN
            where ORDEN_COMPRA.ID = @IdOrdenCompra";

            try
            {
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue(@"IdOrdenCompra", pNumeroFactura);

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //ds = db.ExecuteReader(command, "query");
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
