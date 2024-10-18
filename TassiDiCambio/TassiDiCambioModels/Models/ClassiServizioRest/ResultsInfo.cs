using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TassiDiCambioModels.Models.ClassiServizioRest {
    public class ResultsInfo {
        [JsonPropertyName("totalRecords")]
        public int TotalRecords { get; set; }

        [JsonPropertyName("timezoneReference")]
        public string TimezoneReference { get; set; }
    }
}
