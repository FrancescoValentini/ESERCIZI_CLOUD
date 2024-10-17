using ClientServerExampleModels.Models;

namespace Server {
    class Server {
        public static void main(String[] args) {
            TCPServer srv = new TCPServer("127.0.0.1", 2323);
            srv.StartServer();
        }
    }
}