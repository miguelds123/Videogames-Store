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

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmListaDeseos : Form
    {
        EstadoMantenimiento estadoFrame;

        public frmListaDeseos()
        {
            InitializeComponent();
        }

        private void frmListaDeseos_Load(object sender, EventArgs e)
        {
            this.Text = "Lista Deseos";

            txtIdProducto.Enabled= false;
            btnConfirmar.Enabled= false;
            btnAceptar.Enabled= false;
            btnNuevo.Enabled= false;
            btnBorrar.Enabled= false;
        }

        private void CargarDatos()
        {
            dgvDatos.Rows.Clear();
            
            BLLListaDeseos _BLLListaDeseos = new BLLListaDeseos();
            BLLProducto _BLLProducto= new BLLProducto();

            List<ListaDeseos> lista= new List<ListaDeseos>();
            List<Producto> listaProductos= new List<Producto>();

            lista= _BLLListaDeseos.GetListaDeseosByIdCliente(txtIdCliente.Text);
            listaProductos = _BLLProducto.GetAllProducto();

            string estado = "";

            foreach(Producto producto in listaProductos)
            {
                foreach(ListaDeseos listaDeseos in lista)
                {
                    if (producto.ID == listaDeseos.IdProducto)
                    {
                        if (producto.Estado == 0)
                        {
                            estado = "No disponible";
                        }
                        else
                        {
                            if (producto.Estado == 1)
                            {
                                estado = "Disponible";
                            }
                        }

                        string[] datos =
                        {
                            producto.ID.ToString(),
                            producto.Descripcion.ToString(),
                            producto.Descuento.ToString(),
                            producto.PrecioColones.ToString(),
                            producto.PrecioDolares.ToString(),
                            estado
                        };

                        dgvDatos.Rows.Add(datos);
                    }
                }
            }

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            this.btnNuevo.Enabled = true;
            this.btnBorrar.Enabled = true;
            this.dgvDatos.Enabled = true;
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtIdCliente.Enabled = false;
            this.txtIdProducto.Enabled = false;

            this.btnAceptar.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    txtIdProducto.Enabled= true;
                    btnConfirmar.Enabled= true;
                    txtIdProducto.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Borrar:
                    estadoFrame = EstadoMantenimiento.Borrar;
                    txtIdProducto.Enabled = true;
                    btnConfirmar.Enabled = true;
                    txtIdProducto.Focus();
                    break;

                case EstadoMantenimiento.Ninguno:
                    estadoFrame = EstadoMantenimiento.Ninguno;
                    break;
            }
        }

        private void ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Debe digitar la identificacion del cliente");
                txtIdCliente.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Debe digitar el numero de telefono del cliente");
                txtIdProducto.Focus();
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BLLListaDeseos _BLLListaDeseos= new BLLListaDeseos();
            ListaDeseos listaDeseos= new ListaDeseos();

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    BLLProducto _BLLProducto = new BLLProducto();

                    List<ListaDeseos> lista = new List<ListaDeseos>();
                    List<Producto> listaProductos = new List<Producto>();

                    lista = _BLLListaDeseos.GetListaDeseosByIdCliente(txtIdCliente.Text);
                    listaProductos = _BLLProducto.GetAllProducto();

                    string estado = "";

                    foreach (Producto producto in listaProductos)
                    {
                        foreach (ListaDeseos listaD in lista)
                        {
                            if (producto.ID == listaD.IdProducto)
                            {
                                MessageBox.Show("El producto que desea agregar ya esta en su lista de deseos");
                                txtIdProducto.Enabled= true;
                                btnConfirmar.Enabled= true;
                                return;
                            }
                        }
                    }

                    ValidarCampos();

                    listaDeseos = new ListaDeseos();

                    listaDeseos.IdProducto= Convert.ToInt32(txtIdProducto.Text);
                    listaDeseos.IdCliente= Convert.ToInt32(txtIdCliente.Text);

                    try
                    {
                        _BLLListaDeseos.SaveListaDeseos(listaDeseos);

                        this.CargarDatos();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ocurrio un error en la base de datos al agregar el nuevo correo");
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error en el programa al agregar el nuevo correo");
                        return;
                    }

                    break;

                case EstadoMantenimiento.Borrar:

                    string mensaje = "Esta seguro que desea eliminar este producto de su lista de deseos, esta accion es irreversible";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            _BLLListaDeseos.DeleteListaDeseos(txtIdCliente.Text, txtIdProducto.Text);

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Ocurrio un error en la base de datos al borrar el cliente");
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error en el programa al borrar el cliente");
                            return;
                        }
                    }

                    break;
            }

            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvDatos.Rows.Clear();
            txtIdCliente.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            txtIdProducto.Enabled= false;
            btnConfirmar.Enabled= false;
            txtIdCliente.Enabled= true;
            btnBuscar.Enabled= true;
            btnNuevo.Enabled= false;
            btnBorrar.Enabled= false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Borrar);

            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.dgvDatos.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);

            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            BLLProducto _BLLProducto = new BLLProducto();

            List<Producto> lista = new List<Producto>();
            lista = _BLLProducto.GetAllProducto();

            bool estado = false;

            foreach (Producto producto in lista)
            {
                if (producto.ID == Convert.ToInt32(txtIdProducto.Text))
                {
                    estado = true;
                }
            }

            if (estado)
            {
                txtIdProducto.Enabled = false;
                btnConfirmar.Enabled = false;
                btnAceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("El producto que selecciono no es valido");
                return;
            }
        }

        private void btnConfirmarIdCliente_Click(object sender, EventArgs e)
        {
            BLLCliente _BLLCliente = new BLLCliente();

            List<Cliente> lista = new List<Cliente>();
            lista = _BLLCliente.GetAllCliente();

            bool estado = false;

            foreach (Cliente cliente in lista)
            {
                if (cliente.ID == Convert.ToInt32(txtIdCliente.Text))
                {
                    estado = true;
                }
            }

            if (estado)
            {
                txtIdCliente.Enabled = false;
                txtIdProducto.Enabled = true;
                btnConfirmar.Enabled = true;
            }
            else
            {
                MessageBox.Show("El cliente que selecciono no es valido");
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BLLCliente _BLLCliente = new BLLCliente();

            List<Cliente> lista = new List<Cliente>();
            lista = _BLLCliente.GetAllCliente();

            bool estado = false;

            foreach (Cliente cliente in lista)
            {
                if (cliente.ID == Convert.ToInt32(txtIdCliente.Text))
                {
                    estado = true;
                }
            }

            if (estado)
            {
                try
                {
                    CargarDatos();

                    txtIdCliente.Enabled = false;
                    btnBuscar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar su lista de deseos");
                }
            }
            else
            {
                MessageBox.Show("El cliente que selecciono no es valido");
                return;
            }
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
