using System;
namespace SimplExNetworking.EventArguments
{
    public class MessageRecievedEventArgs : EventArgs
    {
        public uint Sender { get; set; }
        public byte[] Message { get; set; }
        public MessageRecievedEventArgs(uint sender, byte[] message)
        {
            Sender = sender;
            Message = message;
        }
    }
}
