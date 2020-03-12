using System;
namespace SimplExNetworking.EventArguments
{
    public class ReasonEventArgs : EventArgs
    {
        public string Reason { get; set; }
        public ReasonEventArgs(string reason) => Reason = reason;
    }
}
