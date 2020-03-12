using ProtoBuf;
namespace SimplExNetworking.Internal
{
    [ProtoContract(SkipConstructor = true)]
    internal class ServerData
    {
        [ProtoMember(1)]
        public int maxConnections;
        [ProtoMember(2)]
        public int serverUpdateDelay;
        [ProtoMember(3)]
        public int keepAliveDelay;
        public ServerData() { }
        public ServerData(int maxConnections, int serverUpdateDelay, int keepAliveDelay)
        {
            this.maxConnections = maxConnections;
            this.serverUpdateDelay = serverUpdateDelay;
            this.keepAliveDelay = keepAliveDelay;
        }
    }
    [ProtoContract(SkipConstructor = true)]
    internal class ConfirmationInfo
    {
        [ProtoMember(1)]
        public bool confirmed;
        [ProtoMember(2)]
        public ServerData serverInfo;
        [ProtoMember(3)]
        public string additionalInfo;
        [ProtoMember(4)]
        public uint[] connectedClients;
        public ConfirmationInfo() { }
        public ConfirmationInfo(bool confirmed, ServerData serverInfo, string additionalInfo, uint[] connectedClients)
        {
            this.confirmed = confirmed;
            this.serverInfo = serverInfo;
            this.additionalInfo = additionalInfo;
            this.connectedClients = connectedClients;
        }
    }
}
