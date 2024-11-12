using Microsoft.AspNetCore.Mvc;
using MVC_ComuniItaliani.ViewModels;
using FunzioniISTAT;
using FunzioniISTAT.Modelli;


namespace MVC_ComuniItaliani.Controllers {
    public class ComuniController : Controller {
        public IActionResult Index() {
            ComuniISTATElencoComuniViewModel vm = new ComuniISTATElencoComuniViewModel();

            Comune[] elencoComuni = FunzioniInterrogazioneISTAT.getElencoComuni();
            vm.ElencoComuni = elencoComuni;
            return View(vm);
        }


    }
}
