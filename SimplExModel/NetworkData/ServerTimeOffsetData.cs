namespace SimplExModel.NetworkData
{
    public class ServerTimeOffsetData
    {
        public double TimeOffset { get; private set; }
        public ServerTimeOffsetData(double timeOffset)
        {
            TimeOffset = timeOffset;
        }
    }
}
