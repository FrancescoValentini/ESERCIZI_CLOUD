using ClientServerExampleModels.Models;

namespace ClientServerExample {
    class ClientServerExample {

        public static void Main(String[] args) {
            TCPClient client = SetupClient();

            client.Connect();
            while (client.IsClientConnected()) {
                Console.Write("> ");
                string datiDaInviare = Console.ReadLine();
                client.Send(datiDaInviare);
                string rx = client.Receive();
                Console.WriteLine("Ricevuto: {0}",rx);
            }
    

        }

        public static TCPClient SetupClient() {
            Console.Write("IP: ");
            string ip = Console.ReadLine();
            Console.Write("Port: ");
            Int32 port = Int32.Parse(Console.ReadLine());
            return new TCPClient(ip, port);
        }
    }
}