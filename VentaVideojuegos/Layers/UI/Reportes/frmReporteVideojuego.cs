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
    public partial class frmReporteVideojuego : Form
    {
        private int numProducto = 0;

        public frmReporteVideojuego(int pNumProducto)
        {
            InitializeComponent();
            numProducto = pNumProducto;
        }

        private void frmReporteVideojuego_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Videojuego";
            // TODO: This line of code loads data into the 'DataSetReporteVideojuego.PA_REPORTE_VIDEOJUEGO' table. You can move, or remove it, as needed.
            this.PA_REPORTE_VIDEOJUEGOTableAdapter.Fill(this.DataSetReporteVideojuego.PA_REPORTE_VIDEOJUEGO, numProducto);

            this.reportViewer1.RefreshReport();
        }
    }
}
