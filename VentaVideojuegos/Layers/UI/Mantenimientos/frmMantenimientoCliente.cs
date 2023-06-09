﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Interfaces;
using VentaVideojuegos.Layers.DAL;
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmMantenimientoCliente : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        EstadoMantenimiento estadoFrame;
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento Clientes";

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
            IBLLCliente _BLLCliente = new BLLCliente();
            IBLLProvincia _BLLProvincia= new BLLProvincia();
            IBLLCanton _BLLCanton= new BLLCanton();
            List<Provincia> listaProvincias = null;
            List<Canton> listaCantones = null;

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLCliente.GetAllCliente();

            // Cargar el combo
            this.cmbProvincia.Items.Clear();
            this.cmbCanton.Items.Clear();
            listaProvincias = _BLLProvincia.GetAllProvincia();
            listaCantones= _BLLCanton.GetAllCanton();

            //foreach(Provincia provincia in listaProvincias)
            //{
            //    this.cmbProvincia.Items.Add(provincia);
            //}

            //foreach(Canton canton in listaCantones)
            //{
            //    this.cmbCanton.Items.Add((canton));
            //}

            listaProvincias.ForEach(provincia => this.cmbProvincia.Items.Add(provincia));
            listaCantones.ForEach(canton => this.cmbCanton.Items.Add(canton));

            this.cmbEstado.Items.Clear();

            this.cmbEstado.Items.Add(Estado.Activo);
            this.cmbEstado.Items.Add(Estado.Inactivo);

            // Colocar el primero como default
            this.cmbProvincia.SelectedIndex = -1;
            this.cmbCanton.SelectedIndex = -1;
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnBorrar.Enabled = true;
            this.dgvDatos.Enabled = true;
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido1.Clear();
            this.txtApellido2.Clear();
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
            this.txtComentario.Clear();
            this.cmbProvincia.SelectedIndex = -1;
            this.cmbCanton.SelectedIndex = -1;
            this.cmbEstado.SelectedIndex = -1;

            this.txtIdentificacion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtCodigoPostal.Enabled = false;
            this.txtComentario.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnConfirmar.Enabled = false;
            this.cmbProvincia.Enabled = false;
            this.cmbCanton.Enabled = false;
            this.cmbEstado.Enabled = false;

            if (cmbProvincia.Items.Count > 0)
            {
                this.cmbProvincia.SelectedIndex = -1;
            }

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtIdentificacion.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.txtDireccion.Enabled=true;
                    this.txtCodigoPostal.Enabled = true;
                    this.txtComentario.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnConfirmar.Enabled = true;
                    this.cmbEstado.Enabled=true;
                    txtIdentificacion.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.txtDireccion.Enabled = true;
                    this.txtCodigoPostal.Enabled = true;
                    this.txtComentario.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnConfirmar.Enabled = true;
                    this.cmbEstado.Enabled=true;
                    txtIdentificacion.Focus();
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
            if (String.IsNullOrEmpty(txtIdentificacion.Text))
            {
                MessageBox.Show("Debe digitar la identificacion del cliente");
                txtIdentificacion.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe digitar el nombre del cliente");
                txtNombre.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtApellido1.Text))
            {
                MessageBox.Show("Debe digitar el apellido 1 del cliente");
                txtApellido1.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtApellido2.Text))
            {
                MessageBox.Show("Debe digitar el apellido 2 del cliente");
                txtApellido2.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Debe digitar la direccion del cliente");
                txtDireccion.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtCodigoPostal.Text))
            {
                MessageBox.Show("Debe digitar el codigo postal del cliente");
                txtCodigoPostal.Focus();
                return;
            }

            if (cmbProvincia.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la provincia del cliente");
                cmbProvincia.Focus();
                return;
            }

            if (cmbCanton.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el canton del cliente");
                cmbCanton.Focus();
                return;
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);

            this.btnEditar.Enabled = false;
            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLCliente _BLLCliente = new BLLCliente();
            Cliente cliente;

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    if (String.IsNullOrEmpty(txtIdentificacion.Text))
                    {
                        MessageBox.Show("Debe digitar la identificacion del cliente");
                        txtIdentificacion.Focus();
                        return;
                    }

                    try
                    {
                        int num = Convert.ToInt32(txtIdentificacion.Text);
                    }
                    catch (Exception ex)
                    {
                        string message = "El id debe estar compuesto de numero enteros";

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
                        txtIdentificacion.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtNombre.Text))
                    {
                        MessageBox.Show("Debe digitar el nombre del cliente");
                        txtNombre.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtApellido1.Text))
                    {
                        MessageBox.Show("Debe digitar el apellido 1 del cliente");
                        txtApellido1.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtApellido2.Text))
                    {
                        MessageBox.Show("Debe digitar el apellido 2 del cliente");
                        txtApellido2.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtDireccion.Text))
                    {
                        MessageBox.Show("Debe digitar la direccion del cliente");
                        txtDireccion.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtCodigoPostal.Text))
                    {
                        MessageBox.Show("Debe digitar el codigo postal del cliente");
                        txtCodigoPostal.Focus();
                        return;
                    }

                    if (cmbProvincia.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la provincia del cliente");
                        cmbProvincia.Focus();
                        return;
                    }

                    if (cmbCanton.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el canton del cliente");
                        cmbCanton.Focus();
                        return;
                    }

                    if (cmbEstado.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar el estado del cliente");
                        cmbEstado.Focus();
                        return;
                    }

                    cliente = new Cliente();

                    cliente.ID = Convert.ToInt32((string)txtIdentificacion.Text);
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido1 = txtApellido1.Text;
                    cliente.Apellido2 = txtApellido2.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.IdProvincia = ((Provincia)cmbProvincia.SelectedItem).Id;
                    cliente.IdCanton = ((Canton)cmbCanton.SelectedItem).Id;
                    cliente.CodigoPostal = txtCodigoPostal.Text;
                    cliente.Comentario = txtComentario.Text;

                    if (cmbEstado.SelectedItem.Equals(Estado.Activo))
                    {
                        cliente.Estado = 1;
                    }
                    else
                    {
                        if (cmbEstado.SelectedItem.Equals(Estado.Inactivo))
                        {
                            cliente.Estado = 0;
                        }
                    }

                    try
                    {
                        List<Cliente> lista= _BLLCliente.GetAllCliente();

                        bool estado= false;

                        foreach(Cliente cliente1 in lista)
                        {
                            if (cliente1.ID == cliente.ID)
                            {
                                estado= true;
                            }
                        }

                        if (estado == false)
                        {
                            _BLLCliente.SaveCliente(cliente);

                            this.CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("El id que intento agregar ya a sido registrado anteriormente, por favor digite uno que no se encuentre registrado");
                            txtIdentificacion.Focus();
                            return;
                        }
                    }
                    catch(SqlException ex)
                    {
                        string message = "Ocurrio un error en la base de datos al agregar el nuevo cliente " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
                        return;
                    }
                    catch(Exception ex)
                    {
                        string message = "Ocurrio un error en el programa al agregar el nuevo cliente " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
                        return;
                    }
                    
                    break;

                case EstadoMantenimiento.Editar:

                    if (this.dgvDatos.SelectedRows.Count > 0)
                    {

                        if (String.IsNullOrEmpty(txtIdentificacion.Text))
                        {
                            MessageBox.Show("Debe digitar la identificacion del cliente");
                            txtIdentificacion.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtNombre.Text))
                        {
                            MessageBox.Show("Debe digitar el nombre del cliente");
                            txtNombre.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtApellido1.Text))
                        {
                            MessageBox.Show("Debe digitar el apellido 1 del cliente");
                            txtApellido1.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtApellido2.Text))
                        {
                            MessageBox.Show("Debe digitar el apellido 2 del cliente");
                            txtApellido2.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtDireccion.Text))
                        {
                            MessageBox.Show("Debe digitar la direccion del cliente");
                            txtDireccion.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtCodigoPostal.Text))
                        {
                            MessageBox.Show("Debe digitar el codigo postal del cliente");
                            txtCodigoPostal.Focus();
                            return;
                        }

                        if (cmbProvincia.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar la provincia del cliente");
                            cmbProvincia.Focus();
                            return;
                        }

                        if (cmbCanton.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar el canton del cliente");
                            cmbCanton.Focus();
                            return;
                        }

                        if (cmbEstado.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar el estado del cliente");
                            cmbEstado.Focus();
                            return;
                        }

                        cliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;

                        txtIdentificacion.Text = cliente.ID.ToString();
                        cliente.Nombre = txtNombre.Text;
                        cliente.Apellido1 = txtApellido1.Text;
                        cliente.Apellido2 = txtApellido2.Text;
                        cliente.Direccion = txtDireccion.Text;
                        cliente.IdProvincia = ((Provincia)cmbProvincia.SelectedItem).Id;
                        cliente.IdCanton = ((Canton)cmbCanton.SelectedItem).Id;
                        cliente.CodigoPostal = txtCodigoPostal.Text;
                        cliente.Comentario = txtComentario.Text;

                        if (cmbEstado.SelectedItem.Equals(Estado.Activo))
                        {
                            cliente.Estado = 1;
                        }
                        else
                        {
                            if (cmbEstado.SelectedItem.Equals(Estado.Inactivo))
                            {
                                cliente.Estado = 0;
                            }
                        }

                        try
                        {
                            _BLLCliente.UpdateCliente(cliente);

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            string message = "Ocurrio un error en la base de datos al editar el cliente " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                        catch (Exception ex)
                        {
                            string message = "Ocurrio un error en el programa al editar el cliente " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar el cliente que desea editar");
                        return;
                    }

                    break;

                case EstadoMantenimiento.Borrar:

                    string mensaje = "Esta seguro que desea deshabilitar este cliente";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            //_BLLCliente.DeleteCliente(txtIdentificacion.Text);

                            //this.CargarDatos();

                            _BLLCliente.BorradoLogico(txtIdentificacion.Text);

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            string message = "Ocurrio un error en la base de datos al borrar el cliente " + ex.Message; 

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                        catch (Exception ex)
                        {
                            string message = "Ocurrio un error en el programa al borrar el cliente " + ex.Message;

                            _MyLogControlEventos.Error(message.ToString());

                            MessageBox.Show(message);
                            return;
                        }
                    }

                    break;
            }

            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Editar);

                MessageBox.Show("Porfavor, no olvide seleccionar la provincia y canton del cliente");

                Cliente cliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;

                txtIdentificacion.Text = cliente.ID.ToString();
                txtNombre.Text= cliente.Nombre.ToString();
                txtApellido1.Text= cliente.Apellido1.ToString();
                txtApellido2.Text= cliente.Apellido2.ToString();
                txtDireccion.Text= cliente.Direccion.ToString();
                txtCodigoPostal.Text= cliente.CodigoPostal.ToString();
                txtComentario.Text= cliente.Comentario.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el cliente que desea editar");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Cliente cliente = this.dgvDatos.SelectedRows[0].DataBoundItem as Cliente;

                txtIdentificacion.Text = cliente.ID.ToString();
                txtNombre.Text = cliente.Nombre.ToString();
                txtApellido1.Text = cliente.Apellido1.ToString();
                txtApellido2.Text = cliente.Apellido2.ToString();
                txtDireccion.Text = cliente.Direccion.ToString();
                txtCodigoPostal.Text = cliente.CodigoPostal.ToString();
                txtComentario.Text = cliente.Comentario.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el cliente que desea borrar");
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex != -1)
            {
                cmbCanton.Enabled = true;

                cmbCanton.Items.Clear();

                List<Canton> listaTodosCantones = new List<Canton>();

                BLLCanton _BLLCanton = new BLLCanton();

                listaTodosCantones = _BLLCanton.GetAllCanton();

                Provincia provincia = cmbProvincia.SelectedItem as Provincia;

                foreach (Canton canton in listaTodosCantones)
                {
                    if (canton.IdProvincia == provincia.Id)
                    {
                        cmbCanton.Items.Add(canton);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar la provincia");
                cmbProvincia.Focus();
                return;
            }
        }

        private void cmbProvincia_MouseClick(object sender, MouseEventArgs e)
        {
            cmbCanton.Enabled = false;
            cmbCanton.SelectedIndex = -1;
        }
    }
}
