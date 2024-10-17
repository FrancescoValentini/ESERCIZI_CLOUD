using ClientServerExampleModels.Models;

namespace ClientServerExample {
    class ClientServerExample {

        public static void Main(String[] args) {
            TCPServer srv = new TCPServer("127.0.0.1", 2323);
            srv.StartServer();
        }
    }
}