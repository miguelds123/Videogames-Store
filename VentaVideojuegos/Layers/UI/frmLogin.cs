using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLLogin _BLLLogin= new BLLLogin();

            string truncatedString = Encriptado.GetSHA256(txtPassword.Text).Substring(0, Math.Min(Encriptado.GetSHA256(txtPassword.Text).Length, 32));

            if (_BLLLogin.Login(txtUsuario.Text, truncatedString))
            {
                Usuario usuario= _BLLLogin.GetUsuarioByFilter(txtUsuario.Text);

                UsuarioIniciado.usuarioLogin.Clear();

                UsuarioIniciado.usuarioLogin.Add(usuario);

                MessageBox.Show("Su usuario y su coontraseña son correctos. Bienvenido");

                this.Close();
            }
            else
            {
                MessageBox.Show("Su usuario y su coontraseña son incorrectos. Por favor intentelo de nuevo");
                txtUsuario.Clear();
                txtPassword.Clear();
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
        }
    }
}
