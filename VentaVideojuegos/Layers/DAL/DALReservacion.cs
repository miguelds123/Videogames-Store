﻿using System;
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
    class DALReservacion : IDALReservacion
    {
        Usuario _Usuario = new Usuario();
        public DALReservacion()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public void DeleteReservacion(string pId)
        {
            Reservacion reservacion= null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reservacion = GetReservacionById(pId);

                    commandReservacion.CommandType = System.Data.CommandType.StoredProcedure;
                    commandReservacion.CommandText = "PA_DELETE_RESERVACION_ByID";
                    commandReservacion.Parameters.AddWithValue("@ID", Convert.ToInt64(pId));
                    listaCommands.Add(commandReservacion);

                    commandProducto.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProducto.CommandText = "PA_AUMENTAR_CANTIDAD_PRODUCTO";
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

        public List<Reservacion> GetAllReservacion()
        {
            DataSet ds = null;
            List<Reservacion> lista = new List<Reservacion>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_RESERVACION_All";

                    ds = db.ExecuteDataSet(command);
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
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_RESERVACION_ByID";

                    ds = db.ExecuteDataSet(command);
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
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(@"ID_CLIENTE", Convert.ToInt64(pId));
                    command.CommandText = "PA_SELECT_RESERVACION_ByIdCliente";

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

        public void SaveReservacion(Reservacion pReservacion)
        {
            Reservacion reservacion= null;
            SqlCommand commandReservacion = new SqlCommand();
            SqlCommand commandProducto = new SqlCommand();
            List<IDbCommand> listaCommands = new List<IDbCommand>();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    //realiza el insert de la reservacion

                    commandReservacion.CommandType = System.Data.CommandType.StoredProcedure;
                    commandReservacion.CommandText = "PA_INSERT_RESERVACION";
                    commandReservacion.Parameters.AddWithValue(@"ID", pReservacion.ID);
                    commandReservacion.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                    commandReservacion.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                    commandReservacion.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);
                    listaCommands.Add(commandReservacion);

                    //rebaja la cantidad de inventario en base a la cantidad de producto que se
                    //compraron

                    commandProducto.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProducto.CommandText = "PA_DISMINUIR_CANTIDAD_PRODUCTO";
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

        public void UpdateReservacion(Reservacion pReservacion)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_UPDATE_RESERVACION";
                    command.Parameters.AddWithValue(@"ID", pReservacion.ID);
                    command.Parameters.AddWithValue(@"ID_CLIENTE", pReservacion.IdCliente);
                    command.Parameters.AddWithValue(@"ID_PRODUCTO", pReservacion.IdProducto);
                    command.Parameters.AddWithValue(@"ADELANTO", pReservacion.Adelanto);

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
