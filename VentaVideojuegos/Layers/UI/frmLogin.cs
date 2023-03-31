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

            if (_BLLLogin.Login(txtUsuario.Text, txtPassword.Text))
            {
                Usuario usuario= _BLLLogin.GetUsuarioByFilter(txtUsuario.Text);

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
    }
}
