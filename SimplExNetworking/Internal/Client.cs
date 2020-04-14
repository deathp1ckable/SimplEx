using SimplExNetworking.UniqueIdentifiers;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
namespace SimplExNetworking.Internal
{
    internal class Client : IDisposable
    {
        public bool isAlive;
        public bool isDisposed;

        public TcpClient client;
        public UniqueId uniqueID;
        public Timer keepAliveTimer;
        public Client(TcpClient client, UniqueId id)
        {
            this.client = client;
            uniqueID = id;

            isAlive = true;
            isDisposed = false;

            keepAliveTimer = new Timer(5000);
            keepAliveTimer.Elapsed += ConfirmChecker;
            keepAliveTimer.Start();
        }
        private void ConfirmChecker(object sender, ElapsedEventArgs e)
        {
            if (keepAliveTimer != null)
                Dispose();
        }

        public void Confirm()
        {
            keepAliveTimer?.Dispose();
            keepAliveTimer = null;
        }
        private readonly List<byte> buffer = new List<byte>();
        private readonly byte[] lengthBuffer = new byte[4];
        private Package recievedPackage = null;

        private bool isLengthReaded;
        private int messageLength;
        public Package RecievePackage()
        {
            if (!isDisposed)
            {
                recievedPackage = null;
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
                        isLengthReaded = false;
                    }
                }
                if (recievedPackage != null)
                    recievedPackage.senderID = uniqueID.Id;
                return recievedPackage;
            }
            return null;
        }
        public void Dispose()
        {
            if (!isDisposed)
            {
                keepAliveTimer?.Dispose();
                isDisposed = true;
                isAlive = false;
                client.Close();
                uniqueID.Dispose();
            }
        }
    }
}
