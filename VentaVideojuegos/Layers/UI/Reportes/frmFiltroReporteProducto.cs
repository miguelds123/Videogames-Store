using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos.Layers.UI.Reportes
{
    public partial class frmFiltroReporteProducto : Form
    {

        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public frmFiltroReporteProducto()
        {
            InitializeComponent();
        }

        private void frmReporteProducto_Load(object sender, EventArgs e)
        {
            this.Text = "Filtro Reporte Producto";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdProducto.Text))
                {
                    frmReporteProducto frmReporteProducto = new frmReporteProducto(Convert.ToInt32(txtIdProducto.Text));

                    frmReporteProducto.Show();
                }
                else
                {
                    frmReporteProductoAll frmReporteProductoAll = new frmReporteProductoAll();

                    frmReporteProductoAll.Show();
                }
            }
            catch(Exception ex)
            {
                string message= "Ocurrio un error al cargar el reporte: " + ex.Message;

                _MyLogControlEventos.Error(message.ToString());

                MessageBox.Show(message);
                return;
            }
        }
    }
}
