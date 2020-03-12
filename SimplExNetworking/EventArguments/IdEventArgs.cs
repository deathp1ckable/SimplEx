using System;
namespace SimplExNetworking.EventArguments
{
    public class IdEventArgs : EventArgs
    {
        public uint Id { get; set; }
        public IdEventArgs(uint id) => Id = id;
    }
}
