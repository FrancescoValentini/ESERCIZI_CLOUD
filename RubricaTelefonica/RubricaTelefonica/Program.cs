using RubricaTelefonica.Models.Models;

namespace RubricaTelefonica {
    public class RubricaTelefonica {
        private static Rubrica rubr;
        public static void Main(String[] args) {
            if(rubr == null) {
                rubr = new Rubrica(MenuPrimoAvvio());
            }
        }

        private static string MenuPrimoAvvio() {
            return ReadString("Specificare il nome della rubrica:");
        }

        private static string Menu() {
            Console.WriteLine("A) Aggiungi contatto");
            Console.WriteLine("R) Ricerca contatto");
            Console.WriteLine("E) Elimina contatto");
            Console.WriteLine("S) Stampa rubrica");
            Console.WriteLine("");

            return ReadString(rubr.nome + "> ");
        }


        private static string ReadString(string prompt) {
            string s = "";
            do {
                Console.Write(prompt);
                s = Console.ReadLine();
            } while (s != "");

            return s;
        }

    }
}