﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.UI.Reportes;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmComprar : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        static int numeroDetalle = 1;
        double varSubTotal = 0;
        double varTotal = 0;
        double varDescuento = 0;
        double varDescuentoTotal = 0;
        OrdenCompraDTO ordenCompraDTO = new OrdenCompraDTO();

        public frmComprar()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIDCliente.Text = string.Empty;
            txtIDFactura.Text = string.Empty;
            txtIDProducto.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            rdbProducto.Enabled = true;
            rdbVideojuego.Enabled = true;
            btnCancelar.Enabled = true;

            btnNuevo.Enabled = false;

            BLLFactura _BLLFactura= new BLLFactura();

            txtIDFactura.Text = _BLLFactura.GetNextNumeroFactura().ToString();

            txtSubtotal.Text = "0";

            txtTotal.Text="0";

            numeroDetalle = 1;

            dgvDatos.Rows.Clear();
        }

        private void frmComprar_Load(object sender, EventArgs e)
        {
            this.Text = "Compras Productos";

            btnComprar.Enabled = false;
            btnAgregar.Enabled = false;
            btnCancelar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnConfirmarProducto.Enabled = false;
            txtIDCliente.Enabled = false;
            txtIDFactura.Enabled = false;
            txtIDProducto.Enabled = false;
            txtSubtotal.Enabled = false;
            txtTotal.Enabled = false;
            txtCantidad.Enabled = false;
            rdbProducto.Enabled = false;
            rdbVideojuego.Enabled = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIDCliente.Text))
            {
                MessageBox.Show("Debe digitar la identificacion del cliente");
                txtIDCliente.Focus();
                return;
            }

            try
            {
                int num = Convert.ToInt32(txtIDCliente.Text);
            }
            catch (Exception ex)
            {
                string message = ("El id debe estar compuesto de numero enteros");
                _MyLogControlEventos.Error(message.ToString());
                MessageBox.Show(message);
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
                    estado = true; 
                }
            }

            if (estado)
            {
                txtIDCliente.Enabled = false;
                txtIDProducto.Enabled = true;
                txtCantidad.Enabled = true;
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
            if (rdbProducto.Checked)
            {
                if (String.IsNullOrEmpty(txtIDProducto.Text))
                {
                    MessageBox.Show("Debe digitar el id del producto que desea comprar");
                    txtIDProducto.Focus();
                    return;
                }

                if (String.IsNullOrEmpty(txtCantidad.Text))
                {
                    MessageBox.Show("Debe digitar la cantidad de productos que desea comprar");
                    txtCantidad.Focus();
                    return;
                }

                try
                {
                    int num = Convert.ToInt32(txtIDProducto.Text);
                }
                catch (Exception ex)
                {
                    string message = ("El id debe estar compuesto de numero enteros");
                    _MyLogControlEventos.Error(message.ToString());
                    MessageBox.Show(message);
                    txtIDProducto.Focus();
                    return;
                }

                try
                {
                    int num = Convert.ToInt32(txtCantidad.Text);
                }
                catch (Exception ex)
                {
                    string message = ("La cantidad debe estar compuesta de numeros enteros");
                    _MyLogControlEventos.Error(message.ToString());
                    MessageBox.Show(message);
                    txtCantidad.Focus();
                    return;
                }

                BLLProducto _BLLProducto = new BLLProducto();

                List<Producto> lista = _BLLProducto.GetAllProducto();

                bool estado = false;

                foreach (Producto p in lista)
                {
                    if (p.ID == Convert.ToInt32(txtIDProducto.Text))
                    {
                        estado = true;
                    }
                }

                if (estado)
                {
                    btnAgregar.Enabled = true;
                    txtIDProducto.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnConfirmarProducto.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El producto que selecciono no es valido");
                }
            }
            else
            {
                if (rdbVideojuego.Checked)
                {
                    if (String.IsNullOrEmpty(txtIDProducto.Text))
                    {
                        MessageBox.Show("Debe digitar el id del videojuego que desea comprar");
                        txtIDProducto.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtCantidad.Text))
                    {
                        MessageBox.Show("Debe digitar la cantidad de videojuegos que desea comprar");
                        txtCantidad.Focus();
                        return;
                    }

                    try
                    {
                        int num = Convert.ToInt32(txtIDProducto.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = ("El id debe estar compuesto de numero enteros");
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtIDProducto.Focus();
                        return;
                    }

                    try
                    {
                        int num = Convert.ToInt32(txtCantidad.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = ("La cantidad debe estar compuesta de numeros enteros");
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtCantidad.Focus();
                        return;
                    }

                    BLLVideojuego _BLLVideojuego= new BLLVideojuego();

                    List<Videojuego> lista = _BLLVideojuego.GetAllVideojuego();

                    bool estado = false;

                    foreach (Videojuego v in lista)
                    {
                        if (v.ID == Convert.ToInt32(txtIDProducto.Text))
                        {
                            estado = true;
                        }
                    }

                    if (estado)
                    {
                        btnAgregar.Enabled = true;
                        txtIDProducto.Enabled = false;
                        txtCantidad.Enabled = false;
                        btnConfirmarProducto.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El videojuego que selecciono no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de lo que desea comprar");
                    rdbProducto.Focus();
                    return;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnComprar.Enabled = false;
            btnAgregar.Enabled = false;
            btnConfirmarProducto.Enabled = false;
            txtIDFactura.Enabled = false;
            txtIDProducto.Enabled = false;
            txtSubtotal.Enabled = false;
            txtTotal.Enabled = false;
            txtCantidad.Enabled = false;

            txtIDCliente.Text = string.Empty;
            txtIDProducto.Text = string.Empty;
            txtCantidad.Text = string.Empty;

            rdbProducto.Checked = false;
            rdbVideojuego.Checked = false;
            rdbProducto.Enabled = true;
            rdbVideojuego.Enabled = true;
           

            txtSubtotal.Text = "0";

            txtTotal.Text = "0";

            numeroDetalle = 1;

            btnNuevo.Enabled = false;

            dgvDatos.Rows.Clear();

            numeroDetalle = 1;
            varSubTotal = 0;
            varTotal= 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (rdbProducto.Checked)
            {
                BLLProducto _BLLProducto = new BLLProducto();
                DetalleOrden detalleOrden = new DetalleOrden();

                detalleOrden.IdOrden = Convert.ToInt32(txtIDFactura.Text);
                detalleOrden.IdDetalle = numeroDetalle;
                detalleOrden.IdProducto = Convert.ToInt32(txtIDProducto.Text);
                detalleOrden.Cantidad = Convert.ToInt32(txtCantidad.Text);

                List<Producto> lista = _BLLProducto.GetAllProducto();

                foreach (Producto producto in lista)
                {
                    if (Convert.ToUInt32(txtIDProducto.Text) == producto.ID)
                    {
                        if (producto.Estado == 1)
                        {
                            if (producto.CantidadInventario >= Convert.ToInt32(txtCantidad.Text))
                            {
                                detalleOrden.Total = (producto.PrecioColones - producto.Descuento) * detalleOrden.Cantidad;

                                varDescuento += producto.Descuento * detalleOrden.Cantidad;
                            }
                            else
                            {
                                MessageBox.Show("En este momento no tenemos suficientes existencias de este producto, el numero maximo que puede comprar es: " + producto.CantidadInventario);
                                txtCantidad.Enabled = true;
                                txtIDProducto.Enabled = true;
                                btnConfirmarProducto.Enabled = true;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El producto que desea agregar no esta disponible en este momento");
                            txtCantidad.Enabled = true;
                            txtIDProducto.Enabled = true;
                            btnConfirmarProducto.Enabled = true;
                            return;
                        }
                    }
                }

                string[] detalleDataGrid =
                {
                detalleOrden.IdDetalle.ToString(),
                detalleOrden.IdProducto.ToString(),
                detalleOrden.Cantidad.ToString(),
                varDescuento.ToString(),
                detalleOrden.Total.ToString(),
            };

                ordenCompraDTO.listaDetalles.Add(detalleOrden);
                dgvDatos.Rows.Add(detalleDataGrid);

                numeroDetalle++;

                btnComprar.Enabled = true;

                varSubTotal += detalleOrden.Total;
                txtSubtotal.Text = (varSubTotal + varDescuento).ToString();

                varTotal += detalleOrden.Total;
                txtTotal.Text = varTotal.ToString();

                varDescuentoTotal += varDescuento;
                varDescuento = 0;

                txtIDProducto.Enabled = true;
                txtCantidad.Enabled = true;
                btnConfirmarProducto.Enabled = true;
                btnAgregar.Enabled = false;
            }
            else
            {
                if (rdbVideojuego.Checked)
                {
                    BLLVideojuego _BLLVideojuego= new BLLVideojuego();
                    DetalleOrden detalleOrden = new DetalleOrden();

                    detalleOrden.IdOrden = Convert.ToInt32(txtIDFactura.Text);
                    detalleOrden.IdDetalle = numeroDetalle;
                    detalleOrden.IdProducto = Convert.ToInt32(txtIDProducto.Text);
                    detalleOrden.Cantidad = Convert.ToInt32(txtCantidad.Text);

                    List<Videojuego> lista = _BLLVideojuego.GetAllVideojuego();

                    foreach (Videojuego videojuego in lista)
                    {
                        if (Convert.ToUInt32(txtIDProducto.Text) == videojuego.ID)
                        {
                            if (videojuego.ESTADO == 1)
                            {
                                if (videojuego.CANTIDAD_INVENTARIO >= Convert.ToInt32(txtCantidad.Text))
                                {
                                    detalleOrden.Total = (videojuego.PRECIO_COLONES - videojuego.DESCUENTO) * detalleOrden.Cantidad;

                                    varDescuento += videojuego.DESCUENTO * detalleOrden.Cantidad;
                                }
                                else
                                {
                                    MessageBox.Show("En este momento no tenemos suficientes existencias de este videojuego, el numero maximo que puede comprar es: " + videojuego.CANTIDAD_INVENTARIO);
                                    txtCantidad.Enabled = true;
                                    txtIDProducto.Enabled = true;
                                    btnConfirmarProducto.Enabled = true;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El videojuego que desea agregar no esta disponible en este momento");
                                txtCantidad.Enabled = true;
                                txtIDProducto.Enabled = true;
                                btnConfirmarProducto.Enabled = true;
                                return;
                            }
                        }
                    }

                    string[] detalleDataGrid =
                    {
                    detalleOrden.IdDetalle.ToString(),
                    detalleOrden.IdProducto.ToString(),
                    detalleOrden.Cantidad.ToString(),
                    varDescuento.ToString(),
                    detalleOrden.Total.ToString(),
                    };

                    ordenCompraDTO.listaDetalles.Add(detalleOrden);
                    dgvDatos.Rows.Add(detalleDataGrid);

                    numeroDetalle++;

                    btnComprar.Enabled = true;

                    varSubTotal += detalleOrden.Total;
                    txtSubtotal.Text = (varSubTotal + varDescuento).ToString();

                    varTotal += detalleOrden.Total;
                    txtTotal.Text = varTotal.ToString();

                    varDescuentoTotal += varDescuento;
                    varDescuento = 0;

                    txtIDProducto.Enabled = true;
                    txtCantidad.Enabled = true;
                    btnConfirmarProducto.Enabled = true;
                    btnAgregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de lo que desea comprar");
                    rdbProducto.Focus();
                    return;
                }
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (rdbProducto.Checked)
            {
                BLLFactura _BLLFactura = new BLLFactura();
                BLLProducto _BLLProducto = new BLLProducto();

                List<Producto> lista = _BLLProducto.GetAllProducto();

                int cantidad = 0;

                foreach (Producto producto in lista)
                {
                    foreach (DetalleOrden detalleOrden in ordenCompraDTO.listaDetalles)
                    {
                        if (detalleOrden.IdProducto == producto.ID)
                        {
                            cantidad += detalleOrden.Cantidad;

                            if (producto.CantidadInventario < cantidad)
                            {
                                MessageBox.Show("En este momento no poseemos la cantidad de inventario necesario para realizar su compra, su compra sera cancerlada para que pueda intentar realizarla de nuevo");
                                btnCancelar_Click(sender, e);
                                return;
                            }
                        }
                    }
                    cantidad = 0;
                }

                ServiceBCCR serviceBCCR = new ServiceBCCR();

                List<Dolar> listaDolar = new List<Dolar>();

                listaDolar = serviceBCCR.GetDolar(DateTime.UtcNow, DateTime.UtcNow, "318") as List<Dolar>;

                foreach (Dolar d in listaDolar)
                {
                    ordenCompraDTO.TotalDolares = Convert.ToDouble(txtTotal.Text) / d.Monto;
                }

                ordenCompraDTO.ID = Convert.ToInt32(txtIDFactura.Text);
                ordenCompraDTO.FechaOrden = DateTime.Now;
                ordenCompraDTO.IdCliente = Convert.ToInt32(txtIDCliente.Text);
                ordenCompraDTO.Total = Convert.ToInt32(txtTotal.Text);
                ordenCompraDTO.SubTotal = Convert.ToInt32(txtTotal.Text) + varDescuentoTotal;

                try
                {
                    _BLLFactura.SaveFactura(ordenCompraDTO);

                    MessageBox.Show("Su compra a sido realizada con exito");

                    frmReporteFactura frmReporteFactura = new frmReporteFactura(Convert.ToInt32(txtIDFactura.Text));
                    frmReporteFactura.Show();

                    this.Close();
                }
                catch (Exception ex)
                {
                    string message= "No se pudo realizar la compra " + ex.Message;

                    _MyLogControlEventos.Error(message.ToString());

                    MessageBox.Show(message);

                    btnCancelar_Click(sender, e);
                }
            }
            else
            {
                if (rdbVideojuego.Checked)
                {
                    BLLFacturaVideojuego _BLLFacturaVideojuego = new BLLFacturaVideojuego();
                    BLLVideojuego _BLLVideojuego = new BLLVideojuego();

                    List<Videojuego> lista = _BLLVideojuego.GetAllVideojuego();

                    int cantidad = 0;

                    foreach (Videojuego videojuego in lista)
                    {
                        foreach (DetalleOrden detalleOrden in ordenCompraDTO.listaDetalles)
                        {
                            if (detalleOrden.IdProducto == videojuego.ID)
                            {
                                cantidad += detalleOrden.Cantidad;

                                if (videojuego.CANTIDAD_INVENTARIO < cantidad)
                                {
                                    MessageBox.Show("En este momento no poseemos la cantidad de inventario necesario para realizar su compra, su compra sera cancerlada para que pueda intentar realizarla de nuevo");
                                    btnCancelar_Click(sender, e);
                                    return;
                                }
                            }
                        }
                        cantidad = 0;
                    }

                    ServiceBCCR serviceBCCR = new ServiceBCCR();

                    List<Dolar> listaDolar = new List<Dolar>();

                    listaDolar = serviceBCCR.GetDolar(DateTime.UtcNow, DateTime.UtcNow, "318") as List<Dolar>;

                    foreach (Dolar d in listaDolar)
                    {
                        ordenCompraDTO.TotalDolares = Convert.ToDouble(txtTotal.Text) / d.Monto;
                    }

                    ordenCompraDTO.ID = Convert.ToInt32(txtIDFactura.Text);
                    ordenCompraDTO.FechaOrden = DateTime.Now;
                    ordenCompraDTO.IdCliente = Convert.ToInt32(txtIDCliente.Text);
                    ordenCompraDTO.Total = Convert.ToInt32(txtTotal.Text);
                    ordenCompraDTO.SubTotal = Convert.ToInt32(txtTotal.Text) + varDescuentoTotal;

                    try
                    {
                        _BLLFacturaVideojuego.SaveFactura(ordenCompraDTO);

                        MessageBox.Show("Su compra a sido realizada con exito");

                        frmReporteFacturaVideojuego frmReporteFacturaVideojuego = new frmReporteFacturaVideojuego(Convert.ToInt32(txtIDFactura.Text));
                        frmReporteFacturaVideojuego.Show();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        string message= "No se pudo realizar la compra " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);

                        btnCancelar_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de la compra que desea realizar");
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {
            txtIDCliente.Enabled= true;
            btnConfirmar.Enabled= true;
            rdbProducto.Enabled= false;
            rdbVideojuego.Enabled= false;
        }

        private void rdbVideojuego_CheckedChanged(object sender, EventArgs e)
        {
            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;
            rdbProducto.Enabled = false;
            rdbVideojuego.Enabled = false;
        }
    }
}
