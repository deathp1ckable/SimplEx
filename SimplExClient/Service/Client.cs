using Newtonsoft.Json;
using SimplExModel;
using SimplExModel.Model;
using SimplExModel.Model.Data;
using SimplExModel.NetworkData;
using SimplExNetworking.EventArguments;
using SimplExNetworking.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Timers;

namespace SimplExClient.Service
{
    public class Client
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };
        private string IPAdress;
        private int currentQuestionNumber;
        private System.Timers.Timer reconnectionTimer;
        private ClientStatus clientStatus;
        private readonly NetworkClient networkClient;
        private readonly List<ViolationData> violationsList = new List<ViolationData>();
        private readonly List<ChatMessageData> chatMessagesList = new List<ChatMessageData>();
        private readonly List<Answer> answers = new List<Answer>();

        public uint NetworkId { get; private set; }

        public string TeacherName { get; private set; }
        public string TeacherSurname { get; private set; }
        public string TeacherPatronymic { get; private set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int TicketNumber { get; set; }

        public ClientStatus ClientStatus
        {
            get => clientStatus; private set
            {
                clientStatus = value;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public int CurrentQuestionNumber
        {
            get => currentQuestionNumber; set
            {
                currentQuestionNumber = value;
                if (ClientStatus == ClientStatus.Executing && TrackStatus)
                    UpdateStatus();
            }
        }

        public Exam Exam { get; private set; }
        public Ticket Ticket { get; private set; }
        public string GroupName { get; private set; }
        public bool EnableChat { get; private set; }
        public bool TrackStatus { get; private set; }
        public bool Mixing { get; private set; }
        public int ViolationsLimit { get; private set; }
        public double ReconnectionTime { get; private set; }
        public double ServerTimeOffset { get; private set; }

        public double Poins { get; private set; }
        public double Mark { get; private set; }

        public DateTime? BeginingTime { get; private set; }

        public ReadOnlyCollection<ViolationData> Violations { get; private set; }
        public ReadOnlyCollection<ChatMessageData> ChatMessages { get; private set; }
        public ReadOnlyCollection<Answer> Answers { get; private set; }

        public event EventHandler StatusChanged;
        public event EventHandler FailedToConnect;
        public event EventHandler Connected;
        public event EventHandler SessionStarted;
        public event EventHandler MessageRecieved;
        public event EventHandler Violation;
        public event EventHandler Reconnecting;
        public event EventHandler Reconnected;
        public event EventHandler ResultRecieved;
        public event DisconnectedEventHandler Disconnected;

        public Client(ClientConnectionData data, string IPAdress)
        {
            Violations = new ReadOnlyCollection<ViolationData>(violationsList);
            ChatMessages = new ReadOnlyCollection<ChatMessageData>(chatMessagesList);
            Answers = new ReadOnlyCollection<Answer>(answers);

            networkClient = new NetworkClient();

            networkClient.OnConnectedToServer += NetworkClientOnConnectedToServer;
            networkClient.OnFailedToConnect += NetworkClientOnFailedToConnect;
            networkClient.OnMessageRecieved += NetworkClientOnMessageRecieved;
            networkClient.OnDisconnectedFromServer += NetworkClientOnDisconnectedFromServer;

            this.IPAdress = IPAdress;
            Name = data.Name;
            Surname = data.Surname;
            Patronymic = data.Patronymic;
            TicketNumber = data.TicketNumber;
        }

        public void Connect() => networkClient.Connect(IPAdress, 34034);

        public void UpdateClientConnectionData(ClientConnectionData data)
        {
            if (ClientStatus != ClientStatus.Connected)
                throw new Exception();
            Name = data.Name;
            Surname = data.Surname;
            Patronymic = data.Patronymic;
            TicketNumber = data.TicketNumber;

            if (Exam.Tickets.Count <= TicketNumber)
                throw new Exception();
            else if (Exam.Tickets[TicketNumber].TicketNumber == TicketNumber)
                Ticket = Exam.Tickets[TicketNumber];
            else
                for (int i = 0; i < Exam.Tickets.Count; i++)
                    if (Exam.Tickets[i].TicketNumber == TicketNumber)
                    {
                        Ticket = Exam.Tickets[i];
                        break;
                    }
            if (Ticket is null)
                throw new Exception();
            try
            {
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.ClientConnectionData, data)));
            }
            catch
            {
                throw;
            }
        }
        public void UpdateStatus()
        {
            if (ClientStatus != ClientStatus.Executing)
                throw new Exception();
            if (!TrackStatus)
                throw new Exception();
            try
            {
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.ClientStatus, new ClientStatusData(CurrentQuestionNumber, Answers.Count, (DateTime.Now - BeginingTime).Value.TotalSeconds))));
            }
            catch
            {
                throw;
            }
        }
        public void SendChatMessage(string message)
        {
            if (ClientStatus != ClientStatus.Connected && ClientStatus != ClientStatus.Executing)
                throw new Exception();
            if (!EnableChat)
                throw new Exception();
            try
            {
                ChatMessageData chatMessageData = new ChatMessageData($"{Surname} {Name} {Patronymic}", message, (DateTime.Now - BeginingTime).Value.TotalSeconds);
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.Chat, chatMessageData)));
                chatMessagesList.Add(chatMessageData);
            }
            catch
            {
                throw;
            }
        }
        public void AddViolation(string content)
        {
            if (ClientStatus != ClientStatus.Executing)
                throw new Exception();
            if (ViolationsLimit <= 0)
                throw new Exception();
            try
            {
                ViolationData violationData = new ViolationData(content, (DateTime.Now - BeginingTime).Value.TotalSeconds);
                violationsList.Add(violationData);
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.Violation, violationData)));
                Violation?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                throw;
            }
        }
        public void AddAnswer(Answer answer)
        {
            if (ClientStatus != ClientStatus.Executing)
                throw new Exception();
            if (!ReferenceEquals(answer.Question.ParentQuestionGroup.GetParentTicket(), Ticket))
                throw new Exception();
            answers.Add(answer);
            if (TrackStatus)
                UpdateStatus();
        }
        public bool RemoveAnswer(Answer answer)
        {
            if (ClientStatus != ClientStatus.Executing)
                throw new Exception();
            bool result = answers.Remove(answer);
            if (TrackStatus)
                UpdateStatus();
            return result;
        }
        public void HandOver()
        {
            try
            {
                if (ClientStatus != ClientStatus.Executing)
                    throw new Exception();
                List<AnswerData> answerDatas = new List<AnswerData>();
                for (int i = 0; i < answers.Count; i++)
                    answerDatas.Add(new AnswerData(answers[i]));
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.ClientResult, new ClientResultData(answerDatas.ToArray()))));
                ClientStatus = ClientStatus.Executed;
            }
            catch
            {
                throw;
            }
        }
        public void Disconnect()
        {
            if (ClientStatus == ClientStatus.Disconnected)
                return;
            if (ClientStatus == ClientStatus.Executing)
            {
                HandOver();
            }
            else if (ClientStatus == ClientStatus.Connected)
            {
                try
                {
                    ClientStatus = ClientStatus.Disconnected;
                    networkClient.SendMessage(0, GetMessage(new Package(PackageType.Disconnect, null)));
                    Thread.Sleep(networkClient.ServerUpdateDelay);
                    networkClient.Disconnect();
                }
                catch
                {
                    throw;
                }
            }
            else if (ClientStatus == ClientStatus.Reconnecting)
            {
                StopReconnectionTime();
                ClientStatus = ClientStatus.Disconnected;
            }
        }
        private void NetworkClientOnDisconnectedFromServer(object sender, ReasonEventArgs e)
        {
            if (ClientStatus == ClientStatus.Connected || ClientStatus == ClientStatus.Executing)
            {
                Thread thread = new Thread(Reconnect);
                thread.IsBackground = true;
                thread.Start();

                reconnectionTimer = new System.Timers.Timer(ReconnectionTime * 1000 + 1);
                reconnectionTimer.Elapsed += ReconnectionTimerElapsed;
                reconnectionTimer.Start();
                if (ReconnectionTime > 0)
                {
                    ClientStatus = ClientStatus.Reconnecting;
                    Reconnecting?.Invoke(this, EventArgs.Empty);
                }
            }
            else if (ClientStatus == ClientStatus.Disconnected)
            {
                FailedToConnect?.Invoke(this, EventArgs.Empty);
            }
            else if (ClientStatus == ClientStatus.Executed)
                throw new Exception();
        }

        private void StopReconnectionTime()
        {
            if (reconnectionTimer != null)
            {
                reconnectionTimer.Stop();
                reconnectionTimer = null;
            }
        }
        private void NetworkClientOnMessageRecieved(object sender, MessageRecievedEventArgs e)
        {
            Package message = GetPackage(e.Message);
            switch (message.PackageType)
            {
                case PackageType.ServerConnectionData:
                    ServerConnectionData serverConnectionData = message.Message as ServerConnectionData;

                    Exam = serverConnectionData.Exam;
                    GroupName = serverConnectionData.GroupName;
                    EnableChat = serverConnectionData.EnableChat;
                    ViolationsLimit = serverConnectionData.ViolationLimit;
                    ReconnectionTime = serverConnectionData.ReconnectionTime;
                    TrackStatus = serverConnectionData.TrackStatus;
                    Mixing = serverConnectionData.Mixing;

                    TeacherName = serverConnectionData.TeacherName;
                    TeacherSurname = serverConnectionData.TeacherSurname;
                    TeacherPatronymic = serverConnectionData.TeacherPatronymic;

                    if (Exam.Tickets.Count <= TicketNumber)
                        throw new Exception();
                    else if (Exam.Tickets[TicketNumber].TicketNumber == TicketNumber)
                        Ticket = Exam.Tickets[TicketNumber];
                    else
                        for (int i = 0; i < Exam.Tickets.Count; i++)
                            if (Exam.Tickets[i].TicketNumber == TicketNumber)
                            {
                                Ticket = Exam.Tickets[i];
                                break;
                            }
                    if (Ticket is null)
                        throw new Exception();

                    Connected?.Invoke(this, EventArgs.Empty);
                    break;
                case PackageType.ServerTimeOffset:
                    ServerTimeOffsetData serverTimeOffsetData = message.Message as ServerTimeOffsetData;
                    ServerTimeOffset = serverTimeOffsetData.TimeOffset;
                    BeginingTime = DateTime.Now.AddSeconds(-ServerTimeOffset);
                    ClientStatus = ClientStatus.Connected;
                    break;
                case PackageType.ServerStartSession:
                    ClientStatus = ClientStatus.Executing;
                    if (TrackStatus)
                        UpdateStatus();

                    SessionStarted?.Invoke(this, EventArgs.Empty);
                    break;
                case PackageType.Chat:
                    ChatMessageData chatMessageData = message.Message as ChatMessageData;
                    chatMessagesList.Add(chatMessageData);

                    MessageRecieved?.Invoke(this, EventArgs.Empty);
                    break;
                case PackageType.Violation:
                    ViolationData violationData = message.Message as ViolationData;
                    violationsList.Add(violationData);

                    Violation?.Invoke(this, EventArgs.Empty);
                    break;
                case PackageType.ServerReconnectionApproved:
                    StopReconnectionTime();
                    if (ClientStatus == ClientStatus.Reconnecting)
                    {
                        ClientStatus = ClientStatus.Connected;
                        Reconnected?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                case PackageType.ServerReconnectionRejected:
                    StopReconnectionTime();
                    ClientStatus = ClientStatus.Disconnected;

                    Disconnected?.Invoke(this, new DisconnectedEventArgs("Попытка переподключения отвергнута. Соединение разорвано."));
                    break;
                case PackageType.ServerResponse:
                    ServerResponseData serverResponseData = message.Message as ServerResponseData;

                    Poins = serverResponseData.Points;
                    Mark = serverResponseData.Mark;

                    ResultRecieved?.Invoke(this, EventArgs.Empty);

                    ClientStatus = ClientStatus.Executed;
                    try
                    {
                        networkClient.SendMessage(0, GetMessage(new Package(PackageType.Disconnect, null)));
                        Thread.Sleep(networkClient.ServerUpdateDelay);
                        if (networkClient.ClientState == ClientState.Connected)
                            networkClient.Disconnect();
                    }
                    catch
                    {
                        throw;
                    }
                    Disconnected?.Invoke(this, new DisconnectedEventArgs("Выполнение окончено."));
                    break;
                case PackageType.Disconnect:
                    if (ClientStatus == ClientStatus.Executing)
                        HandOver();
                    else
                    {
                        DisconnectData disconnectData = message.Message as DisconnectData;
                        ClientStatus = ClientStatus.Disconnected;
                        Disconnected?.Invoke(this, new DisconnectedEventArgs(disconnectData.Reason));
                    }
                    break;
            }
        }
        private void Reconnect()
        {
            void ReconnnectionDataSender(object a, EventArgs s)
            {
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.ClientReconnecting, new ReconnectionData(NetworkId))));
                NetworkId = networkClient.ClientId;
            }
            try
            {

                networkClient.OnConnectedToServer += ReconnnectionDataSender;
                while (ClientStatus == ClientStatus.Reconnecting)
                {
                    if (networkClient.ClientState == ClientState.Disconnected)
                        networkClient.Connect("127.0.0.1", 34034);
                    Thread.Sleep(networkClient.ServerUpdateDelay);
                }
                if (networkClient.ClientState == ClientState.Connected && (ClientStatus == ClientStatus.Disconnected || ClientStatus == ClientStatus.Executed))
                    networkClient.Disconnect();
            }
            catch
            {
                networkClient.OnConnectedToServer -= ReconnnectionDataSender;
                throw;
            }
        }
        private void NetworkClientOnFailedToConnect(object sender, ReasonEventArgs e)
        {
            FailedToConnect?.Invoke(this, EventArgs.Empty);
        }

        private void NetworkClientOnConnectedToServer(object sender, EventArgs e)
        {
            try
            {
                networkClient.SendMessage(0, GetMessage(new Package(PackageType.ClientConnectionData, new ClientConnectionData(Name, Surname, Patronymic, 0))));
                NetworkId = networkClient.ClientId;
                networkClient.OnConnectedToServer -= NetworkClientOnConnectedToServer;
            }
            catch
            {
                throw;
            }
        }
        private void ReconnectionTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (reconnectionTimer != null)
            {
                ClientStatus = ClientStatus.Disconnected;
                reconnectionTimer = null;
                Disconnected?.Invoke(this, new DisconnectedEventArgs("Соединение потеряно."));
            }
        }
        private byte[] GetMessage(Package package) => Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(package, settings));
        private Package GetPackage(byte[] data) => JsonConvert.DeserializeObject<Package>(Encoding.Unicode.GetString(data), settings);
    }
    public delegate void DisconnectedEventHandler(object sender, DisconnectedEventArgs e);
}
