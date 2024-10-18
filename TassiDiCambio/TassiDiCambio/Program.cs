

using TassiDiCambioModels.Models;
using TassiDiCambioModels.Models.ClassiServizioRest;

namespace TassiDiCambio
{
    public class TassiDiCambio {
        public static void Main(string[] args) {
            // URL dell'API della Banca d'Italia (simulato in questo esempio)
            string url = "http://127.0.0.1/tassi.json";

            // Inizializza l'oggetto per gestire i tassi di cambio
            BANKITALIATassiDiCambio tassiCambio = new BANKITALIATassiDiCambio(url);
            tassiCambio.DoRESTrequest();
            // Ottieni i tassi di cambio
            TassiCambioData dati = tassiCambio.GetTassiCambio();

            // Stampa alcune informazioni di esempio
            Console.WriteLine($"Totale record: {dati.ResultsInfo.TotalRecords}");
            Console.WriteLine($"Prima valuta: {dati.Currencies[0].Name}, Paese: {dati.Currencies[0].Countries[0].StrCountry}");

            Console.WriteLine("ISO CODE ADP");
            Currency c = tassiCambio.GetCurrencyByIsoCode("ADP");
            Console.WriteLine(c.Name);

            Console.WriteLine("COUNTRY NAME ANDORRA");
            Currency c1 = tassiCambio.GetCurrencyByCountryName("ANDORRA");
            Console.WriteLine(c1.Name);

            Console.WriteLine("Tutti gli iso");
            List<string> a = tassiCambio.GetAllCurrenciesIso();
            foreach (string code in a) {
                Console.WriteLine($"{code}");
            }


            Console.WriteLine("Tutti Country");
            List<string> a1 = tassiCambio.GetAllCountriesNames();
            foreach (string code in a1) {
                Console.WriteLine($"{code}");
            }
        }
    }
}