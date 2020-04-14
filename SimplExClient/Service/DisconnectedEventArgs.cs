using System;

namespace SimplExClient.Service
{
    public class DisconnectedEventArgs : EventArgs
    {
        public string Reason { get; private set; }
        public DisconnectedEventArgs(string reason)
        {
            Reason = reason;
        }
    }
}
