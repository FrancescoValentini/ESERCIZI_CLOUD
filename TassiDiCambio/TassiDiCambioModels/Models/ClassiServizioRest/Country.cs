using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TassiDiCambioModels.Models.ClassiServizioRest {
    public class Country {
        [JsonPropertyName("currencyISO")]
        public string CurrencyISO { get; set; }

        [JsonPropertyName("country")]
        public string StrCountry { get; set; }

        [JsonPropertyName("countryISO")]
        public string CountryISO { get; set; }

        [JsonPropertyName("validityStartDate")]
        public string ValidityStartDate { get; set; }

        [JsonPropertyName("validityEndDate")]
        public string ValidityEndDate { get; set; }
    }
}
