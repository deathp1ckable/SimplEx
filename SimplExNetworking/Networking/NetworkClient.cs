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

        private System.Timers.Timer keepAliveTimer = new System.Timers.Timer();
        private List<uint> connectedClients = new List<uint>();
        private bool isAlive;

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

                    keepAliveTimer.Stop();
                    keepAliveTimer.Interval = 5000;
                    keepAliveTimer.AutoReset = false;
                    keepAliveTimer.Start();
                }
                catch (Exception ex)
                {
                    ClientState = ClientState.Disconnected;
                    ThreadPool.QueueUserWorkItem((a) => OnFailedToConnect?.Invoke(this, new ReasonEventArgs(ex.Message)));
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

        private readonly List<byte> buffer = new List<byte>();
        private readonly byte[] lengthBuffer = new byte[4];
        private Package recievedPackage = null;
        private bool isLengthReaded;
        private int messageLength;
        private void PackageReciever()
        {
            try
            {
                while (ClientState != ClientState.Disconnected)
                {
                    if (!isLengthReaded && client.Available >= 4)
                    {
                        client.GetStream().Read(lengthBuffer, 0, lengthBuffer.Length);
                        messageLength = BitConverter.ToInt32(lengthBuffer, 0);
                        buffer.Clear();
                        isLengthReaded = true;
                        isAlive = true;
                    }
                    if (isLengthReaded)
                    {
                        if (client.Available > 0)
                        {
                            byte[] tempBuffer;
                            if (buffer.Count + client.Available >= messageLength)
                                tempBuffer = new byte[messageLength - buffer.Count];
                            else
                                tempBuffer = new byte[client.Available];
                            client.GetStream().Read(tempBuffer, 0, tempBuffer.Length);
                            buffer.AddRange(tempBuffer);
                            isAlive = true;
                        }
                        if (buffer.Count == messageLength)
                        {
                            recievedPackage = SerializationHelper.ProtoDeserialize<Package>(buffer.ToArray());
                            PackageHandler(recievedPackage);
                            isLengthReaded = false;
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
                    if (package.targetID == ClientId && ClientState == ClientState.Connected)
                        ThreadPool.QueueUserWorkItem((a) => OnMessageRecieved?.Invoke(this, new MessageRecievedEventArgs(package.senderID, package.content)));
                    break;
                case PackageType.Confirm:
                    if (package.senderID == 0 && ClientState == ClientState.Confirmation)
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
                            ThreadPool.QueueUserWorkItem((a) => OnConnectedToServer?.Invoke(this, EventArgs.Empty));
                            ClientState = ClientState.Connected;

                            isAlive = true;

                            keepAliveTimer.Stop();
                            keepAliveTimer.Interval = KeepAliveDelay * 1.5;
                            keepAliveTimer.AutoReset = true;
                            keepAliveTimer.Start();
                        }
                        else
                        {
                            ThreadPool.QueueUserWorkItem((a) => OnFailedToConnect?.Invoke(this, new ReasonEventArgs(info.additionalInfo)));
                            ClientState = ClientState.Disconnected;
                        }
                    }
                    break;
                case PackageType.AddClient:
                    if (package.senderID == 0 && ClientState == ClientState.Connected)
                    {
                        ID = BitConverter.ToUInt32(package.content, 0);
                        if (ID != ClientId)
                        {
                            connectedClients.Add(ID);
                            ThreadPool.QueueUserWorkItem((a) => OnClientConnected?.Invoke(this, new IdEventArgs(ID)));
                        }
                    }
                    break;
                case PackageType.RemoveClient:
                    if (package.senderID == 0 && ClientState == ClientState.Connected)
                    {
                        ID = BitConverter.ToUInt32(package.content, 0);
                        if (ID != ClientId)
                        {
                            connectedClients.Remove(ID);
                            ThreadPool.QueueUserWorkItem((a) => OnClientDisconnected?.Invoke(this, new IdEventArgs(ID)));
                        }
                    }
                    break;
                case PackageType.Update:
                    if (package.senderID == 0 && ClientState == ClientState.Connected)
                    {
                        isAlive = true;
                        updatePackage.senderID = ClientId;
                        SendPackage(updatePackage);
                    }
                    break;
                case PackageType.SettingsChanged:
                    if (package.senderID == 0 && ClientState == ClientState.Connected)
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

                        ThreadPool.QueueUserWorkItem((a) => OnSettingsChanged?.Invoke(this, EventArgs.Empty));
                    }
                    break;
                case PackageType.Disconnect:
                    if (package.senderID == 0)
                        Disconnect(false, Encoding.Unicode.GetString(package.content));
                    break;
            }
        }
        private readonly List<byte> bufferList = new List<byte>();
        private void SendPackage(Package package)
        {
            if (ClientState != ClientState.Disconnected)
            {
                try
                {
                    byte[] data = SerializationHelper.ProtoSerialize(package);
                    byte[] length = BitConverter.GetBytes(data.Length);
                    byte[] result = new byte[data.Length + length.Length];
                    Array.Copy(length, result, length.Length);
                    Array.Copy(data, 0, result, length.Length, data.Length);
                    client.GetStream().Write(result, 0, result.Length);
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
                    ThreadPool.QueueUserWorkItem((a) => OnDisconnectedFromServer?.Invoke(this, new ReasonEventArgs(reason)));
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
            if (ClientState == ClientState.Confirmation)
            {
                Disconnect(false, "Connection was not aproved by server.");
                isAlive = false;
            }
        }
    }
}
