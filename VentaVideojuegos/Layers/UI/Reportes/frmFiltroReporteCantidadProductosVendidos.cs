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

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public frmFiltroReporteCantidadProductosVendidos()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
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
                        frmReporteCantidaVideojuegosVendidos frmReporteCantidaVideojuegosVendidos = new frmReporteCantidaVideojuegosVendidos(dateTimePicker1.Value, dateTimePicker2.Value);

                        frmReporteCantidaVideojuegosVendidos.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Ocurrio un error al cargar el reporte: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

    private void frmFiltroReporteCantidadProductosVendidos_Load(object sender, EventArgs e)
        {
            this.Text = "Filtro Reporte Cantidad de Productos Vendidos";
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Producto");
            cmbTipo.Items.Add("Videojuego");
        }
    }
}
