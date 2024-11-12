using FunzioniISTAT.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunzioniISTAT {
    public class FunzioniInterrogazioneISTAT {
        public static async Task<Comune[]> getElencoComuni() {
            string Url = "https://www.istat.it/storage/codici-unita-amministrative/Elenco-comuni-italiani.csv";

            string[] righeCSV = PerformHTTPGet(Url).Result.Split('\n');

            List<Comune> listaComuni = new List<Comune>();

            for (int i = 3; i < righeCSV.Length - 1; i++) {
                listaComuni.Add(GetComune(righeCSV[i]));
            }

            return listaComuni.ToArray();
        }
        /**
         * Metodo per effettuare la richiesta GET HTTP ed ottenere il body
         * come stringa
         * 
         */
        private static async Task<string> PerformHTTPGet(string url) {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }

        /**
         * Metodo che prende come parametro di ingresso una riga CSV e restituisce
         * l'oggetto Comune
         */
        private static Comune GetComune(string csvRow) {
            return new Comune {
                CodiceCatastaleComune = csvRow.Split(';')[19],
                DenominazioneItaliano = csvRow.Split(';')[6],
                RipartizioneGeografica = csvRow.Split(';')[9],
                DenominazioneRegione = csvRow.Split(';')[10],
                DenominazioneUnitaSovracomunale = csvRow.Split(';')[11]
            };
        }
    }
}
