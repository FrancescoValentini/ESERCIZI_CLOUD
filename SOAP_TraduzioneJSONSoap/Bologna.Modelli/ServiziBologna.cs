
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Bologna.Modelli {
    public class ServiziBologna {
        public static async Task<LocaleBologna[]> GetLocaliAsync() {
            string url = "http://www.datiopen.it/export/json/Comune-di-Bologna---Musei-gallerie-luoghi-e-teatri-storici.json";
            HttpClient client = new HttpClient();
                                    // Esegue una richiesta GET all'API e ottiene la risposta JSON
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            // Deserializza il JSON in un oggetto TassiCambioData
            LocaleBologna[] locale = JsonConvert.DeserializeObject<LocaleBologna[]>(json);
            return locale;

        }
    }
}
