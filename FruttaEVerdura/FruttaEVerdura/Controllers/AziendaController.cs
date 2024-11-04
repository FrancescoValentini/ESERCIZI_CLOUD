using FruttaEVerdura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruttaEVerdura.Controllers {

	[Route("api/azienda")] // Route principale es: http://localhost:5005/api/azienda
	[ApiController]

	public class AziendaController : ControllerBase {
		[HttpGet]
		public IEnumerable<Azienda> ListaAziende() {
			// Simula dei dati in un database
			IList<Azienda> lista = new List<Azienda>();

			lista.Add(new Azienda() { // Inserisce la prima azienda
				Id = 1,
				Nome = "Apple"
			});

			lista.Add(new Azienda() { // Inserisce la seconda azienda
				Id = 2,
				Nome = "Microsoft"
			});

			return lista;
		}
		// id è il parametro specificato nella url della richiesta get
		// es: http://localhost:5005/api/azienda/1
		[HttpGet("{id}")] 
		public IActionResult DettaglioAzienda(int id) {
			// Simula una ricerca per id

			if(id > 2) { // simula il caso dove il prodotto non è stato trovato nel db
				return NotFound(); // Restituisce 404 Not Found
			}


			AziendaDetails azienda = new AziendaDetails() {
				Id = id,
				Nome = "Microsoft",
				Descrizione = "Azienda Microsoft"
			};

			return Ok(azienda);
		}
	}
}
