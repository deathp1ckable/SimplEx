namespace SimplExModel.NetworkData
{
    public class DisconnectData
    {
        public string Reason { get; private set; }

        public DisconnectData(string reason)
        {
            Reason = reason;
        }
    }
}
