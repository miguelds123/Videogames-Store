using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.UI;

namespace VentaVideojuegos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Principal";

                Utilitarios.CultureInfo();

                abrirLogin();

                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex.Message);
                return;
            }
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComprar frmComprar= new frmComprar();

            try
            {
                frmComprar.MdiParent= this;
                frmComprar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente frmMantenimientoCliente;

            try
            {
                frmMantenimientoCliente= new frmMantenimientoCliente();
                frmMantenimientoCliente.MdiParent = this;
                frmMantenimientoCliente.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoProductos frmMantenimientoProductos;

            try
            {
                frmMantenimientoProductos = new frmMantenimientoProductos();
                frmMantenimientoProductos.MdiParent = this;
                frmMantenimientoProductos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void telefonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoTelefono frmMantenimientoTelefono;

            try
            {
                frmMantenimientoTelefono = new frmMantenimientoTelefono();
                frmMantenimientoTelefono.MdiParent = this;
                frmMantenimientoTelefono.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void abrirLogin()
        {
            frmLogin frmLogin = new frmLogin();

            try
            {
                frmLogin = new frmLogin();
                frmLogin.MdiParent = this;
                frmLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void validarDerechos()
        {
            Usuario usuario = new Usuario();

            usuario = UsuarioIniciado.usuarioLogin[0];

            if (usuario.IdCategoria == 1)
            {
                mantenimientosToolStripMenuItem.Visible = true;
                procesosToolStripMenuItem.Visible = true;
                reportesToolStripMenuItem.Visible = true;
                administracionToolStripMenuItem.Visible = true;
            }
            else
            {
                if (usuario.IdCategoria == 2)
                {
                    mantenimientosToolStripMenuItem.Visible = false;
                    reportesToolStripMenuItem.Visible = false;
                    procesosToolStripMenuItem.Visible = true;
                }
                else
                {
                    if (usuario.IdCategoria == 3)
                    {
                        mantenimientosToolStripMenuItem.Visible = false;
                        procesosToolStripMenuItem.Visible = false;
                        reportesToolStripMenuItem.Visible = true;
                    }
                }
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();

            try
            {
                frmLogin = new frmLogin();
                frmLogin.MdiParent = this;
                frmLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            validarDerechos();
        }

        private void usuariosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmMantenimientoUsuario frmMantenimientoUsuario = new frmMantenimientoUsuario();

            try
            {
                frmMantenimientoUsuario = new frmMantenimientoUsuario();
                frmMantenimientoUsuario.MdiParent = this;
                frmMantenimientoUsuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }

        private void correoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCorreo frmMantenimientoCorreo= new frmMantenimientoCorreo();

            try
            {
                frmMantenimientoCorreo = new frmMantenimientoCorreo();
                frmMantenimientoCorreo.MdiParent = this;
                frmMantenimientoCorreo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }
    }
}
