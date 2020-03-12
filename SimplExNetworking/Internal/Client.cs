using SimplExNetworking.UniqueIdentifiers;
using System;
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
        public Client(TcpClient client, UniqueId id, int keepAliveDelay)
        {
            this.client = client;
            uniqueID = id;

            isAlive = true;
            isDisposed = false;

            keepAliveTimer = new Timer(keepAliveDelay);
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
        private byte[] lengthBuffer = new byte[8];
        private byte[] buffer = null;
        private Package recievedPackage = null;

        private bool isLengthReaded;
        private long messageLength;
        public Package RecievePackage()
        {
            if (!isDisposed)
            {
                recievedPackage = null;
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
                    isLengthReaded = false;
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
