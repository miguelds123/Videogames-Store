﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.Entities;
using VentaVideojuegos;
using System.ServiceModel.Channels;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmMantenimientoProductos : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        EstadoMantenimiento estadoFrame;

        public frmMantenimientoProductos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);

            MessageBox.Show("Por favor no olvide seleccionar la imagen que desea añadir");

            this.btnEditar.Enabled = false;
            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
        }

        private void frmMantenimientoProductos_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento Producto";

            cmbCategoria.Items.Clear();
            cmbEstado.Items.Clear();

            cmbCategoria.Items.Add(CategoriaProducto.Consola);
            cmbCategoria.Items.Add(CategoriaProducto.Perifericos);

            cmbEstado.Items.Add(Estado.Activo);
            cmbEstado.Items.Add(Estado.Inactivo);

            try
            {
                CargarDatos();
            }
            catch (SqlException ex)
            {
                string message= "Dio error la base de datos " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                string message = "Dio error el programa " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
            }
        }

        private void CargarDatos()
        {
            BLLProducto _BLLProducto = new BLLProducto();

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            dgvDatos.RowTemplate.Height = 100;

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLProducto.GetAllProducto();

            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnBorrar.Enabled = true;
            this.dgvDatos.Enabled = true;
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtID.Clear();
            this.txtDescripcion.Clear();
            this.txtCantidadInventario.Clear();
            this.txtDescuento.Clear();
            this.txtPrecioColones.Clear();
            this.txtPrecioDolares.Clear();
            this.cmbCategoria.SelectedIndex = -1;

            this.txtID.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCantidadInventario.Enabled = false;
            this.txtDescuento.Enabled = false;
            this.txtPrecioColones.Enabled = false;
            this.txtPrecioDolares.Enabled = false;
            this.cmbCategoria.Enabled = false;
            this.cmbEstado.Enabled = false;
            this.pbImagen.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtID.Enabled = true;
                    this.txtDescripcion.Enabled = true;
                    this.txtCantidadInventario.Enabled = true;
                    this.txtDescuento.Enabled = true;
                    this.txtPrecioColones.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.cmbEstado.Enabled = true;
                    this.pbImagen.Enabled = true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtID.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtDescripcion.Enabled = true;
                    this.txtCantidadInventario.Enabled = true;
                    this.txtDescuento.Enabled = true;
                    this.txtPrecioColones.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.cmbEstado.Enabled = true;
                    this.pbImagen.Enabled = true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtID.Focus();
                    estadoFrame = EstadoMantenimiento.Editar;
                    break;

                case EstadoMantenimiento.Borrar:
                    estadoFrame = EstadoMantenimiento.Borrar;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    break;

                case EstadoMantenimiento.Ninguno:
                    estadoFrame = EstadoMantenimiento.Ninguno;
                    break;
            }
        }

        private void ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Debe digitar el ID del producto");
                txtID.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Debe digitar la descripcion del producto");
                txtDescripcion.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtCantidadInventario.Text))
            {
                MessageBox.Show("Debe digitar la cantidad de inventario del producto");
                txtCantidadInventario.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtDescuento.Text))
            {
                MessageBox.Show("Debe digitar el descuento del producto");
                txtDescuento.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPrecioColones.Text))
            {
                MessageBox.Show("Debe digitar el precio en colones del producto");
                txtPrecioColones.Focus();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BLLProducto _BLLProducto = new BLLProducto();
            Producto producto = new Producto();

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    if (String.IsNullOrEmpty(txtID.Text))
                    {
                        MessageBox.Show("Debe digitar el ID del producto");
                        txtID.Focus();
                        return;
                    }

                    try
                    {
                        int num= Convert.ToInt32(txtID.Text);
                    }
                    catch(Exception ex)
                    {
                        string message = "El id debe estar compuesto de numero enteros";
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtID.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("Debe digitar la descripcion del producto");
                        txtDescripcion.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtCantidadInventario.Text))
                    {
                        MessageBox.Show("Debe digitar la cantidad de inventario del producto");
                        txtCantidadInventario.Focus();
                        return;
                    }

                    try
                    {
                        int num = Convert.ToInt32(txtCantidadInventario.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = "La cantidad de inventario debe ser un numero entero";
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtCantidadInventario.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtDescuento.Text))
                    {
                        MessageBox.Show("Debe digitar el descuento del producto");
                        txtDescuento.Focus();
                        return;
                    }

                    try
                    {
                        int num = Convert.ToInt32(txtDescuento.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = "El descuento debe ser un numero entero";
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtDescuento.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtPrecioColones.Text))
                    {
                        MessageBox.Show("Debe digitar el precio en colones del producto");
                        txtPrecioColones.Focus();
                        return;
                    }

                    try
                    {
                        int num = Convert.ToInt32(txtPrecioColones.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = "El precio en colones debe ser un numero entero";
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtPrecioColones.Focus();
                        return;
                    }

                    if (cmbCategoria.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la categoria del producto");
                        cmbCategoria.Focus();
                        return;
                    }

                    if (cmbEstado.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el estado del producto");
                        cmbEstado.Focus();
                        return;
                    }

                    if (pbImagen.Tag== null)
                    {
                        MessageBox.Show("Debe seleccionar una imagen");
                        pbImagen.Focus();
                        return;
                    }

                    producto = new Producto();

                    producto.ID = Convert.ToInt32(txtID.Text);
                    producto.Descripcion = txtDescripcion.Text;
                    producto.CantidadInventario = Convert.ToInt32(txtCantidadInventario.Text);
                    producto.Descuento = Convert.ToDouble(txtDescuento.Text);
                    producto.PrecioColones = Convert.ToDouble(txtPrecioColones.Text);
                    producto.PrecioDolares = Convert.ToDouble(txtPrecioDolares.Text);
                    producto.Imagen = (byte[])this.pbImagen.Tag;

                    if (cmbCategoria.SelectedItem.Equals(CategoriaProducto.Consola))
                    {
                        producto.IdCategoria = 2;
                    }
                    else
                    {
                        if (cmbCategoria.SelectedItem.Equals(CategoriaProducto.Perifericos))
                        {
                            producto.IdCategoria = 3;
                        }
                    }

                    if (cmbEstado.SelectedItem.Equals(Estado.Activo))
                    {
                        producto.Estado = 1;
                    }
                    else
                    {
                        if (cmbEstado.SelectedItem.Equals(Estado.Inactivo))
                        {
                            producto.Estado = 0;
                        }
                    }

                    try
                    {

                        List<Producto> listaProductos = _BLLProducto.GetAllProducto();

                        bool estado= false;

                        foreach(Producto pro in listaProductos)
                        {
                            if (pro.ID== producto.ID)
                            {
                                estado = true;
                            }
                        }

                        if (estado == false)
                        {
                            _BLLProducto.SaveProducto(producto);

                            this.CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("El id que intento agregar ya a sido registrado anteriormente, por favor digite uno que no se encuentre registrado");
                            txtID.Focus();
                            return;
                        }
                    }
                    catch (SqlException ex)
                    {
                        string message = "Ocurrio un error en la base de datos al agregar el nuevo producto " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        string message = "Ocurrio un error en el programa al agregar el nuevo " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
                        return;
                    }

                    break;

                case EstadoMantenimiento.Editar:

                    if (this.dgvDatos.SelectedRows.Count > 0)
                    {

                        if (String.IsNullOrEmpty(txtID.Text))
                        {
                            MessageBox.Show("Debe digitar el ID del producto");
                            txtID.Focus();
                            return;
                        }

                        try
                        {
                            int num = Convert.ToInt32(txtID.Text);
                        }
                        catch (Exception ex)
                        {
                            string message = "El id debe estar compuesto de numero enteros";
                            _MyLogControlEventos.Error(message.ToString());
                            MessageBox.Show(message);
                            txtID.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Debe digitar la descripcion del producto");
                            txtDescripcion.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtCantidadInventario.Text))
                        {
                            MessageBox.Show("Debe digitar la cantidad de inventario del producto");
                            txtCantidadInventario.Focus();
                            return;
                        }

                        try
                        {
                            int num = Convert.ToInt32(txtCantidadInventario.Text);
                        }
                        catch (Exception ex)
                        {
                            string message =("La cantidad de inventario debe ser un numero entero");
                            _MyLogControlEventos.Error(message.ToString());
                            MessageBox.Show(message);
                            txtCantidadInventario.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtDescuento.Text))
                        {
                            MessageBox.Show("Debe digitar el descuento del producto");
                            txtDescuento.Focus();
                            return;
                        }

                        try
                        {
                            int num = Convert.ToInt32(txtDescuento.Text);
                        }
                        catch (Exception ex)
                        {
                            string message = ("El descuento debe ser un numero entero");
                            _MyLogControlEventos.Error(message.ToString());
                            MessageBox.Show(message);
                            txtDescuento.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtPrecioColones.Text))
                        {
                            MessageBox.Show("Debe digitar el precio en colones del producto");
                            txtPrecioColones.Focus();
                            return;
                        }

                        try
                        {
                            int num = Convert.ToInt32(txtPrecioColones.Text);
                        }
                        catch (Exception ex)
                        {
                            string message = ("El precio en colones debe ser un numero entero");
                            _MyLogControlEventos.Error(message.ToString());
                            MessageBox.Show(message);
                            txtPrecioColones.Focus();
                            return;
                        }

                        if (cmbCategoria.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar la categoria del producto");
                            cmbCategoria.Focus();
                            return;
                        }

                        if (cmbEstado.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar el estado del producto");
                            cmbEstado.Focus();
                            return;
                        }

                        if (pbImagen.Tag == null)
                        {
                            MessageBox.Show("Debe seleccionar una imagen");
                            pbImagen.Focus();
                            return;
                        }

                        //telefono = this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;
                        producto = new Producto();

                        producto.ID = Convert.ToInt32(txtID.Text);
                        producto.Descripcion = txtDescripcion.Text;
                        producto.CantidadInventario = Convert.ToInt32(txtCantidadInventario.Text);
                        producto.Descuento = Convert.ToDouble(txtDescuento.Text);
                        producto.PrecioColones = Convert.ToDouble(txtPrecioColones.Text);
                        producto.PrecioDolares = Convert.ToDouble(txtPrecioDolares.Text);
                        producto.Imagen = (byte[])this.pbImagen.Tag;

                        if (cmbCategoria.SelectedItem.Equals(CategoriaProducto.Consola))
                        {
                            producto.IdCategoria = 2;
                        }
                        else
                        {
                            if (cmbCategoria.SelectedItem.Equals(CategoriaProducto.Perifericos))
                            {
                                producto.IdCategoria = 3;
                            }
                        }

                        if (cmbEstado.SelectedItem.Equals(Estado.Activo))
                        {
                            producto.Estado = 1;
                        }
                        else
                        {
                            if (cmbEstado.SelectedItem.Equals(Estado.Inactivo))
                            {
                                producto.Estado = 0;
                            }
                        }

                        try
                        {
                            _BLLProducto.UpdateProducto(producto);

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            string message = "Ocurrio un error en la base de datos al editar el producto " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                        catch (Exception ex)
                        {
                            string message = "Ocurrio un error en el programa al editar el producto " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar el producto que desea editar");
                        return;
                    }

                    break;

                case EstadoMantenimiento.Borrar:

                    string mensaje = "Esta seguro que desea deshabilitar este producto";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            //_BLLProducto.DeleteProducto(Convert.ToDouble(txtID.Text));

                            _BLLProducto.BorradoLogico(Convert.ToInt32(txtID.Text));

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            string message = "Ocurrio un error en la base de datos al borrar el producto " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                        catch (Exception ex)
                        {
                            string message = "Ocurrio un error en el programa al borrar el producto " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                    }

                    break;
            }

            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtPrecioColones.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El precio en colones debe ser un numero entero");
                txtPrecioColones.Focus();
                return;
            }

            ServiceBCCR serviceBCCR = new ServiceBCCR();

            List<Dolar> lista = new List<Dolar>();

            lista = serviceBCCR.GetDolar(DateTime.UtcNow, DateTime.UtcNow, "318") as List<Dolar>;

            foreach (Dolar d in lista)
            {
                txtPrecioDolares.Text = (Convert.ToDouble(txtPrecioColones.Text) / d.Monto).ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {

                MessageBox.Show("Por favor no olvide seleccionar la imagen que desea editar");

                this.CambiarEstado(EstadoMantenimiento.Editar);

                Producto producto = this.dgvDatos.SelectedRows[0].DataBoundItem as Producto;

                txtID.Text = producto.ID.ToString();
                txtDescripcion.Text = producto.Descripcion.ToString();
                txtCantidadInventario.Text = producto.CantidadInventario.ToString();
                txtDescuento.Text = producto.Descuento.ToString();
                txtPrecioColones.Text = producto.PrecioColones.ToString();
                txtPrecioDolares.Text = producto.PrecioDolares.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el producto que desea editar");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Producto producto = this.dgvDatos.SelectedRows[0].DataBoundItem as Producto;

                txtID.Text = producto.ID.ToString();
                txtDescripcion.Text = producto.Descripcion.ToString();
                txtCantidadInventario.Text = producto.CantidadInventario.ToString();
                txtDescuento.Text = producto.Descuento.ToString();
                txtPrecioColones.Text = producto.PrecioColones.ToString();
                txtPrecioDolares.Text = producto.PrecioDolares.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el producto que desea eliminar");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.jpg";
                opt.Filter = "Archivos de Imagenes (*.jpg)|*.jpg| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {

                    //ruta = opt.FileName.Trim();
                    this.pbImagen.ImageLocation = opt.FileName;
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);

                    // Guarla la imagenen Bytes en el Tag de la imagen.
                    pbImagen.Tag = (byte[])cadenaBytes;

                }
            }
            catch (SqlException ex)
            {
                string message = "Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error en el programa " + ex.Message; 

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
