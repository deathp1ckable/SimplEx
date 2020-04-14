namespace SimplExModel.NetworkData
{
    public class ChatMessageData
    {
        public string SenderName { get; private set; }
        public string Content { get; private set; }
        public double TimeOffset { get; private set; }

        public ChatMessageData(string senderName, string content, double timeOffset)
        {
            SenderName = senderName;
            Content = content;
            TimeOffset = timeOffset;
        }
    }
}
