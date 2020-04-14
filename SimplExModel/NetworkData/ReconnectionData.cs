namespace SimplExModel.NetworkData
{
    public class ReconnectionData
    {
        public uint ReconnectionId { get; private set; }
        public ReconnectionData(uint reconnectionId)
        {
            ReconnectionId = reconnectionId;
        }
    }
}
