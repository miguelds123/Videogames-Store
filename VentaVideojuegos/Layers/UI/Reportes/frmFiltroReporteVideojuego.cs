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
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

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
                string message = "Ocurrio un error al cargar el reporte: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }

        private void frmFiltroReporteVideojuego_Load(object sender, EventArgs e)
        {
            this.Text = "Filtro Reporte Videojuego";
        }
    }
}
