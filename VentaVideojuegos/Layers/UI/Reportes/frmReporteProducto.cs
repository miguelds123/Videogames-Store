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
    public partial class frmReporteProducto : Form
    {
        private int numProducto= 0;

        public frmReporteProducto(int pNumProducto)
        {
            InitializeComponent();
            numProducto = pNumProducto;
        }

        private void frmReporteProducto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetReporteProducto.PA_REPORTE_PRODUCTO' table. You can move, or remove it, as needed.
            this.PA_REPORTE_PRODUCTOTableAdapter.Fill(this.DataSetReporteProducto.PA_REPORTE_PRODUCTO, numProducto);

            this.reportViewer1.RefreshReport();
        }
    }
}
