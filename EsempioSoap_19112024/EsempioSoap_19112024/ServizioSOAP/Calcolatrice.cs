using System.ServiceModel;

namespace EsempioSoap_19112024.ServizioSOAP {
    [ServiceContract]
    public interface I_Calcolatrice {
        [OperationContract]
        public int Somma(int a, int b);
        [OperationContract]
        public int Sottrazione(int a, int b);
    }
    public class Calcolatrice : I_Calcolatrice {
        public int Somma(int a, int b) {
            return a + b;
        }

        public int Sottrazione(int a, int b) {
            return a - b;
        }
    }
}
