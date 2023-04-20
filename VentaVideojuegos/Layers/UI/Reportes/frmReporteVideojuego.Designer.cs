
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteVideojuego
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetReporteVideojuego = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteVideojuego();
            this.PA_REPORTE_VIDEOJUEGOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PA_REPORTE_VIDEOJUEGOTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteVideojuegoTableAdapters.PA_REPORTE_VIDEOJUEGOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteVideojuego)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_VIDEOJUEGOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetReporteVideojuego";
            reportDataSource1.Value = this.PA_REPORTE_VIDEOJUEGOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportVideojuego.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetReporteVideojuego
            // 
            this.DataSetReporteVideojuego.DataSetName = "DataSetReporteVideojuego";
            this.DataSetReporteVideojuego.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PA_REPORTE_VIDEOJUEGOBindingSource
            // 
            this.PA_REPORTE_VIDEOJUEGOBindingSource.DataMember = "PA_REPORTE_VIDEOJUEGO";
            this.PA_REPORTE_VIDEOJUEGOBindingSource.DataSource = this.DataSetReporteVideojuego;
            // 
            // PA_REPORTE_VIDEOJUEGOTableAdapter
            // 
            this.PA_REPORTE_VIDEOJUEGOTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteVideojuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteVideojuego";
            this.Text = "frmReporteVideojuego";
            this.Load += new System.EventHandler(this.frmReporteVideojuego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteVideojuego)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_VIDEOJUEGOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_VIDEOJUEGOBindingSource;
        private DataSetReporteVideojuego DataSetReporteVideojuego;
        private DataSetReporteVideojuegoTableAdapters.PA_REPORTE_VIDEOJUEGOTableAdapter PA_REPORTE_VIDEOJUEGOTableAdapter;
    }
}