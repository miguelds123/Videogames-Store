﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.UI;
using VentaVideojuegos.Layers.UI.Reportes;

namespace VentaVideojuegos
{
    public partial class frmPrincipal : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

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

                mantenimientosToolStripMenuItem.Enabled = false;
                procesosToolStripMenuItem.Enabled = false;
                reportesToolStripMenuItem.Enabled = false;
                administracionToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                string message = ("Ocurrio el siguiente error: " + ex.Message);

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void validarDerechos()
        {
            Usuario usuario = new Usuario();

            try
            {
                usuario = UsuarioIniciado.usuarioLogin[0];
            }
            catch(Exception ex)
            {
                string message = "Porfavor inicie sesion " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }

            if (usuario.IdCategoria == 1)
            {
                mantenimientosToolStripMenuItem.Enabled = true;
                procesosToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;
                administracionToolStripMenuItem.Enabled = true;

                mantenimientosToolStripMenuItem.Visible = true;
                procesosToolStripMenuItem.Visible = true;
                reportesToolStripMenuItem.Visible = true;
                administracionToolStripMenuItem.Visible = true;
            }
            else
            {
                if (usuario.IdCategoria == 2)
                {
                    mantenimientosToolStripMenuItem.Enabled = true;
                    procesosToolStripMenuItem.Enabled = true;
                    reportesToolStripMenuItem.Enabled = true;
                    administracionToolStripMenuItem.Enabled = true;

                    mantenimientosToolStripMenuItem.Visible = false;
                    reportesToolStripMenuItem.Visible = false;
                    procesosToolStripMenuItem.Visible = true;
                }
                else
                {
                    if (usuario.IdCategoria == 3)
                    {
                        mantenimientosToolStripMenuItem.Enabled = true;
                        procesosToolStripMenuItem.Enabled = true;
                        reportesToolStripMenuItem.Enabled = true;
                        administracionToolStripMenuItem.Enabled = true;

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
                string message = "Hubo un error al abrir el frame " + ex.Message; 

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
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
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void reservarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReservacion frmReservacion = new frmReservacion();

            try
            {
                frmReservacion = new frmReservacion();
                frmReservacion.MdiParent = this;
                frmReservacion.Show();
            }
            catch (Exception ex)
            {
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void listaDeseosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaDeseos frmListaDeseos= new frmListaDeseos();

            try
            {
                frmListaDeseos.MdiParent = this;
                frmListaDeseos.Show();
            }
            catch (Exception ex)
            {
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void videojuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoVideojuego frmMantenimientoVideojuego = new frmMantenimientoVideojuego();

            try
            {
                frmMantenimientoVideojuego.MdiParent = this;
                frmMantenimientoVideojuego.Show();
            }
            catch (Exception ex)
            {
                string message= "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFiltroReporteProducto frmFiltroReporteProducto = new frmFiltroReporteProducto();

            try
            {
                frmFiltroReporteProducto.MdiParent = this;
                frmFiltroReporteProducto.Show();
            }
            catch (Exception ex)
            {
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void videojuegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroReporteVideojuego frmFiltroReporteVideojuego = new frmFiltroReporteVideojuego();

            try
            {
                frmFiltroReporteVideojuego.MdiParent = this;
                frmFiltroReporteVideojuego.Show();
            }
            catch (Exception ex)
            {
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroReporteOrdenCompraProducto frmFiltroReporteOrdenCompraProducto = new frmFiltroReporteOrdenCompraProducto();

            try
            {
                frmFiltroReporteOrdenCompraProducto.MdiParent = this;
                frmFiltroReporteOrdenCompraProducto.Show();
            }
            catch (Exception ex)
            {
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFiltroReporteCantidadProductosVendidos frmFiltroReporteCantidadProductosVendidos = new frmFiltroReporteCantidadProductosVendidos();

            try
            {
                frmFiltroReporteCantidadProductosVendidos.MdiParent = this;
                frmFiltroReporteCantidadProductosVendidos.Show();
            }
            catch (Exception ex)
            {
                string message = "Hubo un error al abrir el frame " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void mantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
