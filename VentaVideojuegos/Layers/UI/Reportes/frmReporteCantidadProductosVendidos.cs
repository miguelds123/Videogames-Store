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
    public partial class frmReporteCantidadProductosVendidos : Form
    {
        DateTime fechaIncio;
        DateTime fechaFinal;

        public frmReporteCantidadProductosVendidos(DateTime pFechaInicio, DateTime pFechaFinal)
        {
            InitializeComponent();
            fechaFinal = pFechaFinal;
            fechaIncio = pFechaInicio;
        }

        private void frmReporteCantidadProductosVendidos_Load(object sender, EventArgs e)
        {
            this.Text = "Reporte Cantidad de Producto Vendidos";
            // TODO: This line of code loads data into the 'DataSetReporteCantidadProductosVendidos.PA_REPORTE_CANTIDAD_PRODUCTOS_VENDIDOS' table. You can move, or remove it, as needed.
            this.PA_REPORTE_CANTIDAD_PRODUCTOS_VENDIDOSTableAdapter.Fill(this.DataSetReporteCantidadProductosVendidos.PA_REPORTE_CANTIDAD_PRODUCTOS_VENDIDOS, fechaIncio, fechaFinal);

            this.reportViewer1.RefreshReport();
        }
    }
}
