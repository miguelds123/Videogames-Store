using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos
{
    internal class DALLogin : IDALLogin
    {
        public bool Login(string pUsuario, string pContrasena)
        {
            try
            {
                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(pUsuario, pContrasena)))
                {
                    // Si esto da error es porque el usuario no existe! 
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
