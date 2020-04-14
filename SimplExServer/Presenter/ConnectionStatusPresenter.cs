using SimplExServer.Common;
using SimplExServer.Service;
using SimplExServer.View;
using System.Linq;

namespace SimplExServer.Presenter
{
    class ConnectionStatusPresenter : IntegrablePresenter<SessionArgument, IConnectionStatusView>
    {
        private bool isHiden = true;
        private SessionClient currentSessionClient;
        public ConnectionStatusPresenter(IConnectionStatusView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.ViolationAdded += ViewViolationAdded;
            view.Disconnected += ViewDisconnected;
        }

        public override void Run(SessionArgument argument)
        {
            Argument = argument;

            Argument.SessionView.ClientChanged += SessionViewClientChanged;

            View.TrackStatus = argument.Session.TrackStatus;
            View.TrackViolations = argument.Session.ViolationsLimit >= 0;

            Argument.Session.ConnectionDataUpdated += SessionConnectionDataUpdated;
            Argument.Session.ClientStatusUpdated += SessionStatusUpdated;
            Argument.Session.Reconnecting += SessionReconnecting;
            Argument.Session.Reconnected += SessionReconnected;
            Argument.Session.ResultRecieved += SessionResultRecieved;
            Argument.Session.Violation += SessionViolation;
            Argument.Session.SessionStatusUpdated += SessionSessionStatusUpdated;
        }

        private void SessionSessionStatusUpdated(object sender, System.EventArgs e)
        {
            View.Invoke(() =>
            {
                View.ClientStatus = currentSessionClient.ClientStatus;
            });
        }
        private void ViewDisconnected(IConnectionStatusView sender)
        {
            Argument.Session.DisconnectClient(currentSessionClient, "Отключен преподавателем.");
            Argument.SessionView.SessionClients = Argument.Session.Clients.Union(Argument.Session.ExecutedClients).ToList();
        }

        private void ViewViolationAdded(IConnectionStatusView sender)
        {
            Argument.Session.AddViolation(currentSessionClient, sender.ViolationContent);
            View.AddViolation($"№{currentSessionClient.Violations.Count} [{Argument.Session.BeginingTime.Value.AddSeconds(currentSessionClient.Violations[currentSessionClient.Violations.Count - 1].TimeOffset)}] {currentSessionClient.Violations[currentSessionClient.Violations.Count - 1].Content}", currentSessionClient.Violations[currentSessionClient.Violations.Count - 1].TimeOffset);
            View.ViolationContent = string.Empty;
        }
        private void SessionViolation(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    View.AddViolation($"№{e.SessionClient.Violations.Count} [{Argument.Session.BeginingTime.Value.AddSeconds(currentSessionClient.Violations[e.SessionClient.Violations.Count - 1].TimeOffset)}] {currentSessionClient.Violations[e.SessionClient.Violations.Count - 1].Content}", e.SessionClient.Violations[e.SessionClient.Violations.Count - 1].TimeOffset);
                if (isHiden || !ReferenceEquals(e.SessionClient, currentSessionClient))
                    Argument.SessionView.ShowClientToolTip(e.SessionClient, "Нарушение", "Состав нарушения доступен к просмотру.", true);
            });
        }

        private void SessionResultRecieved(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                {
                    View.ClientStatus = currentSessionClient.ClientStatus;
                    View.Points = currentSessionClient.Points;
                    View.Mark = currentSessionClient.ExecutionResult.Mark;
                }
                if (isHiden || !ReferenceEquals(e.SessionClient, currentSessionClient))
                    Argument.SessionView.ShowClientToolTip(e.SessionClient, "Выполнение запрещено", "Результат выполенеия доступен к просмотру.", false);
            });
        }

        private void SessionReconnected(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    View.ClientStatus = currentSessionClient.ClientStatus;
                if (isHiden || !ReferenceEquals(e.SessionClient, currentSessionClient))
                    Argument.SessionView.ShowClientToolTip(e.SessionClient, "Соединение восстановлено", "Переподключеие завершено.", true);
            });
        }

        private void SessionReconnecting(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    View.ClientStatus = currentSessionClient.ClientStatus;
                if (isHiden || !ReferenceEquals(e.SessionClient, currentSessionClient))
                    Argument.SessionView.ShowClientToolTip(e.SessionClient, "Потеря соединения", "Ожидание переподключения.", false);
            });
        }

        private void SessionConnectionDataUpdated(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                {
                    View.ConnectionName = currentSessionClient.Name;
                    View.ConnectionSurname = currentSessionClient.Surname;
                    View.ConnectionPatronimyc = currentSessionClient.Patronymic;
                    View.TicketName = $"Билет '{Argument.Session.Exam.Tickets.Single(a => a.TicketNumber == currentSessionClient.TicketNumber).TicketName}'";
                }
                if (isHiden || !ReferenceEquals(e.SessionClient, currentSessionClient))
                    Argument.SessionView.ShowClientToolTip(e.SessionClient, "Обновление данных", "Данные подключения были обновлены.", false);
            });
        }
        private void SessionStatusUpdated(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    View.AddStatus(e.SessionClient.ClientStatuses[e.SessionClient.ClientStatuses.Count - 1].CurrentQuestionNumber,
                      e.SessionClient.ClientStatuses[e.SessionClient.ClientStatuses.Count - 1].ExecutedQuestions,
                      e.SessionClient.ClientStatuses[e.SessionClient.ClientStatuses.Count - 1].TimeOffset);
            });
        }
        private void SessionViewClientChanged(ISessionView sender)
        {
            currentSessionClient = Argument.SessionView.CurrentSessionClient;
            View.ConnectionName = currentSessionClient.Name;
            View.ConnectionSurname = currentSessionClient.Surname;
            View.ConnectionPatronimyc = currentSessionClient.Patronymic;
            View.TicketName = $"Билет '{Argument.Session.Exam.Tickets.Single(a => a.TicketNumber == currentSessionClient.TicketNumber).TicketName}'";

            View.ClientStatus = currentSessionClient.ClientStatus;
            View.Points = currentSessionClient.Points;
            View.Mark = currentSessionClient.ExecutionResult?.Mark ?? 0;

            View.ClearViolations();
            View.ClearStatuses();

            int i;
            for (i = 0; i < currentSessionClient.ClientStatuses.Count; i++)
                View.AddStatus(currentSessionClient.ClientStatuses[i].CurrentQuestionNumber, currentSessionClient.ClientStatuses[i].ExecutedQuestions, currentSessionClient.ClientStatuses[i].TimeOffset);
            for (i = 0; i < currentSessionClient.Violations.Count; i++)
                View.AddViolation($"№{i + 1} [{Argument.Session.BeginingTime.Value.AddSeconds(currentSessionClient.Violations[i].TimeOffset)}] {currentSessionClient.Violations[i].Content}", currentSessionClient.Violations[i].TimeOffset);
        }
        private void ViewHiden(IConnectionStatusView sender)
        {
            isHiden = true;
        }

        private void ViewShown(IConnectionStatusView sender)
        {
            isHiden = false;
            currentSessionClient = Argument.SessionView.CurrentSessionClient;
        }
    }
}
