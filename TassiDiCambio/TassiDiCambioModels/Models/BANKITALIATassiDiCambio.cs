using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TassiDiCambioModels.Models.ClassiServizioRest;

namespace TassiDiCambioModels.Models
{
    public class BANKITALIATassiDiCambio {
        private string apiURL;
        private TassiCambioData tassiCambio;

        // Costruttore che prende l'URL come parametro
        public BANKITALIATassiDiCambio(string url) {
            apiURL = url;
        }

        public void DoRESTrequest() {
            using (HttpClient client = new HttpClient()) {
                try {
                    // Esegue una richiesta GET all'API e ottiene la risposta JSON
                    HttpResponseMessage response = client.GetAsync(apiURL).Result;
                    response.EnsureSuccessStatusCode();
                    string json = response.Content.ReadAsStringAsync().Result;

                    // Deserializza il JSON in un oggetto TassiCambioData
                    tassiCambio = JsonSerializer.Deserialize<TassiCambioData>(json);
                } catch (Exception ex) {
                    Console.WriteLine($"Errore durante il download: {ex.Message}");
                } 
            }
        }

        public TassiCambioData GetTassiCambio() {
            return tassiCambio;
        }

        public List<Currency> GetCurrencies() {
            return tassiCambio.Currencies;
        }

        public Currency GetCurrency(int position) {
            return tassiCambio.Currencies.ElementAt<Currency>(position);
        }


        // Metodo per ottenere una valuta cercando per codice ISO
        public Currency GetCurrencyByIsoCode(string isoCode) {
            if (tassiCambio != null && tassiCambio.Currencies != null) {
                foreach (Currency currency in tassiCambio.Currencies) {
                    if (currency.IsoCode.Equals(isoCode, StringComparison.OrdinalIgnoreCase)) {
                        return currency; // Restituisci la valuta appena trovi la corrispondenza
                    }
                }
            }
            return null;
        }

        // Metodo per ottenere una valuta cercando per nome del paese
        public Currency GetCurrencyByCountryName(string countryName) {
            foreach (Currency currency in tassiCambio.Currencies) {
                foreach (var country in currency.Countries) {
                    if (country.StrCountry.Equals(countryName, StringComparison.OrdinalIgnoreCase)) {
                        return currency; // Restituisci la valuta appena trovi il paese corrispondente
                    }
                }
            }
            return null;
        }

        // Metodo per ottenere tutti i codici ISO dei paesi
        public List<string> GetAllCountriesIso() {
            if (tassiCambio != null && tassiCambio.Currencies != null) {
                return tassiCambio.Currencies
                    .SelectMany(currency => currency.Countries)
                    .Where(country => !string.IsNullOrEmpty(country.CountryISO))
                    .Select(country => country.CountryISO)
                    .Distinct()
                    .ToList();
            }
            return new List<string>();
        }

        // Metodo per ottenere tutti i nomi dei paesi
        public List<string> GetAllCountriesNames() {
            if (tassiCambio != null && tassiCambio.Currencies != null) {
                return tassiCambio.Currencies
                    .SelectMany(currency => currency.Countries)
                    .Select(country => country.StrCountry)
                    .Distinct()
                    .ToList();
            }
            return new List<string>();
        }
    }
}
