using Bologna.Modelli;
using System.ServiceModel;

namespace SOAP_TraduzioneJSONSoap.WSSoap {
    [ServiceContract]
    public interface IServizioStoricoBologna {
        [OperationContract]
        public LocaleBologna[] getAllLocaliStorici();
        [OperationContract]
        public LocaleBologna[] ricercaLocaliStorici(String ricerca);
    }
    public class ServizioStoricoBologna : IServizioStoricoBologna {
        public LocaleBologna[] getAllLocaliStorici() {
            return ServiziBologna.GetLocaliAsync().Result;
        }

        public LocaleBologna[] ricercaLocaliStorici(string ricerca) {
            return ServiziBologna.RicercaLocali(ricerca).Result;
        }
    }
}
