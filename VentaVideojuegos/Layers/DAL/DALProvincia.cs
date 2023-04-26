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
    /// <summary>
    /// Clase DALProvincia que contiene todos los metodos necesarios para manejar la
    /// informacion contenida en la tabla Provincia de la base de datos
    /// </summary>

    class DALProvincia : IDALProvincia
    {
        Usuario _Usuario = new Usuario();

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public DALProvincia()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        /// <summary>
        /// Método que retorna un lista de objetos con toda la informacion contenida 
        /// en la tabla Provincia de la base de datos
        /// </summary>
        /// <returns>Una lista de objetos Provincia con la informacion de cada uno de 
        /// los campos de la tabla Provincia</returns>

        public List<Provincia> GetAllProvincia()
        {
            IDataReader reader = null;
            List<Provincia> lista = new List<Provincia>();
            SqlCommand command = new SqlCommand();

            command.CommandText = "PA_SELECT_PROVINCIA_All";
            command.CommandType = System.Data.CommandType.StoredProcedure;

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
