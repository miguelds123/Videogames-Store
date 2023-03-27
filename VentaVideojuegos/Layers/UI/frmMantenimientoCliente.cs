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
    public partial class frmMantenimientoCliente : Form
    {
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCliente_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            IBLLCliente _BLLCliente = new BLLCliente();

        }

        private void CambiarEstado(EstadoMantenimiento estado)
        {
            this.txtIdentificacion.Clear();
            this.txtNombre.Clear();
            this.txtApellido1.Clear();
            this.txtApellido2.Clear();

            this.txtIdentificacion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido1.Enabled = false;
            this.txtApellido2.Enabled = false;

            this.btnAceptar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cmbProvincia.Enabled = false;

            if (cmbProvincia.Items.Count > 0)
            {
                this.cmbProvincia.SelectedIndex = 0;
            }

            switch (estado)
            {
                case EstadoMantenimiento.Nuevo:
                    this.txtIdentificacion.Enabled = true;
                    this.txtNombre.Enabled = true;
                    this.txtApellido1.Enabled = true;
                    this.txtApellido2.Enabled = true;
                    this.cmbProvincia.Enabled = true;
                    this.btnAceptar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    txtIdentificacion.Focus();
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
                    break;
            }
        }
    }
}
