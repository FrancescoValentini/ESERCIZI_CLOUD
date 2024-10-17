using ClientServerExampleModels.Models;

namespace Server {
    class Server {
        public static void Main(String[] args) {
            Console.Write("IP Su cui ascoltare: ");
            string ip = Console.ReadLine();

            Console.Write("Porta: ");
            Int32 port = Int32.Parse(Console.ReadLine());

            TCPServer srv = new TCPServer(ip, port);
            srv.StartServer();
        }
    }
}