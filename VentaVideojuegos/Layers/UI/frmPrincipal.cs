using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaVideojuegos.Layers.UI;

namespace VentaVideojuegos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Principal";

                Utilitarios.CultureInfo();

                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex.Message);
                return;
            }
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoCliente frmMantenimientoCliente;

            try
            {
                frmMantenimientoCliente= new frmMantenimientoCliente();
                frmMantenimientoCliente.MdiParent = this;
                frmMantenimientoCliente.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un error al abrir el frame");
            }
        }
    }
}
