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
    public partial class frmReporteOrdenCompraProducto : Form
    {
        private DateTime Fecha;

        public frmReporteOrdenCompraProducto(DateTime pFecha)
        {
            InitializeComponent();
            Fecha = pFecha;
        }

        private void frmReporteOrdenCompraProducto_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Orden Compra Producto";
            // TODO: This line of code loads data into the 'DataSetReporteOrdenCompraProducto.PA_REPORTE_ORDEN_COMPRA_POR_FECHA' table. You can move, or remove it, as needed.
            this.PA_REPORTE_ORDEN_COMPRA_POR_FECHATableAdapter.Fill(this.DataSetReporteOrdenCompraProducto.PA_REPORTE_ORDEN_COMPRA_POR_FECHA, Fecha);

            this.reportViewer1.RefreshReport();
        }
    }
}
