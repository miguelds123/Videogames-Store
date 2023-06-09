﻿using System;
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
    public partial class frmFiltroReporteOrdenCompraProducto : Form
    {
        private static readonly log4net.ILog _MyLogControlEventos =
        log4net.LogManager.GetLogger("MyControlEventos");

        public frmFiltroReporteOrdenCompraProducto()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar el tipo de producto que desea consultar");
                    return;
                }

                if (cmbTipo.SelectedItem.Equals("Producto"))
                {
                    frmReporteOrdenCompraProducto frmReporteOrdenCompraProducto = new frmReporteOrdenCompraProducto(dateTimePicker1.Value);

                    frmReporteOrdenCompraProducto.Show();
                }
                else
                {
                    if (cmbTipo.SelectedItem.Equals("Videojuego"))
                    {
                        frmReporteOrdenCompraVideojuego frmReporteOrdenCompraVideojuego = new frmReporteOrdenCompraVideojuego(dateTimePicker1.Value);

                        frmReporteOrdenCompraVideojuego.Show();
                    }
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

        private void frmFiltroReporteOrdenCompraProducto_Load(object sender, EventArgs e)
        {
            this.Text = "Filtro Reporte Orden Compra";
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Producto");
            cmbTipo.Items.Add("Videojuego");
        }
    }
}
