using SimplExNetworking.EventArguments;
using SimplExNetworking.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
namespace SimplExNetworking.Networking
{
    public class NetworkClient
    {
        private TcpClient client;

        private bool isAlive;
        private System.Timers.Timer keepAliveTimer = new System.Timers.Timer();
        private List<uint> connectedClients = new List<uint>();

        private Thread reciever;
        public uint ClientId { get; private set; }
        public ReadOnlyCollection<uint> ConnectedClients { get => connectedClients.AsReadOnly(); }
        public string IPAdress { get; set; } = "127.0.0.1";
        public string Password { get; set; } = "";
        public int Port { get; set; } = 1759;
        public int UpdateDelay { get; set; } = 10;
        public int ServerUpdateDelay { get; private set; }
        public int MaxConnections { get; private set; }
        public int KeepAliveDelay { get; private set; }
        public ClientState ClientState { get; private set; }

        public event EventHandler OnConnectedToServer;
        public event EventHandler OnSettingsChanged;
        public event ReasonEventHandler OnDisconnectedFromServer;
        public event ReasonEventHandler OnFailedToConnect;
        public event IdEventHandler OnClientConnected;
        public event IdEventHandler OnClientDisconnected;
        public event MessageRecievedEventHandler OnMessageRecieved;
        public NetworkClient() => keepAliveTimer.Elapsed += KeepAliveController;

        private Package connectPackage = new Package(PackageType.Connect, null, 0, 0);
        public void Connect(string ipaddress, int port)
        {
            IPAdress = ipaddress;
            Port = port;
            Password = "";
            Connect();
        }
        public void Connect(string ipaddress, int port, string password)
        {
            IPAdress = ipaddress;
            Port = port;
            Password = password;
            Connect();
        }
        public void Connect()
        {
            if (ClientState == ClientState.Disconnected)
                try
                {
                    ClientState = ClientState.Confirmation;

                    isAlive = true;
                    connectedClients.Clear();

                    client = new TcpClient();
                    client.Connect(IPAddress.Parse(IPAdress), Port);

                    reciever = new Thread(PackageReciever);
                    reciever.IsBackground = true;
                    reciever.Start();

                    connectPackage.content = Encoding.Unicode.GetBytes(Password);
                    SendPackage(connectPackage);
                }
                catch (Exception ex)
                {
                    ClientState = ClientState.Disconnected;
                    OnFailedToConnect?.Invoke(this, new ReasonEventArgs(ex.Message));
                }
            else if (ClientState == ClientState.Connected) throw new InvalidOperationException("Attempting to connect already connected NetworkClient.");
            else throw new InvalidOperationException("Attempting to connect NetworkClient while connecting.");
        }
        public void CheckForIncomingData() => PackageReciever();
        public void SendMessage(uint targetId, byte[] message)
        {
            if (connectedClients.Contains(targetId))
                SendPackage(new Package(PackageType.Message, message, targetId, 0));
            else throw new InvalidOperationException("Attempting to send message to unconnected client.");
        }
        public void BroadcastMessage(uint[] targetIds, byte[] message)
        {
            for (int i = 0; i < targetIds.Length; i++)
                if (i < connectedClients.Count)
                {
                    if (connectedClients.Contains(targetIds[i]))
                        SendMessage(targetIds[i], message);
                    else throw new InvalidOperationException("Attempting to send message to unconnected client.");
                }
        }
        public void BroadcastMessage(BroadcastMode broadcastingType, byte[] message)
        {
            for (int i = 0; i < connectedClients.Count; i++)
                if (i < connectedClients.Count)
                    if (connectedClients[i] != ClientId || broadcastingType == BroadcastMode.All)
                        SendMessage(connectedClients[i], message);
        }
        public void Disconnect() => Disconnect(true);

