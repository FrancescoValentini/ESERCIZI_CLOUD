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

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url);
            string content = await response.Content.ReadAsStringAsync();

            string[] righeCSV = content.Split('\n');

            List<Comune> listaComuni = new List<Comune>();

            for (int i = 3; i < righeCSV.Length - 1; i++) {
                listaComuni.Add(new Comune {
                    CodiceCatastaleComune = righeCSV[i].Split(';')[19],
                    DenominazioneItaliano = righeCSV[i].Split(';')[6],
                    RipartizioneGeografica = righeCSV[i].Split(';')[9],
                    DenominazioneRegione = righeCSV[i].Split(';')[10],
                    DenominazioneUnitaSovracomunale = righeCSV[i].Split(';')[11]
                });
            }

            return listaComuni.ToArray();
        }
    }
}
