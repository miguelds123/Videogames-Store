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
    public partial class frmReporteCantidaVideojuegosVendidos : Form
    {
        DateTime fechaInicio;
        DateTime fechaFinal;

        public frmReporteCantidaVideojuegosVendidos(DateTime pFechaIncio, DateTime pFechaFinal)
        {
            InitializeComponent();
            fechaInicio = pFechaIncio;
            fechaFinal = pFechaFinal;
        }

        private void frmReporteCantidaVideojuegosVendidos_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Cantidad Videojuegos Vendidos";
            // TODO: This line of code loads data into the 'DataSetReporteCantidadVideojuegoVendidos.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOS' table. You can move, or remove it, as needed.
            this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter.Fill(this.DataSetReporteCantidadVideojuegoVendidos.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOS, fechaInicio, fechaFinal);

            this.reportViewer1.RefreshReport();
        }
    }
}
