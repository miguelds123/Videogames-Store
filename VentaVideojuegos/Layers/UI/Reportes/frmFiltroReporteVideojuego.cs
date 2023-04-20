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
    public partial class frmFiltroReporteVideojuego : Form
    {
        public frmFiltroReporteVideojuego()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdProducto.Text))
                {
                    frmReporteVideojuego frmReporteVideojuego = new frmReporteVideojuego(Convert.ToInt32(txtIdProducto.Text));

                    frmReporteVideojuego.Show();
                }
                else
                {
                    frmReporteVideojuegoAll frmReporteVideojuegoAll = new frmReporteVideojuegoAll();

                    frmReporteVideojuegoAll.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar el reporte");
                return;
            }
        }
    }
}
