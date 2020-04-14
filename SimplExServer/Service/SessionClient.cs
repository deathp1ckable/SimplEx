using SimplExModel.Model;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimplExModel.NetworkData;

namespace SimplExServer.Service
{
    public class SessionClient
    {
        private Timer reconnectionTimer;
        private readonly List<ViolationData> violationsList = new List<ViolationData>();
        private readonly List<ClientStatusData> clientStatuses = new List<ClientStatusData>();
        private readonly List<ChatMessageData> chatMessagesList = new List<ChatMessageData>();

        public uint NetworkId { get; set; }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public int TicketNumber { get; private set; }

        public ClientStatus ClientStatus { get; set; }

        public double Points { get; set; }

        public ExecutionResult ExecutionResult { get; set; }

        public ReadOnlyCollection<ViolationData> Violations { get; private set; }
        public ReadOnlyCollection<ClientStatusData> ClientStatuses { get; private set; }
        public ReadOnlyCollection<ChatMessageData> ChatMessages { get; private set; }

        public event EventHandler ReconnectionTimerElapsed;

        public SessionClient(uint networkId, ClientConnectionData data)
        {
            Violations = new ReadOnlyCollection<ViolationData>(violationsList);
            ChatMessages = new ReadOnlyCollection<ChatMessageData>(chatMessagesList);
            ClientStatuses = new ReadOnlyCollection<ClientStatusData>(clientStatuses);

            NetworkId = networkId;
            Name = data.Name;
            Surname = data.Surname;
            Patronymic = data.Patronymic;
            TicketNumber = data.TicketNumber;
        }
        public void UpdateClientConnectionData(ClientConnectionData data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            if (ClientStatus != ClientStatus.Connected)
                throw new Exception();
            Name = data.Name;
            Surname = data.Surname;
            Patronymic = data.Patronymic;
            TicketNumber = data.TicketNumber;
        }
        public void UpdateClientStatusData(ClientStatusData data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            clientStatuses.Add(data);
        }
        public void AddChatMessageData(ChatMessageData data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            chatMessagesList.Add(data);
        }
        public void AddViolationData(ViolationData data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));
            violationsList.Add(data);
        }
        public void BeginReconnectionTime(double time)
        {
            reconnectionTimer = new Timer(time * 1000 + 1);
            reconnectionTimer.Elapsed += TimerElapsed;
            reconnectionTimer.Start();
        }
        public void StopReconnectionTime()
        {
            if (reconnectionTimer != null)
            {
                reconnectionTimer.Stop();
                reconnectionTimer = null;
            }
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (reconnectionTimer != null)
            {
                ReconnectionTimerElapsed?.Invoke(this, EventArgs.Empty);
                reconnectionTimer = null;
            }
        }
    }
}
