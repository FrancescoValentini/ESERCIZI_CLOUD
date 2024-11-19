using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bologna.Modelli {

    public class LocaleBologna {
        public string Categoria { get; set; }
        public string Demonimazione { get; set; }

        [JsonProperty("Indirizzo internet della scheda")]
        public string Indirizzointernetdellascheda { get; set; }
        public string Descrizione { get; set; }
        public string Indirizzo { get; set; }

        [JsonProperty("Indirizzo internet immagine")]
        public string Indirizzointernetimmagine { get; set; }
        public string Latitudine { get; set; }
        public string Longitudine { get; set; }
    }
}
