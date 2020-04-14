namespace SimplExModel.NetworkData
{
    public class ViolationData
    {
        public string Content { get; private set; }
        public double TimeOffset { get; private set; }

        public ViolationData(string content, double timeOffset)
        {
            Content = content;
            TimeOffset = timeOffset;
        }
    }
}
