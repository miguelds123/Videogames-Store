﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        EstadoMantenimiento estadoFrame;
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Dio error la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dio error el programa");
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

            foreach(Provincia provincia in listaProvincias)
            {
                this.cmbProvincia.Items.Add(provincia);
            }

            foreach(Canton canton in listaCantones)
            {
                this.cmbCanton.Items.Add((canton));
            }

            // Colocar el primero como default
            this.cmbProvincia.SelectedIndex = -1;
            this.cmbCanton.SelectedIndex = -1;
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

            this.txtIdentificacion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtCodigoPostal.Enabled = false;
            this.txtComentario.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cmbProvincia.Enabled = false;
            this.cmbCanton.Enabled = false;
            this.cmbDistrito.Enabled = false;

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
                    this.cmbCanton.Enabled=true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtIdentificacion.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtIdentificacion.Enabled = false;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtNombre.Focus();
                    break;

                case EstadoMantenimiento.Borrar:
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
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLCliente _BLLCliente = new BLLCliente();

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    ValidarCampos();

                    Cliente cliente= new Cliente();

                    cliente.ID = Convert.ToInt32((string)txtIdentificacion.Text);
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido1 = txtApellido1.Text;
                    cliente.Apellido2 = txtApellido2.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.IdProvincia = ((Provincia)cmbProvincia.SelectedItem).Id;
                    cliente.IdCanton = ((Canton)cmbCanton.SelectedItem).Id;
                    cliente.IdDistrito = 1;
                    cliente.CodigoPostal = txtCodigoPostal.Text;
                    cliente.Comentario = txtComentario.Text;

                    try
                    {
                        _BLLCliente.SaveCliente(cliente);

                        this.CargarDatos();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show("Ocurrio un error en la base de datos al agregar el nuevo cliente");
                        return;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error en el programa al agregar el nuevo cliente");
                        return;
                    }
                    
                    break;
            }

            this.CambiarEstado(EstadoMantenimiento.Ninguno);
        }
    }
}
