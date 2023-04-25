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
    public partial class frmReporteVideojuegoAll : Form
    {
        public frmReporteVideojuegoAll()
        {
            InitializeComponent();
        }

        private void frmReporteVideojuegoAll_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Videojuego";
            // TODO: This line of code loads data into the 'DataSetReporteVideojuegoAll.PA_REPORTE_VIDEOJUEGO_ALL' table. You can move, or remove it, as needed.
            this.PA_REPORTE_VIDEOJUEGO_ALLTableAdapter.Fill(this.DataSetReporteVideojuegoAll.PA_REPORTE_VIDEOJUEGO_ALL);

            this.reportViewer1.RefreshReport();
        }
    }
}
