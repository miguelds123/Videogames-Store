﻿
namespace VentaVideojuegos.Layers.UI.Reportes
{
    partial class frmReporteVideojuegoAll
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
            this.DataSetReporteVideojuegoAll = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteVideojuegoAll();
            this.PA_REPORTE_VIDEOJUEGO_ALLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PA_REPORTE_VIDEOJUEGO_ALLTableAdapter = new VentaVideojuegos.Layers.UI.Reportes.DataSetReporteVideojuegoAllTableAdapters.PA_REPORTE_VIDEOJUEGO_ALLTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteVideojuegoAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_VIDEOJUEGO_ALLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetVideojuegoAll1";
            reportDataSource1.Value = this.PA_REPORTE_VIDEOJUEGO_ALLBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentaVideojuegos.Layers.UI.Reportes.ReportVideojuegoAll.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(775, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetReporteVideojuegoAll
            // 
            this.DataSetReporteVideojuegoAll.DataSetName = "DataSetReporteVideojuegoAll";
            this.DataSetReporteVideojuegoAll.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PA_REPORTE_VIDEOJUEGO_ALLBindingSource
            // 
            this.PA_REPORTE_VIDEOJUEGO_ALLBindingSource.DataMember = "PA_REPORTE_VIDEOJUEGO_ALL";
            this.PA_REPORTE_VIDEOJUEGO_ALLBindingSource.DataSource = this.DataSetReporteVideojuegoAll;
            // 
            // PA_REPORTE_VIDEOJUEGO_ALLTableAdapter
            // 
            this.PA_REPORTE_VIDEOJUEGO_ALLTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteVideojuegoAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteVideojuegoAll";
            this.Text = "frmReporteVideojuegoAll";
            this.Load += new System.EventHandler(this.frmReporteVideojuegoAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteVideojuegoAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PA_REPORTE_VIDEOJUEGO_ALLBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PA_REPORTE_VIDEOJUEGO_ALLBindingSource;
        private DataSetReporteVideojuegoAll DataSetReporteVideojuegoAll;
        private DataSetReporteVideojuegoAllTableAdapters.PA_REPORTE_VIDEOJUEGO_ALLTableAdapter PA_REPORTE_VIDEOJUEGO_ALLTableAdapter;
    }
}