
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteCantidaVideojuegosVendidos
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
            this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteCantidadVideojuegoVendidos = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteCantidadVideojuegoVendidos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteCantidadVideojuegoVendidosTableAdapters.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteCantidadVideojuegoVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource
            // 
            this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource.DataMember = "PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOS";
            this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource.DataSource = this.DataSetReporteCantidadVideojuegoVendidos;
            // 
            // DataSetReporteCantidadVideojuegoVendidos
            // 
            this.DataSetReporteCantidadVideojuegoVendidos.DataSetName = "DataSetReporteCantidadVideojuegoVendidos";
            this.DataSetReporteCantidadVideojuegoVendidos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetReporteCantidadVideojuegos1";
            reportDataSource1.Value = this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportCantidadVideojuegosVendidos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter
            // 
            this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteCantidaVideojuegosVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteCantidaVideojuegosVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteCantidaVideojuegosVendidos";
            this.Load += new System.EventHandler(this.frmReporteCantidaVideojuegosVendidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteCantidadVideojuegoVendidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSBindingSource;
        private DataSetReporteCantidadVideojuegoVendidos DataSetReporteCantidadVideojuegoVendidos;
        private DataSetReporteCantidadVideojuegoVendidosTableAdapters.PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter PA_REPORTE_CANTIDAD_VIDEOJUEGOS_VENDIDOSTableAdapter;
    }
}