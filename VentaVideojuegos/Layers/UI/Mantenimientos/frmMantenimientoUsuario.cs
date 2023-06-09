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
using VentaVideojuegos.Layers.Entities;

namespace VentaVideojuegos.Layers.UI
{
    public partial class frmMantenimientoUsuario : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        EstadoMantenimiento estadoFrame;

        public frmMantenimientoUsuario()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);

            MessageBox.Show("Por favor no olvide seleccionar la imagen que desea editar");

            this.btnEditar.Enabled = false;
            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
        }

        private void frmMantenimientoUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento Usuario";

            CategoriaUsuario[] categoria = (CategoriaUsuario[])Enum.GetValues(typeof(CategoriaUsuario));

            cmbCategoria.DataSource = categoria;

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
            IBLLLogin _BLLLogin= new BLLLogin();

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            dgvDatos.RowTemplate.Height = 100;

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLLogin.GetAllUsuario();

            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnBorrar.Enabled = true;
            this.dgvDatos.Enabled = true;
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtUsuario.Clear();
            this.txtPassword.Clear();
            this.cmbCategoria.SelectedIndex= -1;

            this.txtUsuario.Enabled = false;
            this.txtPassword.Enabled = false;
            this.cmbCategoria.Enabled = false;
            this.pbImagen.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtUsuario.Enabled = true;
                    this.txtPassword.Enabled = true;
                    this.cmbCategoria.Enabled = true;
                    this.pbImagen.Enabled = true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtUsuario.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtPassword.Enabled = true;
                    this.cmbCategoria.Enabled= true;
                    this.pbImagen.Enabled= true;

                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtUsuario.Focus();
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
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe digitar el nombre de usuario");
                txtUsuario.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe digitar la contraseña del usuario");
                txtPassword.Focus();
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BLLLogin _BLLLogin = new BLLLogin();
            Usuario usuario;

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    if (String.IsNullOrEmpty(txtUsuario.Text))
                    {
                        MessageBox.Show("Debe digitar el nombre de usuario");
                        txtUsuario.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Debe digitar la contraseña del usuario");
                        txtPassword.Focus();
                        return;
                    }

                    if (cmbCategoria.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar la categoria del producto");
                        cmbCategoria.Focus();
                        return;
                    }

                    if (pbImagen.Tag == null)
                    {
                        MessageBox.Show("Debe seleccionar una imagen");
                        pbImagen.Focus();
                        return;
                    }

                    usuario = new Usuario();

                    string truncatedString = Encriptado.GetSHA256(txtPassword.Text).Substring(0, Math.Min(Encriptado.GetSHA256(txtPassword.Text).Length, 32));

                    usuario.Login = txtUsuario.Text;
                    usuario.Password = truncatedString;
                    usuario.IMAGEN= (byte[])this.pbImagen.Tag;

                    if (cmbCategoria.SelectedItem.Equals(CategoriaUsuario.Administrador))
                    {
                        usuario.IdCategoria = 1;
                    }
                    else
                    {
                        if (cmbCategoria.SelectedItem.Equals(CategoriaUsuario.Procesos))
                        {
                            usuario.IdCategoria = 2;
                        }
                        else
                        {
                            if (cmbCategoria.SelectedItem.Equals(CategoriaUsuario.Reportes))
                            {
                                usuario.IdCategoria = 3;
                            }
                        }
                    }

                    try
                    {
                        List<Usuario> listaUsuarios = _BLLLogin.GetAllUsuario();

                        bool estado = false;

                        foreach(Usuario usario in listaUsuarios)
                        {
                            if (usuario.Login.Equals(usario.Login))
                            {
                                estado= true;
                            }
                        }

                        if (!estado)
                        {
                            _BLLLogin.SaveUsuario(usuario);

                            this.CargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("El usuario que desea agregar ya existe");
                            return;
                        }
                    }
                    catch (SqlException ex)
                    {
                        string message = "Ocurrio un error en la base de datos al agregar el nuevo cliente " + ex.Message;

                        _MyLogControlEventos.Error(message.ToString());

                        MessageBox.Show(message);
                        return;
                    }
                    catch (Exception ex)
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

                        if (String.IsNullOrEmpty(txtUsuario.Text))
                        {
                            MessageBox.Show("Debe digitar el nombre de usuario");
                            txtUsuario.Focus();
                            return;
                        }

                        if (String.IsNullOrEmpty(txtPassword.Text))
                        {
                            MessageBox.Show("Debe digitar la contraseña del usuario");
                            txtPassword.Focus();
                            return;
                        }

                        if (cmbCategoria.SelectedIndex == -1)
                        {
                            MessageBox.Show("Debe seleccionar la categoria del producto");
                            cmbCategoria.Focus();
                            return;
                        }

                        if (pbImagen.Tag == null)
                        {
                            MessageBox.Show("Debe seleccionar una imagen");
                            pbImagen.Focus();
                            return;
                        }

                        //telefono = this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;
                        usuario = new Usuario();

                        string truncatedString1 = Encriptado.GetSHA256(txtPassword.Text).Substring(0, Math.Min(Encriptado.GetSHA256(txtPassword.Text).Length, 32));

                        usuario.Login = txtUsuario.Text;
                        usuario.Password = truncatedString1;
                        usuario.IMAGEN = (byte[])this.pbImagen.Tag;

                        if (cmbCategoria.SelectedItem.Equals(CategoriaUsuario.Administrador))
                        {
                            usuario.IdCategoria = 1;
                        }
                        else
                        {
                            if (cmbCategoria.SelectedItem.Equals(CategoriaUsuario.Procesos))
                            {
                                usuario.IdCategoria = 2;
                            }
                            else
                            {
                                if (cmbCategoria.SelectedItem.Equals(CategoriaUsuario.Reportes))
                                {
                                    usuario.IdCategoria = 3;
                                }
                            }
                        }

                        try
                        {
                            _BLLLogin.UpdateUsuario(usuario);

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
                        MessageBox.Show("Debe seleccionar el usuario que desea editar");
                        return;
                    }

                    break;

                case EstadoMantenimiento.Borrar:

                    string mensaje = "Esta seguro que desea eliminar este usuario, esta accion es irreversible";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            _BLLLogin.DeleteUsuario(txtUsuario.Text);

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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {

                MessageBox.Show("Por favor no olvide seleccionar la imagen que desea editar");

                this.CambiarEstado(EstadoMantenimiento.Editar);

                Usuario usuario = this.dgvDatos.SelectedRows[0].DataBoundItem as Usuario;

                txtPassword.Text = usuario.Password;
                txtUsuario.Text = usuario.Login;

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar usuario que desea editar");
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Usuario usuario = this.dgvDatos.SelectedRows[0].DataBoundItem as Usuario;

                txtPassword.Text = usuario.Password;
                txtUsuario.Text = usuario.Login;

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el usuario que desea eliminar");
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
    }
}
