namespace SimplExModel.NetworkData
{
    public class ClientConnectionData
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public int TicketNumber { get; private set; }
        public ClientConnectionData(string name, string surname, string patronymic, int ticketNumber)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            TicketNumber = ticketNumber;
        }
    }
    public enum PackageType
    {
        ClientConnectionData,
        ServerConnectionData,
        Violation,
        ClientStatus,
        ClientResult,
        ServerResponse,
        Chat,
        ServerStartSession,
        Disconnect,
        ClientReconnecting,
        ServerReconnectionApproved,
        ServerReconnectionRejected,
        ServerTimeOffset
    }

    public enum ClientStatus
    {
        Connected,
        Executing,
        Executed,
        Reconnecting,
        Disconnected
    }
}
