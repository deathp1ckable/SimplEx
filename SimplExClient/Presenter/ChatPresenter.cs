using SimplExClient.Common;
using SimplExClient.View;
using SimplExModel.NetworkData;
using System;
using System.Collections.Generic;

namespace SimplExClient.Presenter
{
    class ChatPresenter : IntegrablePresenter<ClientArgument, IChatView>
    {
        private bool isHiden = true;
        private readonly List<string> messages = new List<string>();
        public ChatPresenter(IChatView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.MessageSended += ViewMessageSended;
        }

        private void ViewHiden(IChatView sender)
        {
            isHiden = true;
        }

        public override void Run(ClientArgument argument)
        {
            Argument = argument;
            Argument.Client.MessageRecieved += SessionMessageRecieved;
            Argument.Client.Reconnecting += ClientReconnecting;
            Argument.Client.Reconnected += ClientReconnected;
            Argument.Client.Disconnected += ClientDisconnected;
            View.EnableChat = argument.Client.EnableChat;
        }

        private void ClientDisconnected(object sender, Service.DisconnectedEventArgs e)
        {
            View.Invoke(() =>
            {
                if (Argument.Client.ClientStatus == ClientStatus.Executed)
                    View.IsActive = false;
            });
        }
        private void ClientReconnected(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                RefreshMessages();
            });
        }

        private void ClientReconnecting(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                View.IsActive = false;
            });
        }

        private void SessionMessageRecieved(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                RefreshMessages();
                if (isHiden)
                    Argument.MainView.ShowChatToolTip();
            });
        }

        private void ViewMessageSended(IChatView sender)
        {
            string message = sender.Message.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                Argument.Client.SendChatMessage(message);
                RefreshMessages();
            }
        }

        private void ViewShown(IChatView sender)
        {
            isHiden = false;
            RefreshMessages();
        }

        private void RefreshMessages()
        {
            View.Invoke(() =>
            {
                messages.Clear();
                for (int i = 0; i < Argument.Client.ChatMessages.Count; i++)
                    messages.Add($"[{Argument.Client.BeginingTime.Value.AddSeconds(Argument.Client.ChatMessages[i].TimeOffset)}] " +
                        $"{Argument.Client.ChatMessages[i].SenderName}: " +
                        $"{Argument.Client.ChatMessages[i].Content}");
                View.Messages = messages;
                View.EnableChat = Argument.Client.EnableChat;
            });
        }
    }
}
