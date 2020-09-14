using SimplExServer.Common;
using SimplExServer.Service;
using SimplExServer.View;
using SimplExModel.NetworkData;
using System.Collections.Generic;

namespace SimplExServer.Presenter
{
    class ChatPresenter : IntegrablePresenter<SessionArgument, IChatView>
    {
        private bool isHiden = true;
        private readonly List<string> messages = new List<string>();
        private SessionClient currentSessionClient;
        public ChatPresenter(IChatView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.MessageSended += ViewMessageSended;
        }
        public override void Run(SessionArgument argument)
        {
            Argument = argument;
            Argument.SessionView.ClientChanged += SessionViewClientChanged;
            Argument.Session.MessageRecieved += SessionMessageRecieved;
            Argument.Session.Reconnecting += SessionReconnecting;
            Argument.Session.Reconnected += SessionReconnected;
            Argument.Session.ClientDisconnected += SessionClientDisconnected;
            View.EnableChat = argument.Session.EnableChat;
        }

        private void SessionClientDisconnected(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    View.EnableChat = false;
            });
        }

        private void SessionReconnected(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    RefreshMessages();
            });

        }

        private void SessionReconnecting(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    View.EnableChat = false;
            });
        }

        private void SessionMessageRecieved(object sender, SessionClientEventArg e)
        {
            View.Invoke(() =>
            {
                if (ReferenceEquals(e.SessionClient, currentSessionClient))
                    RefreshMessages();
                if (isHiden || !ReferenceEquals(e.SessionClient, currentSessionClient))
                    Argument.SessionView.ShowClientToolTip(e.SessionClient, "Новое сообщение", "Прочитайте новое сообщение в чате.", false);
            });
        }
        private void ViewMessageSended(IChatView sender)
        {
            string message = sender.Message.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                if (sender.Broadcast)
                    for (int i = 0; i < Argument.Session.Clients.Count; i++)
                        Argument.Session.SendChatMessage(Argument.Session.Clients[i], message);
                else
                    Argument.Session.SendChatMessage(currentSessionClient, message);
                RefreshMessages();
            }
        }

        private void SessionViewClientChanged(ISessionView sender)
        {
            currentSessionClient = Argument.SessionView.CurrentSessionClient;
            RefreshMessages();
        }

        private void ViewShown(IChatView sender)
        {
            isHiden = false;
            currentSessionClient = Argument.SessionView.CurrentSessionClient;
            RefreshMessages();
            if (currentSessionClient.ClientStatus == ClientStatus.Reconnecting || currentSessionClient.ClientStatus == ClientStatus.Executed)
                View.EnableChat = false;
        }
        private void ViewHiden(IChatView sender)
        {
            isHiden = true;
        }
        private void RefreshMessages()
        {
            View.Invoke(() =>
            {
                messages.Clear();
                for (int i = 0; i < currentSessionClient.ChatMessages.Count; i++)
                    messages.Add($"[{Argument.Session.InitializeTime.Value.AddSeconds(currentSessionClient.ChatMessages[i].TimeOffset)}] " +
                        $"{currentSessionClient.ChatMessages[i].SenderName}: " +
                        $"{currentSessionClient.ChatMessages[i].Content}");
                View.Messages = messages;
                View.EnableChat = Argument.Session.EnableChat;
            });
        }
    }
}
