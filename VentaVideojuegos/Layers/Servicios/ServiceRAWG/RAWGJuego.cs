using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaVideojuegos
{
    /// <summary>
    /// Clase RAWGJuego que contiene las propiedades necesarias para almacenar la 
    /// informacion obtenida desde la API RAWG
    /// </summary>

    class RAWGJuego
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("released", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Released { get; set; }

        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        public double Rating { get; set; }
    }
}
