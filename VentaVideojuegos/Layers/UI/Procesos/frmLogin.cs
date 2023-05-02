using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmLogin : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLLogin _BLLLogin= new BLLLogin();

            string truncatedString = Encriptado.GetSHA256(txtPassword.Text).Substring(0, Math.Min(Encriptado.GetSHA256(txtPassword.Text).Length, 32));

            try
            {
                if (_BLLLogin.Login(txtUsuario.Text, truncatedString))
                {
                    Usuario usuario = _BLLLogin.GetUsuarioByFilter(txtUsuario.Text);

                    UsuarioIniciado.usuarioLogin.Clear();

                    UsuarioIniciado.usuarioLogin.Add(usuario);

                    MessageBox.Show("Su usuario y su coontraseña son correctos. Bienvenido");

                    this.Close();
                }
                else
                {
                    string message = ("Su usuario y su coontraseña son incorrectos. Por favor intentelo de nuevo");
                    _MyLogControlEventos.Error(message.ToString());
                    MessageBox.Show(message);
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    return;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtPassword.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Porfavor inicie sesion, de lo contrario, no podra hacer uso del programa, si no posee un usuario, por favor contactese con el administrador");

            this.Text = "Login";
        }
    }
}
