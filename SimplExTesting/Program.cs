using System;
using System.Text;
using SimplExNetworking.Networking;
using SimplExNetworking.EventArguments;

namespace SimplExTesting
{
    static class Program
    {
        /*  /// <summary>
          /// Главная точка входа для приложения.
          /// </summary>
          [STAThread]
          static void Main()
          {
              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new Form1());
          }*/

        private static int attempt = 1;

        private static void Main()
        {
            Console.WriteLine("Нажмите Y чтобы стать сервером.");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                NetworkServer val = (NetworkServer)(object)new NetworkServer();
                val.OnClientDisconnected += Server_OnClientDisconnected;
                val.OnClientConnected += Server_OnClientConnected;
                val.OnServerInitialized += Server_OnServerInitialized;
                Console.WriteLine("Введите порт:");
                val.Port = int.Parse(Console.ReadLine());
                val.InitializeServer();
                do
                {
                    Console.WriteLine("Введите сообщение для рассылке всем клиентам: ");
                    val.BroadcastMessage(BroadcastMode.All, Encoding.Unicode.GetBytes(Console.ReadLine()));
                    Console.WriteLine("Нажммите Y чтобы прекратить рассылку:");
                }
                while (Console.ReadKey().Key != ConsoleKey.Y);
                Console.ReadKey();
            }
            else
            {
                NetworkClient val2 = (NetworkClient)(object)new NetworkClient();
                val2.OnConnectedToServer += Client_OnConnectedToServer;
                val2.OnFailedToConnect += Client_OnFailedToConnect1;
                val2.OnDisconnectedFromServer += Client_OnDisconnectedFromServer;
                val2.OnMessageRecieved += Client_OnMessageRecieved;
                Console.WriteLine("Введите ip адресс:");
                string ip = Console.ReadLine();
                Console.WriteLine("Введите порт:");
                int port = int.Parse(Console.ReadLine());
                val2.Connect(ip, port);
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        private static void Server_OnServerInitialized(object sender, EventArgs e)
        {
            Console.WriteLine("Сервер запущен!");
        }

        private static void Client_OnConnectedToServer(object sender, EventArgs e)
        {
            Console.WriteLine("Подключение к серверу установлено!");
        }

        private static void Client_OnFailedToConnect1(object sender, ReasonEventArgs e)
        {
            Console.WriteLine("Ошибка: " + e.Reason);
            Console.WriteLine("Попытка #" + (++attempt).ToString());
            ((NetworkClient)sender).Connect();
        }

        private static void Client_OnFailedToConnect(object sender, ReasonEventArgs e)
        {
            Console.WriteLine(e.Reason);
        }

        private static void Client_OnSettingsChanged(object sender, EventArgs e)
        {
            Console.WriteLine(((NetworkClient)sender).MaxConnections);
        }

        private static void Client_OnClientDisconnected(object sender, IdEventArgs e)
        {
            Console.WriteLine("Клиент отключился: " + e.Id.ToString());
        }

        private static void Client_OnMessageRecieved(object sender, MessageRecievedEventArgs e)
        {
            Console.WriteLine("\n" + Encoding.Unicode.GetString(e.Message));
        }

        private static void Client_OnDisconnectedFromServer(object sender, ReasonEventArgs e)
        {
            Console.WriteLine(e.Reason);
        }

        private static void Server_OnClientConnected(object sender, IdEventArgs e)
        {
            Console.WriteLine("Новое подключене: " + e.Id.ToString());
        }

        private static void Server_OnClientDisconnected(object sender, ConnectionEventArgs e)
        {
            Console.WriteLine(e.Id.ToString() + " " + e.Reason);
        }
    }
}
