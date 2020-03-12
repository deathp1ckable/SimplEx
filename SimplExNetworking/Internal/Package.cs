using ProtoBuf;
namespace SimplExNetworking.Internal
{
    [ProtoContract(SkipConstructor = true)]
    internal class Package
    {
        [ProtoMember(1)]
        public PackageType packageType;
        [ProtoMember(2)]
        public uint targetID;
        [ProtoMember(3)]
        public uint senderID;
        [ProtoMember(4)]
        public byte[] content;
        public Package() { }
        public Package(PackageType packageType, byte[] content, uint targetID, uint senderID)
        {
            this.packageType = packageType;
            this.content = content;
            this.targetID = targetID;
            this.senderID = senderID;
        }
    }
    internal enum PackageType : byte
    {
        Confirm,
        Connect,
        AddClient,
        Disconnect,
        RemoveClient,
        SettingsChanged,
        Update,
        UpdateEcho,
        Message
    }
    public enum ClientState : byte { Disconnected, Confirmation, Connected }
    public enum BroadcastMode : byte { All, Others }
}
