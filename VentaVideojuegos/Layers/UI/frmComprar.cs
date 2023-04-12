using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmComprar : Form
    {
        static int numeroDetalle = 1;
        double varSubTotal = 0;
        double varTotal = 0;
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

            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;
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
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            txtIDCliente.Enabled=false;
            txtIDProducto.Enabled=true;
            txtCantidad.Enabled=true;
            btnConfirmarProducto.Enabled = true;
            btnConfirmar.Enabled=false;

            if (String.IsNullOrEmpty(txtIDCliente.Text))
            {
                MessageBox.Show("Debe digitar la identificacion del cliente");
                txtIDCliente.Focus();
                return;
            }
        }

        private void btnConfirmarProducto_Click(object sender, EventArgs e)
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

            btnAgregar.Enabled=true;
            txtIDProducto.Enabled=false;
            txtCantidad.Enabled=false;
            btnConfirmarProducto.Enabled=false;
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

            txtSubtotal.Text = "0";

            txtTotal.Text = "0";

            numeroDetalle = 1;

            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;

            btnNuevo.Enabled = false;

            dgvDatos.Rows.Clear();

            numeroDetalle = 1;
            varSubTotal = 0;
            varTotal= 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BLLProducto _BLLProducto = new BLLProducto();
            DetalleOrden detalleOrden= new DetalleOrden();

            detalleOrden.IdOrden= Convert.ToInt32(txtIDFactura.Text);
            detalleOrden.IdDetalle = numeroDetalle;
            detalleOrden.IdProducto= Convert.ToInt32(txtIDProducto.Text);
            detalleOrden.Cantidad= Convert.ToInt32(txtCantidad.Text);

            List<Producto> lista = _BLLProducto.GetAllProducto();

            foreach(Producto producto in lista)
            {
                if (Convert.ToUInt32(txtIDProducto.Text) == producto.ID)
                {
                    detalleOrden.Total = producto.PrecioColones * detalleOrden.Cantidad;
                }
            }

            string[] detalleDataGrid =
            {
                detalleOrden.IdDetalle.ToString(),
                detalleOrden.IdProducto.ToString(),
                detalleOrden.Cantidad.ToString(),
                detalleOrden.Total.ToString()
            };

            ordenCompraDTO.listaDetalles.Add(detalleOrden);
            dgvDatos.Rows.Add(detalleDataGrid);

            numeroDetalle++;

            btnComprar.Enabled = true;

            varSubTotal += detalleOrden.Total;
            txtSubtotal.Text= varSubTotal.ToString();

            varTotal += detalleOrden.Total;
            txtTotal.Text= varTotal.ToString();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            BLLFactura _BLLFactura= new BLLFactura();

            ordenCompraDTO.ID= Convert.ToInt32(txtIDFactura.Text);
            ordenCompraDTO.FechaOrden = DateTime.Now;
            ordenCompraDTO.IdCliente = Convert.ToInt32(txtIDCliente.Text);
            ordenCompraDTO.Total= Convert.ToInt32(txtTotal.Text);
            ordenCompraDTO.SubTotal = Convert.ToInt32(txtSubtotal.Text);

            try
            {
                _BLLFactura.SaveFactura(ordenCompraDTO);

                MessageBox.Show("Su compra a sido realizada con exito");

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo realizar la compra");

                btnCancelar_Click(sender, e);
            }
        }
    }
}
