namespace EsempioSoap_19112024.ServizioSOAP {
    public interface I_Calcolatrice {
        public int Somma(int a, int b);
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
