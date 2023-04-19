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
    public partial class frmReporteFactura : Form
    {
        private int numFactura;
        Usuario _Usuario = new Usuario();

        public frmReporteFactura(int pNumeroFactura)
        {
            InitializeComponent();
            numFactura = pNumeroFactura;
            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetReporteFactura.PA_REPORTE_FACTURA_PRODUCTOS' table. You can move, or remove it, as needed.
            this.PA_REPORTE_FACTURA_PRODUCTOSTableAdapter.Fill(this.DataSetReporteFactura.PA_REPORTE_FACTURA_PRODUCTOS, numFactura);
            this.reportViewer1.RefreshReport();
        }
    }
}
