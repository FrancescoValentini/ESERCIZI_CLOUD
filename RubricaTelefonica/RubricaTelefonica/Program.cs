using RubricaTelefonica.Models.Models;

namespace RubricaTelefonica {
    public class RubricaTelefonica {
        private static Rubrica rubr;
        public static void Main(String[] args) {
            if(rubr == null) {
                rubr = new Rubrica(MenuPrimoAvvio());
            }
            string sc = "";

            do {
                sc = Menu();
                switch (sc) {
                    case "A":
                        rubr.AddPersona(BuildPersona()); 
                        break;
                    case "R":
                        Persona p = rubr.FindPersona(
                                ReadString("Telefono: ")
                        );
                        if(p != null) {
                            Console.WriteLine(p);
                        } else {
                            Console.WriteLine("Persona non trovata");
                        }
                        break;
                    case "E":
                        rubr.DeletePersona(ReadString("Telefono: "));
                        break;
                    case "S":
                        Console.WriteLine(rubr.getPrintableString());
                        break;

                }
            } while (sc != "Q");
        }

        private static Persona BuildPersona() {
            string nome = ReadString("Nome: ");
            string cogn = ReadString("Cognome: ");
            string tele = ReadString("Telefono: ");
            return new Persona(nome, cogn, tele);
        }

        private static string MenuPrimoAvvio() {
            return ReadString("Specificare il nome della rubrica: ");
        }

        private static string Menu() {
            Console.WriteLine("A) Aggiungi contatto");
            Console.WriteLine("R) Ricerca contatto");
            Console.WriteLine("E) Elimina contatto");
            Console.WriteLine("S) Stampa rubrica");
            Console.WriteLine("Q) Esci");
            Console.WriteLine("");

            return ReadString(rubr.nome + "> ").ToUpper();
        }


        private static string ReadString(string prompt) {
            string s = "";
            do {
                Console.Write(prompt);
                s = Console.ReadLine();
            } while (s == "");

            return s;
        }

    }
}