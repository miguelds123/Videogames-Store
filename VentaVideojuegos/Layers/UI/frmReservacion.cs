using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.BLL;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmReservacion : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

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

            btnCancelar.Enabled = true;
            rdbProducto.Enabled = true;
            rdbVideojuego.Enabled = true;

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
            if (rdbProducto.Checked)
            {
                if (String.IsNullOrEmpty(txtIDProducto.Text))
                {
                    MessageBox.Show("Debe digitar el id del producto que desea reservar");
                    txtIDProducto.Focus();
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
                    Producto producto;

                    try
                    {
                        producto = _BLLProducto.GetProductoById(Double.Parse(txtIDProducto.Text));
                    }
                    catch (Exception ex)
                    {
                        string message = "El producto que usted selecciono no es valido " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
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
            else
            {
                if (rdbVideojuego.Checked)
                {
                    if (String.IsNullOrEmpty(txtIDProducto.Text))
                    {
                        MessageBox.Show("Debe digitar el id del videojuego que desea reservar");
                        txtIDProducto.Focus();
                        return;
                    }

                    BLLVideojuego _BLLVideojuego = new BLLVideojuego();

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
                        Videojuego videojuego;

                        try
                        {
                            videojuego = _BLLVideojuego.GetVideojuegoById(Double.Parse(txtIDProducto.Text));
                        }
                        catch (Exception ex)
                        {
                            string message = "El producto que usted selecciono no es valido " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }

                        txtAdelanto.Text = (videojuego.PRECIO_COLONES * 0.5).ToString();

                        btnReservar.Enabled = true;
                        txtIDProducto.Enabled = false;
                        btnConfirmarProducto.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El videojuego que selecciono no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de lo que desea reservar");
                    return;
                }
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

            rdbProducto.Checked= false;
            rdbVideojuego.Checked= false;
            rdbProducto.Enabled=true;
            rdbVideojuego.Enabled=true;
            txtIDCliente.Enabled=false;
            btnConfirmar.Enabled=false;
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
            rdbProducto.Enabled = false;
            rdbProducto.Checked= false;
            rdbVideojuego.Enabled = false;
            rdbProducto.Enabled = false;
            rdbVideojuego.Enabled= false;

            MessageBox.Show("Recuerde que a la hora de hacer un apartado, debera pagar por adelantado la mitad del precio del producto, ademas de que cualquier descuento que le producto posea, no sera valido");
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (rdbProducto.Checked)
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

                                    string rutaImagen = @"c:\temp\qr.png";

                                    if (File.Exists(rutaImagen))
                                        File.Delete(rutaImagen);

                                    Image quickResponseImage = QR.QuickResponseGenerador(txtIDReservacion.Text, 53);

                                    quickResponseImage.Save(rutaImagen, ImageFormat.Png);

                                    MessageBox.Show("En la siguiente direccion podra encontrar un codigo qr con su numero de reservacion con el que podra ir a retirar su reservacion: " + rutaImagen);

                                    this.Close();

                                    return;
                                }
                                catch (Exception ex)
                                {
                                    string message = "No se pudo realizar la reservacion " + ex.Message;

                                    _MyLogControlEventos.Error(message.ToString());

                                    MessageBox.Show(message);

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
            else
            {
                if (rdbVideojuego.Checked)
                {
                    BLLReservacionVideojuego _BLLReservacionVideojuego = new BLLReservacionVideojuego();
                    BLLVideojuego _BLLVideojuego = new BLLVideojuego();

                    reservacion.ID = Convert.ToInt32(txtIDReservacion.Text);
                    reservacion.IdProducto = Convert.ToInt32(txtIDProducto.Text);
                    reservacion.IdCliente = Convert.ToInt32(txtIDCliente.Text);
                    reservacion.Adelanto = Convert.ToInt32(txtAdelanto.Text);

                    List<Videojuego> lista = _BLLVideojuego.GetAllVideojuego();

                    foreach (Videojuego videojuego in lista)
                    {
                        if (Convert.ToUInt32(txtIDProducto.Text) == videojuego.ID)
                        {
                            if (videojuego.ESTADO == 1)
                            {
                                if (videojuego.CANTIDAD_INVENTARIO >= 1)
                                {
                                    try
                                    {
                                        _BLLReservacionVideojuego.SaveReservacion(reservacion);

                                        MessageBox.Show("Su reservacion a sido realizada con exito");

                                        string rutaImagen = @"c:\temp\qr.png";

                                        if (File.Exists(rutaImagen))
                                            File.Delete(rutaImagen);

                                        Image quickResponseImage = QR.QuickResponseGenerador(txtIDReservacion.Text, 53);

                                        quickResponseImage.Save(rutaImagen, ImageFormat.Png);

                                        MessageBox.Show("En la siguiente direccion podra encontrar un codigo qr con su numero de reservacion con el que podra ir a retirar su reservacion: " + rutaImagen);

                                        this.Close();

                                        return;
                                    }
                                    catch (Exception ex)
                                    {
                                        string message = "No se pudo realizar la reservacion " + ex.Message;

                                        _MyLogControlEventos.Error(message.ToString());

                                        MessageBox.Show(message);

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
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de lo que desea reservar");
                    return;
                }
            }
        }

        private void rdbProducto_CheckedChanged(object sender, EventArgs e)
        {
            txtIDCliente.Text = string.Empty;
            txtIDProducto.Text = string.Empty;
            txtAdelanto.Text = string.Empty;

            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;
            btnCancelar.Enabled = true;

            rdbProducto.Enabled = false;
            rdbVideojuego.Enabled = false;
        }

        private void rdbVideojuego_CheckedChanged(object sender, EventArgs e)
        {
            txtIDCliente.Enabled = true;
            btnConfirmar.Enabled = true;
            btnCancelar.Enabled = true;

            txtIDCliente.Text = string.Empty;
            txtIDProducto.Text = string.Empty;
            txtAdelanto.Text = string.Empty;

            rdbProducto.Enabled = false;
            rdbVideojuego.Enabled = false;
        }
    }
}
