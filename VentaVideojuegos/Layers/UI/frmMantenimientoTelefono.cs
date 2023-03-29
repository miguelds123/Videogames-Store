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
    public partial class frmMantenimientoTelefono : Form
    {
        EstadoMantenimiento estadoFrame;
        public frmMantenimientoTelefono()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTelefono_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento Clientes";

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
            IBLLTelefono _BLLTelefono= new BLLTelefono();

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLTelefono.GetAllTelefono();

            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnBorrar.Enabled = true;
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtIdCliente.Clear();
            this.txtNumeroTelefono.Clear();

            this.txtIdCliente.Enabled = false;
            this.txtNumeroTelefono.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtIdCliente.Enabled = true;
                    this.txtNumeroTelefono.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtNumeroTelefono.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtNumeroTelefono.Enabled = true;
                    this.txtIdCliente.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtNumeroTelefono.Focus();
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
            if (String.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Debe digitar la identificacion del cliente");
                txtIdCliente.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtNumeroTelefono.Text))
            {
                MessageBox.Show("Debe digitar el numero de telefono del cliente");
                txtNumeroTelefono.Focus();
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
            IBLLTelefono _BLLTelefono= new BLLTelefono();
            Telefono telefono;

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    ValidarCampos();

                    telefono=new Telefono();

                    telefono.IdCliente= Convert.ToInt32(txtIdCliente.Text);
                    telefono.Numero = txtNumeroTelefono.Text;

                    try
                    {
                        _BLLTelefono.SaveTelefono(telefono);

                        this.CargarDatos();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ocurrio un error en la base de datos al agregar el nuevo cliente");
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error en el programa al agregar el nuevo cliente");
                        return;
                    }

                    break;

                case EstadoMantenimiento.Editar:

                    if (this.dgvDatos.SelectedRows.Count > 0)
                    {

                        ValidarCampos();

                        //telefono = this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;
                        telefono = new Telefono();
                        Telefono telefonoViejo= this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;

                        telefono.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                        telefono.Numero= txtNumeroTelefono.Text;

                        try
                        {
                            _BLLTelefono.UpdateTelefono(telefono, telefonoViejo.Numero, telefonoViejo.IdCliente.ToString());

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Ocurrio un error en la base de datos al editar el cliente");
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error en el programa al editar el cliente");
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

                    string mensaje = "Esta seguro que desea eliminar este numero de telefono, esta accion es irreversible";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            _BLLTelefono.DeleteTelefono(txtIdCliente.Text, txtNumeroTelefono.Text);

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

                Telefono telefono = this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;

                txtNumeroTelefono.Text = telefono.Numero;
                txtIdCliente.Text = telefono.IdCliente.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el numero de telefono que desea editar");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Telefono telefono = this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;

                txtNumeroTelefono.Text = telefono.Numero;
                txtIdCliente.Text = telefono.IdCliente.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el numeor de telefono que desea borrar");
            }
        }
    }
}
