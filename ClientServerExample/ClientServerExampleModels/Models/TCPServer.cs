using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerExampleModels.Models {
    
    public class TCPServer {
        private TcpListener server = null;
        public string ip { get; }
        public Int32 port { get; }

        private IPAddress ipAddr;

        private Byte[] data;

        private string strData = null;

        private bool running = false;

        public TCPServer(string ip, int port) {
            this.ip = ip;
            this.port = port;
            this.data = new Byte[1024];

            ipAddr = IPAddress.Parse(ip);
            server = new TcpListener(ipAddr, port);
        }

        public void StartServer() {
            server.Start();
            running = true;
            listener();
        }
        public void StopServer() {
            server.Stop();
            running = false;
        }

        private void listener() {
            int i = 0;
            try {
                while (running) {
                    // Accetta la connessione
                    TcpClient client = server.AcceptTcpClient();

                    Console.WriteLine("Nuova connessione");

                    strData = null;

                    // Stream per lettura / scrittura datti
                    NetworkStream stream = client.GetStream();

                    while ((i = stream.Read(data, 0, data.Length)) != 0) {
                        // Conversione da byte in ascii
                        strData = System.Text.Encoding.ASCII.GetString(data, 0, i);
                        Console.Write("RX: {0}", strData);

                        // Processa i dati
                        strData = ReverseStr(strData);

                        // Converte da ascii a bytes grezzi
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(strData + "\n");

                        // invia i dati
                        stream.Write(msg, 0, msg.Length);

                        Console.Write("TX: {0}", strData);
                    }
                }
            } catch (SocketException e) {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally { running = false; server.Stop(); }
        }
        



        private static string ReverseStr(string s) {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
