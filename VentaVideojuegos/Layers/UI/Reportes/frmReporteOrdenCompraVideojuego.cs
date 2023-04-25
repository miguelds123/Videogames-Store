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
    public partial class frmReporteOrdenCompraVideojuego : Form
    {
        private DateTime Fecha;

        public frmReporteOrdenCompraVideojuego(DateTime pFecha)
        {
            InitializeComponent();
            Fecha = pFecha;
        }

        private void frmReporteOrdenCompraVideojuego_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Orden Compra Videojuego";
            // TODO: This line of code loads data into the 'DataSetReporteOrdenCompraVideojuego.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHA' table. You can move, or remove it, as needed.
            this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter.Fill(this.DataSetReporteOrdenCompraVideojuego.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHA, Fecha);

            this.reportViewer1.RefreshReport();
        }
    }
}
