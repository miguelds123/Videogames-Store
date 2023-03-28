using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos.Interfaces;
using VentaVideojuegos.Properties;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    class DALProvincia : IDALProvincia
    {
        Usuario _Usuario = new Usuario();
        public DALProvincia()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }
        public List<Provincia> GetAllProvincia()
        {
            IDataReader reader = null;
            List<Provincia> lista = new List<Provincia>();
            SqlCommand command = new SqlCommand();

            string sql = @" select * from  PROVINCIA";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    reader = db.ExecuteReader(command);

                    while (reader.Read())
                    {
                        Provincia provincia = new Provincia()
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            Descripcion = reader["DESCRIPCION"].ToString()
                        };
                        lista.Add(provincia);
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
