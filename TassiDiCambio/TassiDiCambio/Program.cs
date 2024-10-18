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

            string sc = "";
            do {
                sc = Menu().ToUpper();
                switch (sc) {
                    case "V":
                        tassiCambio.GetAllCurrenciesIso().ForEach(s => Console.WriteLine(s));
                        break;
                    case "C":
                        Currency c = tassiCambio.GetCurrencyByIsoCode(ReadString("ISO CODE: "));
                        Console.WriteLine(c == null ? "Valuta non trovata" : tassiCambio.GetCurrencyByIsoCode("ADP").Name);
                        break;
                    case "S":
                        tassiCambio.GetAllCountriesNames().ForEach(s =>  Console.WriteLine(s));
                        break;
                }
            } while (sc != "Q");
        }

        private static string Menu() {
            Console.WriteLine("V) Visualizza tutti i codici delle valute");
            Console.WriteLine("C) Ricerca valuta mediante codice ISO");
            Console.WriteLine("S) Visualizza tutte le nazioni presenti");
            Console.WriteLine("");
            return ReadString("> ");
        }

        private static string ReadString(string prompt) {
            string str = "";
            do {
                Console.Write(prompt);
                str = Console.ReadLine();
            }while(str == "");
            return str;
        }
    }
}