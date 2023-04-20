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
    public partial class frmFiltroReporteProducto : Form
    {
        public frmFiltroReporteProducto()
        {
            InitializeComponent();
        }

        private void frmReporteProducto_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Ocurrio un error al cargar el reporte");
                return;
            }
        }
    }
}
