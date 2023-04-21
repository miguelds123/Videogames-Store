
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteOrdenCompraVideojuego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteOrdenCompraVideojuego = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteOrdenCompraVideojuego();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteOrdenCompraVideojuegoTableAdapters.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteOrdenCompraVideojuego)).BeginInit();
            this.SuspendLayout();
            // 
            // PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource
            // 
            this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource.DataMember = "PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHA";
            this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource.DataSource = this.DataSetReporteOrdenCompraVideojuego;
            // 
            // DataSetReporteOrdenCompraVideojuego
            // 
            this.DataSetReporteOrdenCompraVideojuego.DataSetName = "DataSetReporteOrdenCompraVideojuego";
            this.DataSetReporteOrdenCompraVideojuego.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetReporteOrdenCompraVideojuego1";
            reportDataSource1.Value = this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportOrdenCompraVideojuego.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 434);
            this.reportViewer1.TabIndex = 0;
            // 
            // PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter
            // 
            this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteOrdenCompraVideojuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteOrdenCompraVideojuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteOrdenCompraVideojuego";
            this.Load += new System.EventHandler(this.frmReporteOrdenCompraVideojuego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteOrdenCompraVideojuego)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHABindingSource;
        private DataSetReporteOrdenCompraVideojuego DataSetReporteOrdenCompraVideojuego;
        private DataSetReporteOrdenCompraVideojuegoTableAdapters.PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter PA_REPORTE_ORDEN_COMPRA_VIDEOJUEGO_POR_FECHATableAdapter;
    }
}