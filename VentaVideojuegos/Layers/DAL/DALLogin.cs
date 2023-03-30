using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    internal class DALLogin : IDALLogin
    {
        Usuario _UsuarioBD = new Usuario();

        public DALLogin()
        {
            //_Usuario.Login = Settings.Default.Login;
            //_Usuario.Password = Settings.Default.Password;

            _UsuarioBD.Login = "sa";
            _UsuarioBD.Password = "123456";
        }

        public void DeleteUsuario(string pId)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_DELETE_USUARIO";
                    command.Parameters.AddWithValue("USUARIO", pId);

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

        public List<Usuario> GetAllUsuario()
        {
            DataSet ds = null;
            List<Usuario> lista = new List<Usuario>();
            SqlCommand command = new SqlCommand();

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_Usuario.Login, _Usuario.Password)))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "PA_SELECT_USUARIO_All";

                    ds = db.ExecuteDataSet(command);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Login= dr["USUARIO"].ToString();
                        usuario.Password = dr["PASSWORD"].ToString();
                        usuario.IdCategoria = (int)dr["ID_CATEGORIA"];
                        usuario.IMAGEN = (byte[])dr["IMAGEN"];

                        lista.Add(usuario);
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

        public Usuario GetUsuarioByFilter(string pDescripcion)
        {
            throw new NotImplementedException();
        }

        public void SaveUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public bool Login(string pUsuario, string pContrasena)
        {
            List < Usuario >

            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(_UsuarioBD.Login, _UsuarioBD.Password)))
                {

                }

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al intentar ingresar");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return false;
            }
        }
    }
}
