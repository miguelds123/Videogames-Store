﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    internal class DALTelefono : IDALTelefono
    {
        Usuario _Usuario = new Usuario();
        public DALTelefono()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        public bool DeleteTelefono(string pId, string pTelefono)
        {
            bool retorno = false;
            double rows = 0d;
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Delete from TELEFONO 
                where (ID_CLIENTE = @IdCliente and TELEFONO like @Telefono)";
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pId));
                command.Parameters.AddWithValue(@"Telefono", pTelefono);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {

                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                    retorno = true;

                return retorno;
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

        public List<Telefono> GetAllTelefono()
        {
            DataSet ds = null;
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Select * from TELEFONO";
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono()
                        {
                            Numero = dr["TELEFONO"].ToString(),
                            IdCliente= (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(telefono);
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

        public List<Telefono> GetTelefonoByFilter(string pNumeroTelefono)
        {
            DataSet ds = null;
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Select * from TELEFONO where TELEFONO.TELEFONO like @Telefono";
                command.Parameters.AddWithValue(@"Telefono", pNumeroTelefono);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono()
                        {
                            Numero = dr["TELEFONO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(telefono);
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

        public List<Telefono> GetTelefonoByIdCliente(string pId)
        {
            DataSet ds = null;
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            try
            {
                string sql = @"Select * from TELEFONO where ID_CLIENTE = @IdCliente";
                command.Parameters.AddWithValue(@"IdCliente", Convert.ToInt64(pId));
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    ds = db.ExecuteReader(command, "query");
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Telefono telefono = new Telefono()
                        {
                            Numero = dr["TELEFONO"].ToString(),
                            IdCliente = (int)dr["ID_CLIENTE"]
                        };

                        lista.Add(telefono);
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

        public List<Telefono> SaveTelefono(Telefono pTelefono)
        {
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            string sql = @"Insert into TELEFONO values (@Telefono, @IdCliente)";

            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"Telefono", pTelefono.Numero);
                command.Parameters.AddWithValue(@"IdCliente", pTelefono.IdCliente);

                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    lista = this.GetTelefonoByIdCliente(pTelefono.IdCliente.ToString());
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

        public List<Telefono> UpdateTelefono(Telefono pTelefono, string pTelefonoViejo, string pIdClienteViejo)
        {
            List<Telefono> lista = new List<Telefono>();
            SqlCommand command = new SqlCommand();

            string sql = @"Update TELEFONO Set TELEFONO = @TelefonoNuevo, ID_CLIENTE = @IdClienteNuevo
            where TELEFONO = @TelefonoViejo and ID_CLIENTE = @IdClienteViejo";

            double rows = 0;

            try
            {
                command.Parameters.AddWithValue(@"TelefonoNuevo", pTelefono.Numero);
                command.Parameters.AddWithValue(@"IdClienteNuevo", pTelefono.IdCliente);
                command.Parameters.AddWithValue(@"TelefonoViejo", pTelefonoViejo);
                command.Parameters.AddWithValue(@"IdClienteViejo", Convert.ToInt64(pIdClienteViejo));

                command.CommandText = sql;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    rows = db.ExecuteNonQuery(command, IsolationLevel.ReadCommitted);
                }

                if (rows > 0)
                {
                    lista = this.GetTelefonoByIdCliente(pTelefono.IdCliente.ToString());
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
    }
}