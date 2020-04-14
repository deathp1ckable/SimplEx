using SimplExServer.Common;
using SimplExServer.Service;
using SimplExServer.View;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Presenter
{
    class SessionPresenter : Presenter<Session, ISessionView>
    {
        public SessionPresenter(ISessionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.SessionAborted += ViewAbortSession;
            view.SessionStarted += ViewSessionStarted;
            view.SessionStoped += ViewSessionStoped;
        }

        private void ViewSessionStoped(ISessionView sender)
        {
            Argument.Stop();
        }
        public override void Run(Session argument)
        {
            Argument = argument;

            Argument.Stopped += ArgumentStopped;
            Argument.ClientConnected += ArgumentClientConnected;
            Argument.ClientDisconnected += ArgumentClientDisconnected;
            Argument.ConnectionDataUpdated += ArgumentConnectionDataUpdated;

            View.SessionClients = new List<SessionClient>();
            View.SessionStatus = Argument.SessionStatus;
            View.GroupName = Argument.GroupName;
            View.Time = Argument.Exam.Time;

            SessionArgument sessionArgument = new SessionArgument(Argument, View);

            View.SessionInformationView = ApplicationController.Run<SessionInformationPresenter, Session>(Argument).View;
            View.ConnectionStatusView = ApplicationController.Run<ConnectionStatusPresenter, SessionArgument>(sessionArgument).View;
            View.ChatView = ApplicationController.Run<ChatPresenter, SessionArgument>(sessionArgument).View;

            View.Show();
        }

        private void ArgumentStopped(object sender, System.EventArgs e)
        {
            View.Invoke(() =>
            {
                View.SessionStatus = Argument.SessionStatus;
                View.ShowMessage("Сессия окончена", "Результаты выполнения доступны к просмотру.");
            });
            SessionService.GetInstance().Session = null;
        }

        private void ViewSessionStarted(ISessionView sender)
        {
            if (Argument.Clients.Count > 0)
            {
                Argument.StartSession();
                View.SessionStatus = Argument.SessionStatus;
            }
        }

        private void ViewAbortSession(ISessionView sender)
        {
            Argument.Abort();
            SessionService.GetInstance().Session = null;
            View.Close();
        }

        private void ArgumentConnectionDataUpdated(object sender, SessionClientEventArg e)
        {
            InvokeRefreshClients();
        }

        private void ArgumentClientDisconnected(object sender, SessionClientEventArg e)
        {
            InvokeRefreshClients();
        }

        private void ArgumentClientConnected(object sender, SessionClientEventArg e)
        {
            InvokeRefreshClients();
        }

        private void InvokeRefreshClients()
        {
            View.Invoke(() =>
            {
                View.SessionClients = Argument.Clients.Union(Argument.ExecutedClients).ToList();
            });
        }
    }
}
