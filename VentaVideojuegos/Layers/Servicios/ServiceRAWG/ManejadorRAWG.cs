using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VentaVideojuegos;

namespace VentaVideojuegos
{
    static class ManejadorRAWG
    {
        public const string BaseUrl = "https://rawg.io/api";

        public static string CrearURL (string nombre, string rawgkey)
        {
            string nombreJuego= nombre.ToLower();

            if (nombreJuego.Contains(' '))
            {
                nombreJuego = nombreJuego.Replace(" ", "-");
            }

            string URL = $"{BaseUrl}/games/{nombreJuego}";

            URL += $"?search_precise=false&search_exact=false&key={rawgkey}";

            return URL ;
        }

        public static async Task<T> Consulta<T> (string nombre, string rawgkey)
        {
            string URL= CrearURL(nombre, rawgkey);

            string respuesta = "";

            using (HttpClient Client = new HttpClient())
            {
                Task<HttpResponseMessage> RespuestaTask = Client.GetAsync(URL);
                RespuestaTask.Wait();

                respuesta= await RespuestaTask.Result.Content.ReadAsStringAsync();
            }
            return DeserializeJsonToObject<T>(respuesta);
        }

        public static async Task<RAWGJuego> RespuestaRAWG (string nombre, string rawgkey)
        {
            RAWGJuego juegoConsulta= await Consulta<RAWGJuego>(nombre, rawgkey);

            return juegoConsulta;
        }

        public static T DeserializeJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
