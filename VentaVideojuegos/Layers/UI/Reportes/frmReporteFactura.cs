using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaVideojuegos.Layers.UI.Reportes
{
    public partial class frmReporteFactura : Form
    {
        private int numFactura;
        Usuario _Usuario = new Usuario();

        public frmReporteFactura(int pNumeroFactura)
        {
            InitializeComponent();
            numFactura = pNumeroFactura;
            _Usuario.Login = "sa";
            _Usuario.Password = "123456";
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetReporteFactura.PA_REPORTE_FACTURA_PRODUCTOS' table. You can move, or remove it, as needed.
            this.PA_REPORTE_FACTURA_PRODUCTOSTableAdapter.Fill(this.DataSetReporteFactura.PA_REPORTE_FACTURA_PRODUCTOS, numFactura);
            this.reportViewer1.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            string ruta = @"c:\temp\reporte.pdf";
            try
            {
                if (!Directory.Exists(@"c:\temp"))
                    Directory.CreateDirectory(@"c:\temp");

                byte[] Bytes = this.reportViewer1.LocalReport.Render(format: "PDF", deviceInfo: "");

                using (FileStream stream = new FileStream(ruta, FileMode.Create))
                {
                    stream.Write(Bytes, 0, Bytes.Length);
                }

                Process.Start(ruta);

                String CuentaCorreoElectronico = "mdsantamaria02@gmail.com";
                String ContrasenaGeneradaGmail = "wglcnnjyegilimtq";
                MailMessage mensaje = new MailMessage();
                mensaje.IsBodyHtml = true;
                mensaje.Subject = "Gracias por su compra";
                mensaje.Body = "Muchas gracias por su compra, aqui tiene el pdf de su factura";
                mensaje.From = new MailAddress(CuentaCorreoElectronico);
                mensaje.To.Add("michiassasin@gmail.com"); //Correo del destinatario
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(CuentaCorreoElectronico,
                ContrasenaGeneradaGmail);
                smtp.EnableSsl = true;
                Attachment attachment = new Attachment(@"c:\temp\reporte.pdf");
                mensaje.Attachments.Add(attachment);
                smtp.Send(mensaje);

                MessageBox.Show("La factura a sido enviada a su correo");

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ocurrio un error al ejecutar la instruccion en la base" +
                    " de datos");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en el programa");
                return;
            }
        }
    }
}
