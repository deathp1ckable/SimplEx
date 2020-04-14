using System;
namespace SimplExNetworking.EventArguments
{
    public class MessageRecievedEventArgs : EventArgs
    {
        public uint SenderId { get; set; }
        public byte[] Message { get; set; }
        public MessageRecievedEventArgs(uint sender, byte[] message)
        {
            SenderId = sender;
            Message = message;
        }
    }
}
