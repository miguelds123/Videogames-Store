
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteFactura));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PA_REPORTE_FACTURA_PRODUCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteFactura = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteFactura();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCorreo = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PA_REPORTE_FACTURA_PRODUCTOSTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteFacturaTableAdapters.PA_REPORTE_FACTURA_PRODUCTOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_FACTURA_PRODUCTOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteFactura)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PA_REPORTE_FACTURA_PRODUCTOSBindingSource
            // 
            this.PA_REPORTE_FACTURA_PRODUCTOSBindingSource.DataMember = "PA_REPORTE_FACTURA_PRODUCTOS";
            this.PA_REPORTE_FACTURA_PRODUCTOSBindingSource.DataSource = this.DataSetReporteFactura;
            // 
            // DataSetReporteFactura
            // 
            this.DataSetReporteFactura.DataSetName = "DataSetReporteFactura";
            this.DataSetReporteFactura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCorreo,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 55);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCorreo
            // 
            this.btnCorreo.Image = ((System.Drawing.Image)(resources.GetObject("btnCorreo.Image")));
            this.btnCorreo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCorreo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCorreo.Name = "btnCorreo";
            this.btnCorreo.Size = new System.Drawing.Size(164, 52);
            this.btnCorreo.Text = "Enviar PDF al correo";
            this.btnCorreo.Click += new System.EventHandler(this.btnCorreo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(81, 52);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetFactura2";
            reportDataSource1.Value = this.PA_REPORTE_FACTURA_PRODUCTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReporteFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 59);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 379);
            this.reportViewer1.TabIndex = 5;
            // 
            // PA_REPORTE_FACTURA_PRODUCTOSTableAdapter
            // 
            this.PA_REPORTE_FACTURA_PRODUCTOSTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmReporteFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteFactura";
            this.Load += new System.EventHandler(this.frmReporteFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_FACTURA_PRODUCTOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteFactura)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCorreo;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_FACTURA_PRODUCTOSBindingSource;
        private DataSetReporteFactura DataSetReporteFactura;
        private DataSetReporteFacturaTableAdapters.PA_REPORTE_FACTURA_PRODUCTOSTableAdapter PA_REPORTE_FACTURA_PRODUCTOSTableAdapter;
    }
}