using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;
using VentaVideojuegos.Layers.Entities;
using VentaVideojuegos.Properties;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    class DALDistrito : IDALDistrito
    {
        Usuario _Usuario = new Usuario();
        public DALDistrito()
        {
            _Usuario.Login = Settings.Default.Login;
            _Usuario.Password = Settings.Default.Password;
        }
        public List<Distrito> GetAllProvincia()
        {
            IDataReader reader = null;
            List<Distrito> lista = new List<Distrito>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from  DISTRITO ";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Distrito distrito = new Distrito()
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            IdProvincia = int.Parse(reader["ID_PROVINCIA"].ToString()),
                            IdDistrito = int.Parse(reader["ID_CANTON"].ToString()),
                            Descripcion = reader["DESCRIPCION"].ToString()
                        };
                        lista.Add(distrito);
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
    }
}
