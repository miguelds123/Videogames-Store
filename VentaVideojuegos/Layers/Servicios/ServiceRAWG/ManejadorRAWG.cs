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
    /// <summary>
    /// Clase Manejador que los metodos necesario para retornar la informacion de un 
    /// videojuego contenida en la API RAWG
    /// </summary>

    static class ManejadorRAWG
    {
        public const string BaseUrl = "https://rawg.io/api";

        /// <summary>
        /// Método que crea el URL necesario para realizar la consulta en el API RAWG  
        /// </summary>
        /// <param name="nombre">nombre del videojuego a consultar</param>
        /// <param name="rawgkey">key necesaria para hacer la consulta en el API RAWG</param>
        /// <returns>Un string que contiene el URL necesario para hacer la consulta</returns>

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

        /// <summary>
        /// Método realiza la consulta al API RAWG y devuelve la informacion deserealizada  
        /// </summary>
        /// <param name="nombre">nombre del videojuego a consultar</param>
        /// <param name="rawgkey">key necesaria para hacer la consulta en el API RAWG</param>
        /// <returns>La informacion deserealizada</returns>

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

        /// <summary>
        /// Método que toma la informacion desearilzada y la almacena en una clase que 
        /// posteriormente es retornada
        /// </summary>
        /// <param name="nombre">nombre del videojuego a consultar</param>
        /// <param name="rawgkey">key necesaria para hacer la consulta en el API RAWG</param>
        /// <returns>Una instacia de la clase RAWGJuego que contiene la informacion 
        /// obtenida de la API</returns>

        public static RAWGJuego RespuestaRAWGObjecto(string nombre, string rawgkey)
        {
            Task<RAWGJuego> task= Consulta<RAWGJuego>(nombre, rawgkey);

            RAWGJuego rawgJuego= new RAWGJuego();

            rawgJuego.Name= task.Result.Name;
            rawgJuego.Description= task.Result.Description;
            rawgJuego.Rating= task.Result.Rating;
            rawgJuego.Released= task.Result.Released;

            return rawgJuego;
        }

        /// <summary>
        /// Método que deserealiza Json a Objetos  
        /// </summary>
        /// <param name="json">string que contiene el json que se va a deserealizar</param>
        /// <returns>Un json deserealizado</returns>

        public static T DeserializeJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
