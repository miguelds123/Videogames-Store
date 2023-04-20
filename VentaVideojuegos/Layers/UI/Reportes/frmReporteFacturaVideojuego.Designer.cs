
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteFacturaVideojuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteFacturaVideojuego));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteFacturaVideojuego = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteFacturaVideojuego();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCorreo = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PA_REPORTE_FACTURA_VIDEOJUEGOTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteFacturaVideojuegoTableAdapters.PA_REPORTE_FACTURA_VIDEOJUEGOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteFacturaVideojuego)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource
            // 
            this.PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource.DataMember = "PA_REPORTE_FACTURA_VIDEOJUEGO";
            this.PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource.DataSource = this.DataSetReporteFacturaVideojuego;
            // 
            // DataSetReporteFacturaVideojuego
            // 
            this.DataSetReporteFacturaVideojuego.DataSetName = "DataSetReporteFacturaVideojuego";
            this.DataSetReporteFacturaVideojuego.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCorreo,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 55);
            this.toolStrip1.TabIndex = 5;
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
            reportDataSource1.Name = "DataSetReporteFacturaVideojuego";
            reportDataSource1.Value = this.PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportFacturaVideojuego.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 59);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 379);
            this.reportViewer1.TabIndex = 6;
            // 
            // PA_REPORTE_FACTURA_VIDEOJUEGOTableAdapter
            // 
            this.PA_REPORTE_FACTURA_VIDEOJUEGOTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteFacturaVideojuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmReporteFacturaVideojuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteFacturaProducto";
            this.Load += new System.EventHandler(this.frmReporteFacturaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteFacturaVideojuego)).EndInit();
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
        private System.Windows.Forms.BindingSource PA_REPORTE_FACTURA_VIDEOJUEGOBindingSource;
        private DataSetReporteFacturaVideojuego DataSetReporteFacturaVideojuego;
        private DataSetReporteFacturaVideojuegoTableAdapters.PA_REPORTE_FACTURA_VIDEOJUEGOTableAdapter PA_REPORTE_FACTURA_VIDEOJUEGOTableAdapter;
    }
}