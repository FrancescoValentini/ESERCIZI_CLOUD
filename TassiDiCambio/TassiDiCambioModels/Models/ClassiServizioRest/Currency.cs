using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TassiDiCambioModels.Models.ClassiServizioRest {
    public class Currency {
        [JsonPropertyName("isoCode")]
        public string IsoCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("graph")]
        public bool Graph { get; set; }

        [JsonPropertyName("countries")]
        public List<Country> Countries { get; set; }
    }
}
