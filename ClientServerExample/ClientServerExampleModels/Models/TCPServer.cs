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

        private bool running = false;

        public TCPServer(string ip, int port) {
            this.ip = ip;
            this.port = port;

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
            try {
                while (running) {
                    // Accetta la connessione
                    TcpClient client = server.AcceptTcpClient();

                    Console.WriteLine("Nuova connessione");


                    // Stream per lettura / scrittura datti
                    NetworkStream stream = client.GetStream();

                    ProcessIncomingData(stream);


                }
            } catch (SocketException e) {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally { running = false; server.Stop(); }
        }
        

        private void ProcessIncomingData(NetworkStream stream) {
            int i = 0;
            byte[] buff = new byte[1024];
            string str;
            while ((i = stream.Read(buff, 0, buff.Length)) != 0) {
                // Conversione da byte in ascii
                str = System.Text.Encoding.ASCII.GetString(buff, 0, i);

                Console.Write("RX: {0}", str);

                // Processa i dati
                str = ReverseStr(str.Replace("\n",""));

                Console.Write("TX: {0}", str);
                WriteStringToStream(stream, str + "\n");
            }
        }

        private void WriteStringToStream(NetworkStream stream, string str) {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(str);
            stream.Write(msg, 0, msg.Length);
        }

        private static string ReverseStr(string s) {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
