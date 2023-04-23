using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase QR que contiene todos los metodos necesarios para generar un QR
    /// </summary>

    class QR
    {
        /// <summary>
        /// Método que retorna una imagen QR
        /// </summary>
        /// <param name="input">informacion que va estar contenida en el QR</param>
        /// <param name="qrlevel">tamaño de la imagen QR</param>
        /// <returns>Imagen QR</returns>

        public static Image QuickResponseGenerador(string input, int qrlevel)
        {

            string toenc = input;

            MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();

            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;

            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L; // - Using LOW for more storage

            qe.QRCodeVersion = qrlevel;

            System.Drawing.Bitmap bm = qe.Encode(toenc);

            return bm;

        }
    }
}
