﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.BLL;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmReservacion : Form
    {
        Reservacion reservacion= new Reservacion();

        public frmReservacion()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIDCliente.Text = string.Empty;
            txtIDReservacion.Text = string.Empty;
            txtIDProducto.Text = string.Empty;
            txtAdelanto.Text = string.Empty;

            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;
            btnCancelar.Enabled = true;

            btnNuevo.Enabled = false;

            BLLReservacion _BLLReservacion= new BLLReservacion();

            txtIDReservacion.Text = _BLLReservacion.GetNextNumeroReservacion().ToString();

            txtAdelanto.Text = "0";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtIDCliente.Text))
            {
                MessageBox.Show("Debe digitar la identificacion del cliente");
                txtIDCliente.Focus();
                return;
            }

            BLLCliente _BLLCliente = new BLLCliente();

            List<Cliente> lista = _BLLCliente.GetAllCliente();

            bool estado= false;

            foreach (Cliente cliente in lista)
            {
                if (cliente.ID == Convert.ToInt32(txtIDCliente.Text))
                {
                    estado= true;
                }
            }

            if (estado)
            {
                txtIDCliente.Enabled = false;
                txtIDProducto.Enabled = true;
                btnConfirmarProducto.Enabled = true;
                btnConfirmar.Enabled = false;
            }
            else
            {
                MessageBox.Show("El cliente que selecciono no es valido");
            }
        }

        private void btnConfirmarProducto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIDProducto.Text))
            {
                MessageBox.Show("Debe digitar el id del producto que desea reservar");
                txtIDProducto.Focus();
                return;
            }

            BLLProducto _BLLProducto= new BLLProducto();

            List<Producto> lista= _BLLProducto.GetAllProducto();

            bool estado= false;

            foreach (Producto p in lista)
            {
                if (p.ID == Convert.ToInt32(txtIDProducto.Text))
                {
                    estado= true;
                }
            }

            if (estado)
            {
                Producto producto;

                try
                {
                    producto = _BLLProducto.GetProductoById(Double.Parse(txtIDProducto.Text));
                }
                catch
                {
                    MessageBox.Show("El producto que usted selecciono no es valido");
                    return;
                }

                txtAdelanto.Text = (producto.PrecioColones * 0.5).ToString();

                btnReservar.Enabled = true;
                txtIDProducto.Enabled = false;
                btnConfirmarProducto.Enabled = false;
            }
            else
            {
                MessageBox.Show("El producto que selecciono no es valido");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnReservar.Enabled = false;
            btnReservar.Enabled = false;
            btnConfirmarProducto.Enabled = false;
            txtIDReservacion.Enabled = false;
            txtIDProducto.Enabled = false;
            txtAdelanto.Enabled = false;

            txtIDCliente.Text = string.Empty;
            txtIDProducto.Text = string.Empty;

            txtAdelanto.Text = "0";

            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;

            btnNuevo.Enabled = false;
        }

        private void frmReservacion_Load(object sender, EventArgs e)
        {
            this.Text = "Reservacion Productos";

            btnReservar.Enabled = false;
            btnReservar.Enabled = false;
            btnCancelar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnConfirmarProducto.Enabled = false;
            txtIDCliente.Enabled = false;
            txtIDReservacion.Enabled= false;
            txtIDProducto.Enabled = false;
            txtAdelanto.Enabled = false;

            MessageBox.Show("Recuerde que a la hora de hacer un apartado, debera pagar por adelantado la mitad del precio del producto, ademas de que cualquier descuento que le producto posea, no sera valido");
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLLReservacion _BLLReservacion = new BLLReservacion();
            BLLProducto _BLLProducto = new BLLProducto();

            reservacion.ID = Convert.ToInt32(txtIDReservacion.Text);
            reservacion.IdProducto = Convert.ToInt32(txtIDProducto.Text);
            reservacion.IdCliente = Convert.ToInt32(txtIDCliente.Text);
            reservacion.Adelanto = Convert.ToInt32(txtAdelanto.Text);

            List<Producto> lista = _BLLProducto.GetAllProducto();

            foreach (Producto producto in lista)
            {
                if (Convert.ToUInt32(txtIDProducto.Text) == producto.ID)
                {
                    if (producto.Estado == 1)
                    {
                        if (producto.CantidadInventario >= 1)
                        {
                            try
                            {
                                _BLLReservacion.SaveReservacion(reservacion);

                                MessageBox.Show("Su reservacion a sido realizada con exito");

                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo realizar la reservacion");

                                btnCancelar_Click(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show("En este momento no tenemos suficientes existencias de este producto");
                            txtIDProducto.Enabled = true;
                            btnConfirmarProducto.Enabled = true;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El producto que desea agregar no esta disponible en este momento");
                        txtIDProducto.Enabled = true;
                        btnConfirmarProducto.Enabled = true;
                        return;
                    }
                }
            }
        }
    }
}