﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.BLL;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmMantenimientoVideojuego : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        EstadoMantenimiento estadoFrame;

        public frmMantenimientoVideojuego()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);

            MessageBox.Show("Por favor no olvide seleccionar la imagen que desea añadir");

            this.btnEditar.Enabled = false;
            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
        }

        private void frmMantenimientoVideojuego_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento Videojuego";

            cmbEstado.Items.Clear();

            cmbEstado.Items.Add(Estado.Activo);
            cmbEstado.Items.Add(Estado.Inactivo);

            try
            {
                CargarDatos();
            }
            catch (SqlException ex)
            {
                string message = "Dio error la base de datos " + ex.Message;

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
            BLLVideojuego _BLLVideojuego = new BLLVideojuego();

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            dgvDatos.RowTemplate.Height = 100;

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLVideojuego.GetAllVideojuego();

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
            txtNombre.Clear();
            txtFechaSalida.Clear();
            txtNota.Clear();

            this.txtID.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCantidadInventario.Enabled = false;
            this.txtDescuento.Enabled = false;
            this.txtPrecioColones.Enabled = false;
            this.txtPrecioDolares.Enabled = false;
            txtNombre.Enabled = false;
            txtFechaSalida.Enabled = false;
            txtNota.Enabled = false;
            btnBuscar.Enabled = false;
            btnConfirmar.Enabled = false;

            this.cmbEstado.Enabled = false;
            this.pbImagen.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtID.Enabled = true;
                    txtNombre.Enabled = true;
                    btnBuscar.Enabled = true;

                    this.btnCancelar.Enabled = true;
                    btnAceptar.Enabled = true;
                    txtID.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtID.Enabled = true;
                    txtNombre.Enabled = true;
                    btnBuscar.Enabled = true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtID.Enabled = false;
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

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe digitar el nombre del videojuego");
                txtNombre.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtFechaSalida.Text))
            {
                MessageBox.Show("Debe digitar la fecha de salida del producto");
                txtFechaSalida.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtNota.Text))
            {
                MessageBox.Show("Debe digitar la nota del producto");
                txtNota.Focus();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BLLVideojuego _BLLVideojuego = new BLLVideojuego();
            Videojuego videojuego = new Videojuego();

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
                        int num = Convert.ToInt32(txtID.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = ("El id debe estar compuesto de numero enteros");
                        _MyLogControlEventos.Error(message.ToString());
                        MessageBox.Show(message);
                        txtID.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtNombre.Text))
                    {
                        MessageBox.Show("Debe digitar el nombre del videojuego");
                        txtNombre.Focus();
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
                        string message = ("La cantidad de inventario debe ser un numero entero");
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

                    if (String.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("Debe digitar la descripcion del producto");
                        txtDescripcion.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtFechaSalida.Text))
                    {
                        MessageBox.Show("Debe digitar la fecha de salida del producto");
                        txtFechaSalida.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtNota.Text))
                    {
                        MessageBox.Show("Debe digitar la nota del producto");
                        txtNota.Focus();
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

                    videojuego = new Videojuego();

                    videojuego.ID = Convert.ToInt32(txtID.Text);
                    videojuego.DESCRIPCION = txtDescripcion.Text;
                    videojuego.CANTIDAD_INVENTARIO = Convert.ToInt32(txtCantidadInventario.Text);
                    videojuego.DESCUENTO = Convert.ToInt32(txtDescuento.Text);
                    videojuego.PRECIO_COLONES = Convert.ToDouble(txtPrecioColones.Text);
                    videojuego.PRECIO_DOLARES = Convert.ToDouble(txtPrecioDolares.Text);
                    videojuego.Imagen = (byte[])this.pbImagen.Tag;
                    videojuego.NOMBRE = txtNombre.Text;
                    videojuego.FECHA_SALIDA = Convert.ToDateTime(txtFechaSalida.Text);
                    videojuego.NOTA = Convert.ToDouble(txtNota.Text);
                    videojuego.ID_CATEGORIA = 1;

                    if (cmbEstado.SelectedItem.Equals(Estado.Activo))
                    {
                        videojuego.ESTADO = 1;
                    }
                    else
                    {
                        if (cmbEstado.SelectedItem.Equals(Estado.Inactivo))
                        {
                            videojuego.ESTADO = 0;
                        }
                    }

                    try
                    {
                        List<Videojuego> listaVideojuegos = _BLLVideojuego.GetAllVideojuego();

                        bool estado = false;

                        foreach (Videojuego videojuego1 in listaVideojuegos)
                        {
                            if (videojuego1.ID == videojuego.ID)
                            {
                                estado = true;
                            }
                        }

                        if (estado == false)
                        {
                            _BLLVideojuego.SaveVideojuego(videojuego);

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
                            string message = ("El id debe estar compuesto de numero enteros");
                            _MyLogControlEventos.Error(message.ToString());
                            MessageBox.Show(message);
                            txtID.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Debe digitar el nombre del videojuego");
                            txtNombre.Focus();
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
                            string message = ("La cantidad de inventario debe ser un numero entero");
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

                        if (String.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Debe digitar la descripcion del producto");
                            txtDescripcion.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtFechaSalida.Text))
                        {
                            MessageBox.Show("Debe digitar la fecha de salida del producto");
                            txtFechaSalida.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtNota.Text))
                        {
                            MessageBox.Show("Debe digitar la nota del producto");
                            txtNota.Focus();
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
                        videojuego = new Videojuego();

                        videojuego.ID = Convert.ToInt32(txtID.Text);
                        videojuego.DESCRIPCION = txtDescripcion.Text;
                        videojuego.CANTIDAD_INVENTARIO = Convert.ToInt32(txtCantidadInventario.Text);
                        videojuego.DESCUENTO = Convert.ToInt32(txtDescuento.Text);
                        videojuego.PRECIO_COLONES = Convert.ToDouble(txtPrecioColones.Text);
                        videojuego.PRECIO_DOLARES = Convert.ToDouble(txtPrecioDolares.Text);
                        videojuego.Imagen = (byte[])this.pbImagen.Tag;
                        videojuego.NOMBRE = txtNombre.Text;
                        videojuego.FECHA_SALIDA = Convert.ToDateTime(txtFechaSalida.Text);
                        videojuego.NOTA = Convert.ToDouble(txtNota.Text);
                        videojuego.ID_CATEGORIA = 1;

                        if (cmbEstado.SelectedItem.Equals(Estado.Activo))
                        {
                            videojuego.ESTADO = 1;
                        }
                        else
                        {
                            if (cmbEstado.SelectedItem.Equals(Estado.Inactivo))
                            {
                                videojuego.ESTADO = 0;
                            }
                        }

                        try
                        {
                            _BLLVideojuego.UpdateVideojuego(videojuego);

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

                    string mensaje = "Esta seguro que desea deshabilitar este videojuego";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            //_BLLProducto.DeleteProducto(Convert.ToDouble(txtID.Text));

                            _BLLVideojuego.BorradoLogico(Convert.ToInt32(txtID.Text));

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

                Videojuego videojuego = this.dgvDatos.SelectedRows[0].DataBoundItem as Videojuego;

                txtID.Text = videojuego.ID.ToString();
                txtDescripcion.Text = videojuego.DESCRIPCION.ToString();
                txtCantidadInventario.Text = videojuego.CANTIDAD_INVENTARIO.ToString();
                txtDescuento.Text = videojuego.DESCUENTO.ToString();
                txtPrecioColones.Text = videojuego.PRECIO_COLONES.ToString();
                txtPrecioDolares.Text = videojuego.PRECIO_DOLARES.ToString();
                txtNombre.Text = videojuego.NOMBRE.ToString();
                txtFechaSalida.Text = videojuego.FECHA_SALIDA.ToString();
                txtNota.Text = videojuego.NOTA.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el videojuego que desea editar");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Videojuego videojuego = this.dgvDatos.SelectedRows[0].DataBoundItem as Videojuego;

                txtID.Text = videojuego.ID.ToString();
                txtDescripcion.Text = videojuego.DESCRIPCION.ToString();
                txtCantidadInventario.Text = videojuego.CANTIDAD_INVENTARIO.ToString();
                txtDescuento.Text = videojuego.DESCUENTO.ToString();
                txtPrecioColones.Text = videojuego.PRECIO_COLONES.ToString();
                txtPrecioDolares.Text = videojuego.PRECIO_DOLARES.ToString();
                txtNombre.Text = videojuego.NOMBRE.ToString();
                txtFechaSalida.Text = videojuego.FECHA_SALIDA.ToString();
                txtNota.Text = videojuego.NOTA.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el videojeugo que desea eliminar");
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
                string message = ("Ocurrio un error en el programa " + ex.Message);

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteRAWG clienteRAWG = new ClienteRAWG();

                RAWGJuego rawgJuego = clienteRAWG.ObtenerJuego(txtNombre.Text, "c2440053b87e41b88030c0bd0099a493");

                txtDescripcion.Text = rawgJuego.Description;
                txtFechaSalida.Text = rawgJuego.Released.ToString();
                txtNota.Text = rawgJuego.Rating.ToString();

                txtCantidadInventario.Enabled= true;
                txtDescuento.Enabled= true;
                txtPrecioColones.Enabled= true;
                cmbEstado.Enabled= true;
                pbImagen.Enabled = true;
                btnConfirmar.Enabled= true;
            }
            catch(Exception ex)
            {
                string message = ("No se encontro el videojuego " + ex.Message);

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Videojuego videojuego = this.dgvDatos.SelectedRows[0].DataBoundItem as Videojuego;

                txtID.Text = videojuego.ID.ToString();
                txtNombre.Text = videojuego.NOMBRE.ToString();
                txtCantidadInventario.Text = videojuego.CANTIDAD_INVENTARIO.ToString();
                txtDescuento.Text = videojuego.DESCUENTO.ToString();
                txtPrecioColones.Text = videojuego.PRECIO_COLONES.ToString();
                txtPrecioDolares.Text = videojuego.PRECIO_DOLARES.ToString();
                txtDescripcion.Text = videojuego.DESCRIPCION.ToString();
                txtFechaSalida.Text = videojuego.FECHA_SALIDA.ToString();
                txtNota.Text = videojuego.NOTA.ToString();

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
    }
}
