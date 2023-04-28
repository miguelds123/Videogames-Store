using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos.Layers.Entities
{
    /// <summary>
    /// Clase Encriptado que contiene los metodos necesarios para encriptar las contraseñas
    /// de los usuarios
    /// </summary>

    static class Encriptado
    {
        /// <summary>
        /// Metodo que recibe un string y lo retorna encriptado en SHA256 
        /// </summary>
        /// <param name="str">valor a encriptar</param>
        /// <returns>String encriptado en SHA256</returns>

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
