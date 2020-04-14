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
            view.SessionStartedStoped += ViewSessionStartedStoped;
        }
        public override void Run(Session argument)
        {
            Argument = argument;

            Argument.ClientConnected += ArgumentClientConnected;
            Argument.ClientDisconnected += ArgumentClientDisconnected;
            Argument.ConnectionDataUpdated += ArgumentConnectionDataUpdated;
            Argument.Stopped += ArgumentStopped;

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
            });
            SessionService.GetInstance().Session = null;
        }

        private void ViewSessionStartedStoped(ISessionView sender)
        {
            if (Argument.SessionStatus == SessionStatus.WaitingForConnections)
            {
                Argument.StartSession();
            }
            else if (Argument.SessionStatus == SessionStatus.ExecutionInProgress)
            {
                Argument.Stop(); 
            }
            View.SessionStatus = Argument.SessionStatus;
        }

        private void ViewAbortSession(ISessionView sender)
        {
            Argument.Abort();
            SessionService.GetInstance().Session = null;
            View.Close();
        }
        private void ArgumentConnectionDataUpdated(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                View.SessionClients = Argument.Clients.Union(Argument.ExecutedClients).ToList();
            });
        }

        private void ArgumentClientDisconnected(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                View.SessionClients = Argument.Clients.Union(Argument.ExecutedClients).ToList();
            });
        }

        private void ArgumentClientConnected(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                View.SessionClients = Argument.Clients.Union(Argument.ExecutedClients).ToList();
            });
        }
    }
}
