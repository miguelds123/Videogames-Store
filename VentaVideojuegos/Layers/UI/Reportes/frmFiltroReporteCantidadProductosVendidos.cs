using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos.Layers.UI.Reportes
{
    public partial class frmFiltroReporteCantidadProductosVendidos : Form
    {
        public frmFiltroReporteCantidadProductosVendidos()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Porfavor, seleccione el tipo de producto que desea consultar");
                return;
            }

            if (cmbTipo.SelectedItem.Equals("Producto"))
            {
                frmReporteCantidadProductosVendidos frmReporteCantidadProductosVendidos = new frmReporteCantidadProductosVendidos(dateTimePicker1.Value, dateTimePicker2.Value);

                frmReporteCantidadProductosVendidos.Show();
            }
            else
            {
                if (cmbTipo.SelectedItem.Equals("Videojuego"))
                {
                    MessageBox.Show("Insertar Reporte Videojuego");
                }
            }
        }

        private void frmFiltroReporteCantidadProductosVendidos_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Producto");
            cmbTipo.Items.Add("Videojuego");
        }
    }
}
