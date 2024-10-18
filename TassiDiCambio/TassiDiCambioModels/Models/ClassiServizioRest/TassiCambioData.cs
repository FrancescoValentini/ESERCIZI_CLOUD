using System.Text.Json.Serialization;

namespace TassiDiCambioModels.Models.ClassiServizioRest {
    public class TassiCambioData {
        [JsonPropertyName("resultsInfo")]
        public ResultsInfo ResultsInfo { get; set; }

        [JsonPropertyName("currencies")]
        public List<Currency> Currencies { get; set; }

    }
}