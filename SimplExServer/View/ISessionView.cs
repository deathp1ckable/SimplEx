using SimplExServer.Service;
using System;
using System.Collections.Generic;

namespace SimplExServer.View
{
    public interface ISessionView : IView
    {
        double Time { get; set; }
        string GroupName { set; }

        SessionStatus SessionStatus { set; }
        
        SessionClient CurrentSessionClient { get; set; }
        IList<SessionClient> SessionClients { get; set; }

        ISessionInformationView SessionInformationView { get; set; }
        IConnectionStatusView ConnectionStatusView { get; set; }
        IChatView ChatView { get; set; }

        void ShowClientToolTip(SessionClient sessionClient, string title, string caption, bool isWarning);
        void ShowMessage(string title, string message);
        void ShowError(string message);
        void Invoke(Action action);

        event ViewActionHandler<ISessionView> SessionAborted;
        event ViewActionHandler<ISessionView> ClientChanged;
        event ViewActionHandler<ISessionView> SessionStarted;
        event ViewActionHandler<ISessionView> SessionStoped;
    }
}
