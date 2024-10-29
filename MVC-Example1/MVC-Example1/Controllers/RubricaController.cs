using Microsoft.AspNetCore.Mvc;
using MVC_Example1.Models;

namespace MVC_Example1.Controllers {
    public class RubricaController : Controller {
        private static Rubrica rubrica = new Rubrica("Rubrica Personale");
        // Metodo Index per visualizzare la lista di contatti
        public IActionResult Index() {
            return View(rubrica);
        }


        // Metodo per mostrare il form di aggiunta contatto
        public IActionResult FormContatto() {
            return View();
        }

        // Metodo per aggiungere un nuovo contatto
        [HttpPost]
        public IActionResult AddPersona(Persona persona) {
            try {
                rubrica.AddPersona(persona);
                return RedirectToAction("Index");
            } catch (Exception ex) {
                // Gestione errore (persona già presente)
                ViewBag.ErrorMessage = ex.Message;
                return View("FormContatto");
            }
        }

        // Metodo per modificare un nuovo contatto
        [HttpPost]
        public IActionResult UpdatePersona(String telefono,Persona p) {
            try {
                rubrica.UpdatePersona(telefono, p);
                return RedirectToAction("Index");
            } catch (Exception ex) {
                // Gestione errore (persona già presente)
                ViewBag.ErrorMessage = ex.Message;
                return View("FormContatto");
            }
        }


        // Metodo per cancellare un contatto (passa il telefono come identificatore)
        public IActionResult DeletePersona(string telefono) {
            try {
                rubrica.DeletePersona(telefono);
            } catch (Exception ex) {
                // Messaggio di errore se la persona non esiste
                ViewBag.ErrorMessage = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
