using SimplExNetworking.EventArguments;
using SimplExNetworking.Internal;
using SimplExNetworking.UniqueIdentifiers;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace SimplExNetworking.Networking
{
    public class NetworkServer
    {
        private TcpListener listener;
        private UniqueIdHost host;
        private ClientsDictionary connectedClients = new ClientsDictionary();

        private UniqueId serverID;

        private Thread accepter;
        private Thread reciecer;
        private Thread keepAlive;

        private int keepAliveDelay = 1000;
        private int updateDelay = 10;
        private int maxConnections = 30;
        public int Port { get; set; } = 1759;
        public int KeepAliveDelay
        {
            get => keepAliveDelay; set
            {
                keepAliveDelay = value;
                SendSettings();
            }
        }
        public int UpdateDelay
        {
            get => updateDelay; set
            {
                updateDelay = value;
                SendSettings();
            }
        }
        public int MaxConnections
        {
            get => maxConnections; set
            {
                if (MaxConnections + 1 >= connectedClients.Count)
                {
                    maxConnections = value;
                    SendSettings();
                }
                else throw new ArgumentException("Attemting to set max connection count to less value then cont of existing connections.");
            }
        }
        public string Password { get; set; } = string.Empty;
        public bool IsInitialized { get; set; }
        public ClientsList ConnectedClients { get; private set; }
        public event EventHandler OnServerInitialized;
        public event EventHandler OnServerStopped;
        public event IdEventHandler OnClientConnected;
        public event ConnectionEventHandler OnClientDisconnected;
        public event MessageRecievedEventHandler OnMessageRecieved;
        public event ReasonEventHandler OnFailedToInitializeServer;
        public NetworkServer() => ConnectedClients = new ClientsList(connectedClients);
        public void InitializeServer(int port, string password, int maxConnections, int updateDelay, int keepAliveDeley)
        {
            Port = port;
            UpdateDelay = updateDelay;
            KeepAliveDelay = keepAliveDeley;
            MaxConnections = maxConnections;
            Password = password;
            InitializeServer();
        }
        public void InitializeServer(int port, int maxConnections, int updateDelay, int keepAliveDeley)
        {
            Port = port;
            UpdateDelay = updateDelay;
            KeepAliveDelay = keepAliveDeley;
            MaxConnections = maxConnections;
            Password = "";
            InitializeServer();
        }
        public void InitializeServer()
        {
            if (!IsInitialized)
            {
                try
                {
                    connectedClients.Clear();
                    IsInitialized = true;
                    host = new UniqueIdHost(KeepAliveDelay);
                    serverID = host.CreateUniqueID();

                    connectedClients.Add(null);

                    listener = new TcpListener(new IPEndPoint(IPAddress.Any, Port));
                    listener.Start();

                    accepter = new Thread(Accepter);
                    accepter.IsBackground = true;
                    accepter.Start();

                    reciecer = new Thread(PackageReciever);
                    reciecer.IsBackground = true;
                    reciecer.Start();

                    keepAlive = new Thread(KeepAlive);
                    keepAlive.IsBackground = true;
                    keepAlive.Start();

                    OnServerInitialized?.Invoke(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    IsInitialized = false;
                    OnFailedToInitializeServer?.Invoke(this, new ReasonEventArgs(ex.Message));
                }
            }
            else throw new InvalidOperationException("Attempting to initialized already initilized NetworkServer");
        }
        public void CheckForIncomingData() => PackageReciever();
        public void DisconnectClient(uint clientId)
        {
            if (connectedClients.ContainsKey(clientId))
                DisconnectClient(clientId, true);
            else throw new InvalidOperationException("Attempting to disconnect to unconnected client.");
        }

        public void SendMessage(uint targetId, byte[] message)
        {
            if (connectedClients.ContainsKey(targetId))
                SendPackage(new Package(PackageType.Message, message, targetId, 0));
            else throw new InvalidOperationException("Attempting to send message to unconnected client.");
        }
        public void BroadcastMessage(uint[] targetIds, byte[] message)
        {
            Client[] tmp = connectedClients.Values.ToArray();
            for (int i = 0; i < tmp.Length; i++)
                SendMessage(tmp[i].uniqueID.Id, message);
        }
        public void BroadcastMessage(BroadcastMode broadcastingType, byte[] message)
        {
            Client[] tmp = connectedClients.Values.ToArray();
            for (int i = 0; i < tmp.Length; i++)
                if (broadcastingType == BroadcastMode.All)
                    if (tmp[i] == null)
                        OnMessageRecieved?.Invoke(this, new MessageRecievedEventArgs(0, message));
                    else
                        SendMessage(tmp[i].uniqueID.Id, message);
                else if (tmp[i] != null)
                    SendMessage(tmp[i].uniqueID.Id, message);
        }

        public void StopServer()
        {
            if (IsInitialized)
            {
                Client[] tmp = connectedClients.Values.ToArray();
                for (int i = 0; i < tmp.Length; i++)
                    if (tmp[i] != null)
                        DisconnectClient(tmp[i].uniqueID.Id, true, "Server stopped.");
                listener.Stop();
                serverID.Dispose();
                IsInitialized = false;
                keepAlive.Abort();
                accepter.Abort();
                reciecer.Abort();
                OnServerStopped?.Invoke(this, new EventArgs());
            }
            else throw new InvalidOperationException("Attempting to stop uninitilized NetworkServer");
        }

        private void Accepter()
        {
            try
            {
                while (IsInitialized)
                    connectedClients.Add(new Client(listener.AcceptTcpClient(), host.CreateUniqueID(), KeepAliveDelay));
            }
            catch (SocketException ex) when (ex.ErrorCode == 10004)
            {
                return;
            }
            catch (ThreadAbortException)
            {
                return;
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " SERVER PACKAGE RECIEVER ERROR: " + ex.Message + Environment.NewLine);
                Accepter();
            }
        }
        private void PackageReciever()
        {
            Client current = null;
            Client[] tmp;
            Package package;
            try
            {
                while (IsInitialized)
                {
                    tmp = connectedClients.Values.ToArray();
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        current = tmp[i];
                        if (tmp[i] != null)
                        {
                            package = tmp[i].RecievePackage();
                            if (package != null) PackageHandler(package);
                        }
                    }
                    Thread.Sleep(UpdateDelay);
                }
            }
            catch (ThreadAbortException)
            {
                return;
            }
            catch (SocketException ex)
            {
                if (current != null)
                    DisconnectClient(current.uniqueID.Id, false, "Connection lost: " + ex.Message);
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " SERVER PACKAGE RECIEVER ERROR: " + ex.Message + Environment.NewLine);
                PackageReciever();
            }
        }
        private Package updatePackage = new Package(PackageType.Update, null, 0, 0);
        private void KeepAlive()
        {
            try
            {

                while (IsInitialized)
                {
                    Client[] tmp = connectedClients.Values.ToArray();
                    for (int i = 0; i < tmp.Length; i++)
                        if (tmp[i] != null)
                        {
                            if (tmp[i].isDisposed)
                                connectedClients.Remove(tmp[i].uniqueID.Id);
                            if (!tmp[i].isAlive)
                                DisconnectClient(tmp[i].uniqueID.Id, false, "Client is not responding");
                            tmp[i].isAlive = false;
                            updatePackage.targetID = tmp[i].uniqueID.Id;
                            SendPackage(updatePackage);
                        }
                    Thread.Sleep(keepAliveDelay);
                }
            }
            catch (ThreadAbortException)
            {
                return;
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " SERVER PACKAGE RECIEVER ERROR: " + ex.Message + Environment.NewLine);
                KeepAlive();
            }
        }
        private Package recieverPackage = new Package();

        private void PackageHandler(Package package)
        {
            switch (package.packageType)
            {
                case PackageType.Message:
                    if (package.targetID == 0)
                        OnMessageRecieved?.Invoke(this, new MessageRecievedEventArgs(package.senderID, package.content));
                    else SendPackage(package);
                    break;
                case PackageType.Connect:
                    if (!connectedClients[package.senderID].isDisposed)
                        if (connectedClients.Count > MaxConnections + 1)
                        {
                            ConfirmationInfo info = new ConfirmationInfo(false, null, "Server is full.", null);
                            recieverPackage.packageType = PackageType.Confirm;
                            recieverPackage.content = SerializationHelper.ProtoSerialize(info);
                            recieverPackage.targetID = package.senderID;
                            SendPackage(recieverPackage);
                        }
                        else if (Password != string.Empty && Encoding.Unicode.GetString(package.content) != Password)
                        {
                            ConfirmationInfo info = new ConfirmationInfo(false, null, "Incorrect password.", null);
                            recieverPackage.packageType = PackageType.Confirm;
                            recieverPackage.content = SerializationHelper.ProtoSerialize(info);
                            recieverPackage.targetID = package.senderID;
                            SendPackage(recieverPackage);
                        }
                        else
                        {
                            connectedClients[package.senderID].Confirm();
                            uint[] ids = new uint[connectedClients.Count];
                            connectedClients.Keys.CopyTo(ids, 0);
                            ConfirmationInfo info = new ConfirmationInfo(true, new ServerData(MaxConnections, UpdateDelay, KeepAliveDelay), "Connection successful", ids);
                            recieverPackage.packageType = PackageType.Confirm;
                            recieverPackage.content = SerializationHelper.ProtoSerialize(info);
                            recieverPackage.targetID = package.senderID;
                            SendPackage(recieverPackage);
                            recieverPackage.packageType = PackageType.AddClient;
                            recieverPackage.content = BitConverter.GetBytes(package.senderID);
                            BroadcastPackage(recieverPackage);
                            OnClientConnected?.Invoke(this, new IdEventArgs(package.senderID));
                        }
                    break;
                case PackageType.Disconnect:
                    DisconnectClient(package.senderID, false, Encoding.Unicode.GetString(package.content));
                    break;
                case PackageType.UpdateEcho:
                    connectedClients[package.senderID].isAlive = true;
                    break;
            }
        }
        private void SendPackage(Package package)
        {
            if (IsInitialized == true)
            {
                try
                {
                    byte[] buff = SerializationHelper.ProtoSerialize(package);
                    byte[] length = BitConverter.GetBytes((long)buff.Length);
                    connectedClients[package.targetID].client.GetStream().Write(length, 0, length.Length);
                    connectedClients[package.targetID].client.GetStream().Write(buff, 0, buff.Length);
                }
                catch (SocketException ex)
                {
                    DisconnectClient(package.targetID, false, "Connection lost: " + ex.Message);
                }
                catch
                {
                    return;
                }
            }
            else throw new InvalidOperationException("Attempting to send message with uninitilized NetworkServer");
        }
        private void BroadcastPackage(Package package)
        {
            Client[] tmp = connectedClients.Values.ToArray();
            for (int i = 0; i < tmp.Length; i++)
                if (tmp[i] != null)
                {
                    package.targetID = tmp[i].uniqueID.Id;
                    SendPackage(package);
                }
        }

        private ServerData settings = new ServerData();
        private Package settingsPackage = new Package(PackageType.SettingsChanged, null, 0, 0);
        private void SendSettings()
        {
            if (IsInitialized)
            {
                settings.keepAliveDelay = keepAliveDelay;
                settings.serverUpdateDelay = updateDelay;
                settings.maxConnections = maxConnections;
                settingsPackage.content = SerializationHelper.ProtoSerialize(settings);
                BroadcastPackage(settingsPackage);
            }
        }
        private void DisconnectClient(uint clientID, bool sendReason, string reason = "Disconnected by server")
        {
            if (IsInitialized == true)
            {
                if (connectedClients.ContainsKey(clientID))
                {
                    Package disconnectPackage = new Package();
                    if (sendReason)
                    {
                        disconnectPackage.packageType = PackageType.Disconnect;
                        disconnectPackage.content = Encoding.Unicode.GetBytes(reason);
                        disconnectPackage.targetID = clientID;
                        SendPackage(disconnectPackage);
                    }
                    if (connectedClients.ContainsKey(clientID))
                    {
                        if (connectedClients[clientID].keepAliveTimer == null)
                            OnClientDisconnected?.Invoke(this, new ConnectionEventArgs(clientID, reason));
                        connectedClients[clientID].Dispose();
                        connectedClients.Remove(clientID);
                        disconnectPackage.packageType = PackageType.RemoveClient;
                        disconnectPackage.content = BitConverter.GetBytes(clientID);
                        BroadcastPackage(disconnectPackage);
                    }
                }
            }
            else throw new InvalidOperationException("Attempting to disconnect client from uninitilized NetworkServer.");
        }
    }
    public delegate void MessageRecievedEventHandler(object sender, MessageRecievedEventArgs e);
    public delegate void ReasonEventHandler(object sender, ReasonEventArgs e);
    public delegate void IdEventHandler(object sender, IdEventArgs e);
    public delegate void ConnectionEventHandler(object sender, ConnectionEventArgs e);
}
