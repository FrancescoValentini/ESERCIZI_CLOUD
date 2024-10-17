using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerExampleModels.Models {
    
    public class TCPClient {
        public string IpAddr { get; }
        public Int32 Port { get; }

        private IPEndPoint ipEndp;
        private TcpClient client;



        public TCPClient(string ipAddr, Int32 port) {
            this.IpAddr = ipAddr;
            this.Port = port;
            this.ipEndp = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            this.client = new TcpClient();
        }

        public bool IsClientConnected() {
            return client.Connected;
        }

        public bool Connect() {
            try {
                client.Connect(ipEndp);
                return true;
            } catch (SocketException ex) {
                Console.WriteLine($"Errore durante la connessione: {ex.Message}");
                return false;
            }
        }

        public void Send(string message) {
            if (client.Connected) {
                try {
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                } catch (Exception ex) {
                    Console.WriteLine($"Errore durante l'invio del messaggio: {ex.Message}");
                }
            } else {
                Console.WriteLine("Client non connesso");
            }
        }

        public string Receive() {
            if (client.Connected) {
                try {
                    NetworkStream stream = client.GetStream();
                    byte[] data = new byte[256]; // Buffer for incoming data
                    int bytes = stream.Read(data, 0, data.Length);
                    return Encoding.UTF8.GetString(data, 0, bytes);
                } catch (Exception ex) {
                    Console.WriteLine($"Errore durante la ricezione del messaggio: {ex.Message}");
                    return string.Empty;
                }
            } else {
                Console.WriteLine("Client non connesso");
                return string.Empty;
            }
        }

        public void Disconnect() {
            if (client.Connected) {
                client.Close();
            }
        }

        public void Dispose() {
            Disconnect();
            client.Dispose();
        }
    }
}
