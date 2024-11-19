using Bologna.Modelli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProgettoApi.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]

   
    public class TestController : ControllerBase {
        [HttpGet]
        public int somma(int a, int b) {
            return a + b;
        }
        [HttpGet]
        public LocaleBologna[] getLocali() {
            return ServiziBologna.GetLocaliAsync().Result;
        }

        [HttpGet]
        public LocaleBologna[] ricercaLocali(String nome) {
            return ServiziBologna.RicercaLocali(nome).Result;
        }
    }
}
