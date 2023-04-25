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
    public partial class frmReporteProductoAll : Form
    {
        public frmReporteProductoAll()
        {
            InitializeComponent();
        }

        private void frmReporteProductoAll_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Producto";
            // TODO: This line of code loads data into the 'DataSetReporteProductoAll.PA_REPORTE_PRODUCTO_ALL' table. You can move, or remove it, as needed.
            this.PA_REPORTE_PRODUCTO_ALLTableAdapter.Fill(this.DataSetReporteProductoAll.PA_REPORTE_PRODUCTO_ALL);

            this.reportViewer1.RefreshReport();
        }
    }
}
