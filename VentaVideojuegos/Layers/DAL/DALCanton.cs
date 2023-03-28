using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Properties;
using VentaVideojuegos.Layers.Entities;
using System.Windows.Forms;

namespace VentaVideojuegos.Layers.DAL
{
    class DALCanton : IDALCanton
    {
        Usuario _Usuario = new Usuario();
        public DALCanton()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }
        public List<Canton> GetAllCanton()
        {
            IDataReader reader = null;
            List<Canton> lista = new List<Canton>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from  CANTON ";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Canton canton = new Canton()
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            IdProvincia = int.Parse(reader["ID_PROVINCIA"].ToString()),
                            Descripcion = reader["DESCRIPCION"].ToString()
                        };
                        lista.Add(canton);
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
