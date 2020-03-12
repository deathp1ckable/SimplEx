using System;
namespace SimplExNetworking.EventArguments
{
    public class ConnectionEventArgs : EventArgs
    {
        public uint Id { get; set; }
        public string Reason { get; set; }
        public ConnectionEventArgs(uint id, string reason)
        {
            Reason = reason;
            Id = id;
        }
    }
}
