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
using VentaVideojuegos.Layers.DAL;

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
            List<Provincia> lista = null;

            // Cambiar el estado
            this.CambiarEstado(EstadoMantenimiento.Ninguno);

            // dgvDatos.RowTemplate.Height = 100;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Cargar el DataGridView
            this.dgvDatos.DataSource = _BLLCliente.GetAllCliente();

            // Cargar el combo
            this.cmbProvincia.Items.Clear();
            lista = _BLLProvincia.GetAllProvincia();

            foreach(Provincia provincia in lista)
            {
                this.cmbProvincia.Items.Add(provincia);
            }

            // Colocar el primero como default
            this.cmbProvincia.SelectedIndex = -1;
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
