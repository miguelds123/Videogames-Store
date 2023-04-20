
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteProducto
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
            this.PA_REPORTE_PRODUCTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteProducto = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteProducto();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PA_REPORTE_PRODUCTOTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteProductoTableAdapters.PA_REPORTE_PRODUCTOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_PRODUCTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // PA_REPORTE_PRODUCTOBindingSource
            // 
            this.PA_REPORTE_PRODUCTOBindingSource.DataMember = "PA_REPORTE_PRODUCTO";
            this.PA_REPORTE_PRODUCTOBindingSource.DataSource = this.DataSetReporteProducto;
            // 
            // DataSetReporteProducto
            // 
            this.DataSetReporteProducto.DataSetName = "DataSetReporteProducto";
            this.DataSetReporteProducto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetReporteProducto";
            reportDataSource1.Value = this.PA_REPORTE_PRODUCTOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportProducto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // PA_REPORTE_PRODUCTOTableAdapter
            // 
            this.PA_REPORTE_PRODUCTOTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteProducto";
            this.Load += new System.EventHandler(this.frmReporteProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_PRODUCTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_PRODUCTOBindingSource;
        private DataSetReporteProducto DataSetReporteProducto;
        private DataSetReporteProductoTableAdapters.PA_REPORTE_PRODUCTOTableAdapter PA_REPORTE_PRODUCTOTableAdapter;
    }
}