using Newtonsoft.Json;
using SimplExModel;
using SimplExModel.Model;
using SimplExModel.NetworkData;
using SimplExModel.Service;
using SimplExNetworking.EventArguments;
using SimplExNetworking.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace SimplExServer.Service
{
    class Session
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
            PreserveReferencesHandling = PreserveReferencesHandling.All,
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };

        private ServerConnectionData serverConnectionData;
        private byte[] serverConnectionDataBuffer;
        private System.Timers.Timer sessionTimer;

        private NetworkServer networkServer = new NetworkServer();

        private List<SessionClient> executedClients = new List<SessionClient>();
        private List<SessionClient> clientsList = new List<SessionClient>();
        private Dictionary<uint, SessionClient> clients = new Dictionary<uint, SessionClient>();
        private SessionStatus sessionStatus = SessionStatus.NotStarted;

        public Exam Exam { get; private set; }
        public IExamSaver ExamSaver { get; private set; }

        public SessionStatus SessionStatus
        {
            get => sessionStatus; private set
            {
                sessionStatus = value;
                SessionStatusUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
        public string GroupName { get; private set; }

        public string TeacherName { get; private set; }
        public string TeacherSurname { get; private set; }
        public string TeacherPatronymic { get; private set; }

        public bool EnableChat { get; private set; }
        public bool TrackStatus { get; private set; }
        public bool Mixing { get; private set; }
        public int ViolationsLimit { get; private set; }
        public double ReconnectionTime { get; private set; }

        public DateTime? InitializeTime { get; private set; }
        public DateTime? StartSessionTime { get; private set; }

        public ReadOnlyCollection<SessionClient> Clients { get; private set; }
        public ReadOnlyCollection<SessionClient> ExecutedClients { get; private set; }

        public event SessionClientEventHandler ClientConnected;
        public event SessionClientEventHandler ClientDisconnected;
        public event SessionClientEventHandler ConnectionDataUpdated;
        public event SessionClientEventHandler MessageRecieved;
        public event SessionClientEventHandler ClientStatusUpdated;
        public event SessionClientEventHandler Reconnecting;
        public event SessionClientEventHandler Reconnected;
        public event SessionClientEventHandler Violation;
        public event SessionClientEventHandler ResultRecieved;

        public event EventHandler InitializationFailed;
        public event EventHandler SessionInitialized;
        public event EventHandler SessionStatusUpdated;
        public event EventHandler Stopped;

        public Session(ServerConnectionData data, IExamSaver examSaver)
        {
            serverConnectionData = data;
            Exam = data.Exam;
            ExamSaver = examSaver;
            GroupName = data.GroupName;
            TeacherName = data.TeacherName;
            TeacherSurname = data.TeacherSurname;
            TeacherPatronymic = data.TeacherPatronymic;
            EnableChat = data.EnableChat;
            ReconnectionTime = data.ReconnectionTime;
            ViolationsLimit = data.ViolationLimit;
            TrackStatus = data.TrackStatus;
            Mixing = data.Mixing;

            Clients = new ReadOnlyCollection<SessionClient>(clientsList);
            ExecutedClients = new ReadOnlyCollection<SessionClient>(executedClients);
        }

        public void Initialize()
        {
            int i, j;
            Exam temp = (Exam)serverConnectionData.Exam.Clone();
            for (i = 0; i < temp.Tickets.Count; i++)
            {
                Question[] questions = temp.Tickets[i].GetQuestions();
                for (j = 0; j < questions.Length; j++)
                    questions[j].Answer = null;
            }
            serverConnectionData = new ServerConnectionData(temp, GroupName, TeacherName, TeacherSurname, TeacherPatronymic, EnableChat, TrackStatus, Mixing, ViolationsLimit, ReconnectionTime);

            networkServer.OnMessageRecieved += NetworkServerOnMessageRecieved;
            networkServer.OnClientDisconnected += NetworkServerOnClientDisconnected;
            networkServer.OnServerInitialized += NetworkServerOnServerInitialized;
            networkServer.OnFailedToInitializeServer += NetworkServerOnFailedToInitializeServer;

            SessionStatus = SessionStatus.WaitingForConnections;
            InitializeTime = DateTime.Now;

            ExamSerializationService serializationService = ExamSerializationService.GetInstance();
            serverConnectionDataBuffer = GetMessage(new Package(PackageType.ServerConnectionData, serverConnectionData));
            networkServer.InitializeServer(34034, 1000, 100,5000);
        }

        public void StartSession()
        {
            if (SessionStatus != SessionStatus.WaitingForConnections)
                throw new Exception();
            if (clients.Count == 0)
                throw new Exception();
            try
            {
                networkServer.BroadcastMessage(BroadcastMode.Others, GetMessage(new Package(PackageType.ServerStartSession, null)));
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " START SESSION ERROR: " + ex.Message + Environment.NewLine);
            }
            for (int i = 0; i < clientsList.Count; i++)
                clientsList[i].ClientStatus = ClientStatus.Executing;
            if (Exam.Time > 0)
            {
                sessionTimer = new System.Timers.Timer(Exam.Time * 1000);
                sessionTimer.Elapsed += SessionTimerElapsed;
                sessionTimer.Start();
            }
            StartSessionTime = DateTime.Now;
            SessionStatus = SessionStatus.ExecutionInProgress;
        }
        public void SendChatMessage(SessionClient sessionClient, string message)
        {
            try
            {
                ChatMessageData chatMessageData = new ChatMessageData($"{TeacherSurname} {TeacherName} {TeacherSurname}", message, (DateTime.Now - InitializeTime).Value.TotalSeconds);
                networkServer.SendMessage(sessionClient.NetworkId, GetMessage(new Package(PackageType.Chat, chatMessageData)));
                sessionClient.AddChatMessageData(chatMessageData);
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " SEND CHAT MESSAGE ERROR: " + ex.Message + Environment.NewLine);
            }
        }
        public void AddViolation(SessionClient sessionClient, string content)
        {
            if (SessionStatus == SessionStatus.WaitingForConnections)
                throw new Exception();
            if (ViolationsLimit < 0)
                throw new Exception();
            try
            {
                ViolationData violationData = new ViolationData(content, (DateTime.Now - InitializeTime).Value.TotalSeconds);
                networkServer.SendMessage(sessionClient.NetworkId, GetMessage(new Package(PackageType.Violation, violationData)));
                sessionClient.AddViolationData(violationData);
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " ADD VIOLATION ERROR: " + ex.Message + Environment.NewLine);
            }
            if (sessionClient.Violations.Count > ViolationsLimit)
            {
                DisconnectClient(sessionClient, "Превышен лимит нарушений.");
                sessionClient.ClientStatus = ClientStatus.Disconnected;
            }
            Violation?.Invoke(this, new SessionClientEventArg(sessionClient));
        }
        public void DisconnectClient(SessionClient sessionClient, string reason)
        {
            if (!clients.ContainsKey(sessionClient.NetworkId))
                throw new Exception();
            try
            {
                if (sessionClient.ClientStatus == ClientStatus.Disconnected)
                    return;
                else if (sessionClient.ClientStatus == ClientStatus.Connected)
                {
                    networkServer.SendMessage(sessionClient.NetworkId, GetMessage(new Package(PackageType.Disconnect, new DisconnectData(reason))));
                    clients.Remove(sessionClient.NetworkId);
                    clientsList.Remove(sessionClient);
                    Thread.Sleep(networkServer.UpdateDelay);
                    networkServer.DisconnectClient(sessionClient.NetworkId);
                }
                else if (sessionClient.ClientStatus == ClientStatus.Executing)
                {
                    networkServer.SendMessage(sessionClient.NetworkId, GetMessage(new Package(PackageType.Disconnect, new DisconnectData(reason))));
                }
                else if (sessionClient.ClientStatus == ClientStatus.Reconnecting)
                {
                    sessionClient.StopReconnectionTime();
                    sessionClient.ClientStatus = ClientStatus.Disconnected;
                    sessionClient.ReconnectionTimerElapsed -= SessionClientReconnectionTimerElapsed;
                    clientsList.Remove(sessionClient);
                    clients.Remove(sessionClient.NetworkId);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " DISCONNECT ERROR: " + ex.Message + Environment.NewLine);
            }
        }
        public void Stop()
        {
            for (int i = 0; i < clientsList.Count; i++)
                DisconnectClient(clientsList[i], "Cессия окончена");
            if (SessionStatus == SessionStatus.WaitingForConnections)
                SessionStatus = SessionStatus.Finished;
        }
        public bool SaveResults()
        {
            if (ExamSaver != null)
            {
                for (int i = 0; i < executedClients.Count; i++)
                    if (!ExamSaver.SaveResult(executedClients[i].ExecutionResult))
                        return false;
                return true;
            }
            else throw new Exception();
        }
        public void Abort()
        {
            try
            {
                networkServer.StopServer();
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " ABORT ERROR: " + ex.Message + Environment.NewLine);
            }
            int i;
            for (i = 0; i < clientsList.Count; i++)
                clientsList[i].ClientStatus = ClientStatus.Disconnected;
            for (i = 0; i < executedClients.Count; i++)
                executedClients[i].ClientStatus = ClientStatus.Disconnected;
            clients.Clear();
            clientsList.Clear();
            executedClients.Clear();
        }

        private void NetworkServerOnClientDisconnected(object sender, ConnectionEventArgs e)
        {
            if (clients.ContainsKey(e.Id))
            {
                SessionClient sessionClient = clients[e.Id];
                sessionClient.ClientStatus = ClientStatus.Reconnecting;
                sessionClient.ReconnectionTimerElapsed += SessionClientReconnectionTimerElapsed;
                sessionClient.BeginReconnectionTime(ReconnectionTime);
                if (ReconnectionTime > 0)
                    Reconnecting?.Invoke(this, new SessionClientEventArg(sessionClient));
            }
        }
        private void SessionClientReconnectionTimerElapsed(object sender, EventArgs e)
        {
            SessionClient sessionClient = sender as SessionClient;
            if (clients.ContainsKey(sessionClient.NetworkId))
            {
                sessionClient.ClientStatus = ClientStatus.Disconnected;
                sessionClient.ReconnectionTimerElapsed -= SessionClientReconnectionTimerElapsed;
                clientsList.Remove(sessionClient);
                clients.Remove(sessionClient.NetworkId);
                ClientDisconnected?.Invoke(this, new SessionClientEventArg(sessionClient));

                CheckSessionStatus();
            }
        }
        private void NetworkServerOnMessageRecieved(object sender, MessageRecievedEventArgs e)
        {
            SessionClient sessionClient;
            Package message = GetPackage(e.Message);
            switch (message.PackageType)
            {
                case PackageType.ClientConnectionData:
                    if (SessionStatus != SessionStatus.WaitingForConnections)
                    {
                        try
                        {
                            networkServer.DisconnectClient(e.SenderId);
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " CLIENT CONNECTION DATA ERROR: " + ex.Message + Environment.NewLine);
                        }
                        return;
                    }
                    ClientConnectionData clientInformation = message.Message as ClientConnectionData;
                    if (clients.ContainsKey(e.SenderId))
                    {
                        sessionClient = clients[e.SenderId];
                        sessionClient.UpdateClientConnectionData(clientInformation);

                        ConnectionDataUpdated?.Invoke(this, new SessionClientEventArg(sessionClient));
                        break;
                    }
                    else
                    {
                        double timeOffset = (DateTime.Now - InitializeTime).Value.TotalSeconds;
                        sessionClient = new SessionClient(e.SenderId, clientInformation);
                        clients.Add(e.SenderId, sessionClient);
                        clientsList.Add(sessionClient);
                        try
                        {
                            networkServer.SendMessage(e.SenderId, serverConnectionDataBuffer);
                            networkServer.SendMessage(e.SenderId, GetMessage(new Package(PackageType.ServerTimeOffset, new ServerTimeOffsetData(timeOffset))));
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " CLIENT CONNECTION DATA ERROR: " + ex.Message + Environment.NewLine);
                        }
                        sessionClient.ClientStatus = ClientStatus.Connected;

                        ClientConnected?.Invoke(this, new SessionClientEventArg(sessionClient));
                        break;
                    }
                case PackageType.ClientStatus:
                    string s = Encoding.Unicode.GetString(e.Message);
                    ClientStatusData clientStatusData = message.Message as ClientStatusData;
                    sessionClient = clients[e.SenderId];
                    sessionClient.UpdateClientStatusData(clientStatusData);

                    ClientStatusUpdated?.Invoke(this, new SessionClientEventArg(sessionClient));
                    break;
                case PackageType.Violation:
                    ViolationData violationData = message.Message as ViolationData;
                    sessionClient = clients[e.SenderId];
                    sessionClient.AddViolationData(violationData);
                    if (sessionClient.Violations.Count > ViolationsLimit)
                    {
                        DisconnectClient(sessionClient, "Превышен лимит нарушений.");
                        sessionClient.ClientStatus = ClientStatus.Disconnected;
                    }

                    Violation?.Invoke(this, new SessionClientEventArg(sessionClient));
                    break;
                case PackageType.ClientReconnecting:
                    ReconnectionData reconnectionData = message.Message as ReconnectionData;
                    try
                    {
                        if (clients.ContainsKey(reconnectionData.ReconnectionId))
                        {
                            sessionClient = clients[reconnectionData.ReconnectionId];
                            sessionClient.StopReconnectionTime();
                            if (clients.ContainsKey(sessionClient.NetworkId))
                            {
                                clientsList.Remove(sessionClient);
                                clients.Remove(sessionClient.NetworkId);
                                sessionClient.NetworkId = e.SenderId;
                                clients.Add(e.SenderId, sessionClient);
                                clientsList.Add(sessionClient);
                                networkServer.SendMessage(e.SenderId, GetMessage(new Package(PackageType.ServerReconnectionApproved, null)));

                                if (SessionStatus == SessionStatus.ExecutionInProgress)
                                    sessionClient.ClientStatus = ClientStatus.Executing;
                                else
                                    sessionClient.ClientStatus = ClientStatus.Connected;

                                Reconnected?.Invoke(this, new SessionClientEventArg(sessionClient));
                            }
                            else
                                networkServer.SendMessage(e.SenderId, GetMessage(new Package(PackageType.ServerReconnectionRejected, null)));
                        }
                        else
                            networkServer.SendMessage(e.SenderId, GetMessage(new Package(PackageType.ServerReconnectionRejected, null)));
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " RECONNECTION ERROR: " + ex.Message + Environment.NewLine);
                    }
                    break;
                case PackageType.ClientResult:
                    sessionClient = clients[e.SenderId];
                    ClientResultData clientResultData = message.Message as ClientResultData;
                    ExecutionResult executionResult = new ExecutionResult();
                    Ticket ticket = Exam.Tickets.Single(a => a.TicketNumber == sessionClient.TicketNumber);
                    executionResult.ExecutorGroup = GroupName;
                    executionResult.ExecutorName = sessionClient.Name;
                    executionResult.ExecutorSurname = sessionClient.Surname;
                    executionResult.ExecutorPatronymic = sessionClient.Patronymic;
                    executionResult.ExecutionDate = InitializeTime;
                    executionResult.ExecutionTime = (DateTime.Now - StartSessionTime).Value.TotalSeconds;
                    executionResult.Ticket = ticket;
                    double points = 0;
                    Question[] questions = ticket.GetQuestions();
                    for (int i = 0; i < clientResultData.AnswerDatas.Count; i++)
                    {
                        Answer answer = clientResultData.AnswerDatas[i].CreateAnswer(Exam);
                        points += answer.Question.CheckAnswer(answer);
                        executionResult.Answers.Add(new ExecutorAnswer(answer));
                    }
                    executionResult.Mark = Exam.MarkSystem.GetMark(points / ticket.MaxPoints * 100);
                    Exam.ExecutionResults.Add(executionResult);
                    sessionClient.ExecutionResult = executionResult;
                    executedClients.Add(sessionClient);

                    sessionClient.Points = points;

                    try
                    {
                        networkServer.SendMessage(e.SenderId, GetMessage(new Package(PackageType.ServerResponse, new ServerResponseData(points, executionResult.Mark))));
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " CLIENT RESULT ERROR: " + ex.Message + Environment.NewLine);
                    }
                    sessionClient.ClientStatus = ClientStatus.Executed;

                    ResultRecieved?.Invoke(this, new SessionClientEventArg(sessionClient));
                    break;
                case PackageType.Disconnect:
                    sessionClient = clients[e.SenderId];
                    sessionClient.StopReconnectionTime();
                    clientsList.Remove(sessionClient);
                    clients.Remove(sessionClient.NetworkId);

                    if (sessionClient.ClientStatus != ClientStatus.Executed)
                        sessionClient.ClientStatus = ClientStatus.Disconnected;

                    ClientDisconnected?.Invoke(this, new SessionClientEventArg(sessionClient));

                    CheckSessionStatus();
                    break;
                case PackageType.Chat:
                    sessionClient = clients[e.SenderId];
                    ChatMessageData chatMessageData = message.Message as ChatMessageData;
                    sessionClient.AddChatMessageData(chatMessageData);
                    MessageRecieved?.Invoke(this, new SessionClientEventArg(sessionClient));
                    break;
            }
        }
        private void SessionTimerElapsed(object sender, ElapsedEventArgs e) => Stop();
        private void NetworkServerOnFailedToInitializeServer(object sender, ReasonEventArgs e) => InitializationFailed?.Invoke(this, EventArgs.Empty);
        private void NetworkServerOnServerInitialized(object sender, EventArgs e) => SessionInitialized?.Invoke(this, EventArgs.Empty);
        private void CheckSessionStatus()
        {
            if (clients.Count == 0 && SessionStatus != SessionStatus.WaitingForConnections)
            {
                SessionStatus = SessionStatus.Finished;
                try
                {
                    if (networkServer.IsInitialized)
                        networkServer.StopServer();
                }
                catch (Exception ex)
                {
                    File.AppendAllText("log.txt", "[" + DateTime.Now.ToString() + "]" + " CHECK SESSION STATUS ERROR: " + ex.Message + Environment.NewLine);
                }
                Stopped?.Invoke(this, EventArgs.Empty);
            }
        }
        private byte[] GetMessage(Package package) => Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(package, settings));
        private Package GetPackage(byte[] data) => JsonConvert.DeserializeObject<Package>(Encoding.Unicode.GetString(data), settings);
    }
    delegate void SessionClientEventHandler(object sender, SessionClientEventArg e);
    public enum SessionStatus { NotStarted, WaitingForConnections, ExecutionInProgress, Finished };
}
