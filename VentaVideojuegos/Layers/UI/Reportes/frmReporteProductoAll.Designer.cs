
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteProductoAll
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
            this.PA_REPORTE_PRODUCTO_ALLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteProductoAll = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteProductoAll();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PA_REPORTE_PRODUCTO_ALLTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteProductoAllTableAdapters.PA_REPORTE_PRODUCTO_ALLTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_PRODUCTO_ALLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteProductoAll)).BeginInit();
            this.SuspendLayout();
            // 
            // PA_REPORTE_PRODUCTO_ALLBindingSource
            // 
            this.PA_REPORTE_PRODUCTO_ALLBindingSource.DataMember = "PA_REPORTE_PRODUCTO_ALL";
            this.PA_REPORTE_PRODUCTO_ALLBindingSource.DataSource = this.DataSetReporteProductoAll;
            // 
            // DataSetReporteProductoAll
            // 
            this.DataSetReporteProductoAll.DataSetName = "DataSetReporteProductoAll";
            this.DataSetReporteProductoAll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetReporteProductoAll1";
            reportDataSource1.Value = this.PA_REPORTE_PRODUCTO_ALLBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportProductoAll.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // PA_REPORTE_PRODUCTO_ALLTableAdapter
            // 
            this.PA_REPORTE_PRODUCTO_ALLTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteProductoAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteProductoAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteProductoAll";
            this.Load += new System.EventHandler(this.frmReporteProductoAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_PRODUCTO_ALLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteProductoAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_PRODUCTO_ALLBindingSource;
        private DataSetReporteProductoAll DataSetReporteProductoAll;
        private DataSetReporteProductoAllTableAdapters.PA_REPORTE_PRODUCTO_ALLTableAdapter PA_REPORTE_PRODUCTO_ALLTableAdapter;
    }
}