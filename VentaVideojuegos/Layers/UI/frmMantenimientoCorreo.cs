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
    public partial class frmMantenimientoCorreo : Form
    {
        EstadoMantenimiento estadoFrame;
        public frmMantenimientoCorreo()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.CambiarEstado(EstadoMantenimiento.Nuevo);

            this.btnEditar.Enabled = false;
            this.btnBorrar.Enabled = false;
            this.btnNuevo.Enabled = false;
        }

        private void frmMantenimientoCorreo_Load(object sender, EventArgs e)
        {
            this.Text = "Mantenimiento Correo";

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
            IBLLCorreo _BLLCorreo = new BLLCorreo();

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLCorreo.GetAllCorreo();

            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnBorrar.Enabled = true;
            this.dgvDatos.Enabled = true;
        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtIdCliente.Clear();
            this.txtCorreo.Clear();

            this.txtIdCliente.Enabled = false;
            this.txtCorreo.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtIdCliente.Enabled = true;
                    this.txtCorreo.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtCorreo.Focus();
                    estadoFrame = EstadoMantenimiento.Nuevo;
                    break;

                case EstadoMantenimiento.Editar:
                    this.txtCorreo.Enabled = true;
                    this.txtIdCliente.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtCorreo.Focus();
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

            if (String.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe digitar el numero de telefono del cliente");
                txtCorreo.Focus();
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IBLLCorreo _BLLCorreo= new BLLCorreo();
            Correo correo;

            switch (estadoFrame)
            {
                case EstadoMantenimiento.Nuevo:

                    ValidarCampos();

                    correo= new Correo();

                    correo.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                    correo.CorreoElectronico = txtCorreo.Text;

                    try
                    {
                        _BLLCorreo.SaveCorreo(correo);

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

                case EstadoMantenimiento.Editar:

                    if (this.dgvDatos.SelectedRows.Count > 0)
                    {

                        ValidarCampos();

                        //telefono = this.dgvDatos.SelectedRows[0].DataBoundItem as Telefono;
                        correo= new Correo();
                        Correo correoViejo = this.dgvDatos.SelectedRows[0].DataBoundItem as Correo;

                        correo.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                        correo.CorreoElectronico = txtCorreo.Text;

                        try
                        {
                            _BLLCorreo.UpdateCorreo(correo, correoViejo.CorreoElectronico, correoViejo.IdCliente.ToString());

                            this.CargarDatos();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Ocurrio un error en la base de datos al editar el correo");
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error en el programa al editar el correo");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar el correo que desea editar");
                        return;
                    }

                    break;

                case EstadoMantenimiento.Borrar:

                    string mensaje = "Esta seguro que desea eliminar este correo electronico, esta accion es irreversible";
                    string caption = "Advertencia";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show(mensaje, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            _BLLCorreo.DeleteCorreo(txtIdCliente.Text, txtCorreo.Text);

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

                Correo correo = this.dgvDatos.SelectedRows[0].DataBoundItem as Correo;

                txtCorreo.Text = correo.CorreoElectronico;
                txtIdCliente.Text = correo.IdCliente.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el correo que desea editar");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.SelectedRows.Count > 0)
            {
                this.CambiarEstado(EstadoMantenimiento.Borrar);

                Correo correo = this.dgvDatos.SelectedRows[0].DataBoundItem as Correo;

                txtCorreo.Text = correo.CorreoElectronico;
                txtIdCliente.Text = correo.IdCliente.ToString();

                this.btnEditar.Enabled = false;
                this.btnBorrar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.dgvDatos.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el correo que desea borrar");
            }
        }
    }
}