        private byte[] lengthBuffer = new byte[8];
        private byte[] buffer = null;
        private Package recievedPackage = null;
        private bool isLengthReaded;
        private long messageLength;
        private void PackageReciever()
        {
            try
            {
                while (ClientState != ClientState.Disconnected)
                {
                    if (!isLengthReaded && client.Available >= 8)
                    {
                        client.GetStream().Read(lengthBuffer, 0, lengthBuffer.Length);
                        messageLength = BitConverter.ToInt64(lengthBuffer, 0);
                        buffer = new byte[messageLength];
                        isLengthReaded = true;
                    }
                    if (isLengthReaded && client.Available >= messageLength)
                    {
                        client.GetStream().Read(buffer, 0, buffer.Length);
                        recievedPackage = SerializationHelper.ProtoDeserialize<Package>(buffer);
                        PackageHandler(recievedPackage);
                        isLengthReaded = false;
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
                Disconnect(false, "Connection lost: " + ex.Message);
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " CLIENT PACKAGE RECIEVER ERROR: " + ex.Message + Environment.NewLine);
                PackageReciever();
            }
        }

        private uint ID;
        private Package updatePackage = new Package(PackageType.UpdateEcho, null, 0, 0);
        private void PackageHandler(Package package)
        {
            switch (package.packageType)
            {
                case PackageType.Message:
                    if (package.targetID == ClientId)
                        OnMessageRecieved?.Invoke(this, new MessageRecievedEventArgs(package.senderID, package.content));
                    break;
                case PackageType.Confirm:
                    if (package.senderID == 0)
                    {
                        ConfirmationInfo info = SerializationHelper.ProtoDeserialize<ConfirmationInfo>(package.content);
                        if (info.confirmed)
                        {
                            connectedClients.AddRange(info.connectedClients);
                            ClientId = package.targetID;
                            MaxConnections = info.serverInfo.maxConnections;
                            ServerUpdateDelay = info.serverInfo.serverUpdateDelay;
                            UpdateDelay = ServerUpdateDelay;
                            KeepAliveDelay = info.serverInfo.keepAliveDelay;
                            OnConnectedToServer?.Invoke(this, new EventArgs());
                            ClientState = ClientState.Connected;

                            isAlive = true;

                            keepAliveTimer.Stop();
                            keepAliveTimer.Interval = KeepAliveDelay * 1.5;
                            keepAliveTimer.AutoReset = true;
                            keepAliveTimer.Start();
                        }
                        else
                        {
                            OnFailedToConnect?.Invoke(this, new ReasonEventArgs(info.additionalInfo));
                            ClientState = ClientState.Disconnected;
                        }
                    }
                    break;
                case PackageType.AddClient:
                    if (package.senderID == 0)
                    {
                        ID = BitConverter.ToUInt32(package.content, 0);
                        if (ID != ClientId)
                        {
                            connectedClients.Add(ID);
                            OnClientConnected?.Invoke(this, new IdEventArgs(ID));
                        }
                    }
                    break;
                case PackageType.RemoveClient:
                    if (package.senderID == 0)
                    {
                        ID = BitConverter.ToUInt32(package.content, 0);
                        connectedClients.Remove(ID);
                        OnClientDisconnected?.Invoke(this, new IdEventArgs(ID));
                    }
                    break;
                case PackageType.Update:
                    if (package.senderID == 0)
                    {
                        isAlive = true;
                        updatePackage.senderID = ClientId;
                        SendPackage(updatePackage);
                    }
                    break;
                case PackageType.SettingsChanged:
                    if (package.senderID == 0)
                    {
                        ServerData serverInfo = SerializationHelper.ProtoDeserialize<ServerData>(package.content);
                        MaxConnections = serverInfo.maxConnections;
                        ServerUpdateDelay = serverInfo.serverUpdateDelay;
                        UpdateDelay = ServerUpdateDelay;
                        KeepAliveDelay = serverInfo.keepAliveDelay;

                        keepAliveTimer.Stop();
                        keepAliveTimer.Interval = KeepAliveDelay * 1.5;
                        keepAliveTimer.AutoReset = true;
                        keepAliveTimer.Start();

                        OnSettingsChanged?.Invoke(this, new EventArgs());
                    }
                    break;
                case PackageType.Disconnect:
                    if (package.senderID == 0)
                        Disconnect(false, Encoding.Unicode.GetString(package.content));
                    break;
            }
        }
        private void SendPackage(Package package)
        {
            if (ClientState != ClientState.Disconnected)
            {
                try
                {
                    byte[] buff = SerializationHelper.ProtoSerialize(package);
                    byte[] length = BitConverter.GetBytes((long)buff.Length);
                    client.GetStream().Write(length, 0, length.Length);
                    client.GetStream().Write(buff, 0, buff.Length);
                }
                catch (SocketException ex)
                {
                    Disconnect(false, "Connection lost: " + ex.Message);
                }
                catch
                {
                    return;
                }
            }
            else throw new InvalidOperationException("Attempting to send message with unconnected NetworkClient");
        }
        private void Disconnect(bool sendReason, string reason = "Client disconnected by himself.")
        {
            if (ClientState != ClientState.Disconnected)
            {
                if (sendReason && ClientState != ClientState.Confirmation)
                    SendPackage(new Package(PackageType.Disconnect, Encoding.Unicode.GetBytes(reason), 0, ClientId));
                if (ClientState != ClientState.Disconnected)
                {
                    client.Close();
                    keepAliveTimer.Stop();
                    ClientState = ClientState.Disconnected;
                    OnDisconnectedFromServer?.Invoke(this, new ReasonEventArgs(reason));
                    reciever.Abort();
                }
            }
            else throw new InvalidOperationException("Attempting to disconnect unconnected NetworkClient.");
        }
        private void KeepAliveController(object sender, ElapsedEventArgs e)
        {
            if (ClientState == ClientState.Connected)
            {
                if (!isAlive)
                    Disconnect(false, "Connection lost. Server is not responding.");
                isAlive = false;
            }
        }
    }
}
