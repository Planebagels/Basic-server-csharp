using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

/// <summary>
/// this class houses all of the server logic
/// </summary>
namespace Network_
{
    class Server
    {

        public static int MaxPlayers { get; private set; }
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();
        public static int Port { get; private set; }

        private static TcpListener tcpL;

        public static void Start(int _MaxPlayers, int _port)
        {
            MaxPlayers = _MaxPlayers;
            Port = _port;

            Console.WriteLine("Starting server, please wait...");
            InitServerData();

            tcpL = new TcpListener(IPAddress.Any, Port);
            tcpL.Start();
            tcpL.BeginAcceptTcpClient(new AsyncCallback(ConnectCallback), null);

            Console.WriteLine($"Server started on {Port}, ");

            

        }

        private static void ConnectCallback(IAsyncResult _result)
        {
            TcpClient _client = tcpL.EndAcceptTcpClient(_result);
            tcpL.BeginAcceptTcpClient(new AsyncCallback(ConnectCallback), null);

            Console.WriteLine($"CONNECTION FROM {_client.Client.RemoteEndPoint}");

            for (int x = 1; x <= MaxPlayers; x++)
            {
                if (clients[1].tcp.socket == null)
                { clients[1].tcp.Connect(_client);  };
                return;
                
            }

            Console.WriteLine($"{_client.Client.RemoteEndPoint} failed to connect to server because the server is full, Error code: SF");


            
        }
        public static void InitServerData()
        {
            for (int i = 1;  i <= MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }
        }
    }
}
