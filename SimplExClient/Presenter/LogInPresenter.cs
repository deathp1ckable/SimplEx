using SimplExClient.Service;
using SimplExClient.Common;
using SimplExClient.View;
using System.Threading;
using System;
using SimplExModel.NetworkData;

namespace SimplExClient.Presenter
{
    class LogInPresenter : Presenter<object, ILogInView>
    {
        ILoadingContextView loadingContextView;
        public LogInPresenter(ILogInView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Connected += ViewConnected;
            loadingContextView = ApplicationController.Run<LoadingContextPresenter, object>(null).View;
        }

        private void ViewConnected(ILogInView sender)
        {
            sender.AllowConnect = false;
            Client sessionClient = new Client(new ClientConnectionData(sender.ViewName, sender.Surname, sender.Patronymic, 0), "127.0.0.1");
            sessionClient.Connected += SessionClientOnConnected;
            sessionClient.FailedToConnect += SessionClientOnFailedToConnect;
            ThreadPool.QueueUserWorkItem((a) => sessionClient.Connect());
            loadingContextView.Show();
        }

        private void SessionClientOnFailedToConnect(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                loadingContextView.Hide();
                Client sessionClient = sender as Client;
                sessionClient.Connected -= SessionClientOnConnected;
                sessionClient.FailedToConnect -= SessionClientOnFailedToConnect;
                View.ShowError("Не удалось подключится к cессии.");
                View.AllowConnect = true;
            });
        }
        private void SessionClientOnConnected(object sender, EventArgs e)
        {
            View.Invoke(() =>
            {
                View.AllowConnect = true;
                loadingContextView.Hide();
                Client sessionClient = sender as Client;
                sessionClient.Connected -= SessionClientOnConnected;
                sessionClient.FailedToConnect -= SessionClientOnFailedToConnect;
                View.Hide();
                ApplicationController.Run<MainPresenter, Client>(sender as Client);
                View.Show();
            });
        }
    }
}
