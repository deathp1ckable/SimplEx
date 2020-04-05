using SimplExServer.Model;
using SimplExNetworking.Networking;
using SimplExNetworking.EventArguments;
using System;
using System.Collections.Generic;

namespace SimplExServer.Services
{
    class SessionService
    {
        private Dictionary<uint, ClientService> ConnectedClients = new Dictionary<uint, ClientService>();
        private NetworkServer networkServer;
        public string GroupName { get; private set; }
        public bool TrackStatusCheck { get; private set; }
        public bool SaveResults { get; private set; }
        public bool MixAnswers { get; private set; }
        public bool EnableChat { get; private set; }
        public bool WaitForReconnection { get; private set; }
        public int ReconnectionTime { get; private set; }
        public bool TrackViolations { get; private set; }
        public int ViolationsLimit { get; private set; }
        public IExamSaver ExamSaver { get; private set; }
        public Exam Exam { get; private set; }
        public void OpenSession()
        {
            if (networkServer != null)
            {
                networkServer.OnClientConnected -= NetworkServerOnClientConnected;
                networkServer.OnMessageRecieved += NetworkServerOnMessageRecieved; ;
            }
            networkServer = new NetworkServer();
            networkServer.InitializeServer(34034, 1000, 1000, 3000);
        }

        private void NetworkServerOnMessageRecieved(object sender, MessageRecievedEventArgs e)
        {

        }

        private void NetworkServerOnClientConnected(object sender, IdEventArgs e)
        {

        }
    }
    class ClientService
    {
        public string ClientName { get; private set; }
    }
}
