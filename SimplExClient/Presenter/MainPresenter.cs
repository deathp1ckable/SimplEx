using SimplExClient.Common;
using SimplExClient.View;
using SimplExClient.Service;
using SimplExModel.NetworkData;
using System;

namespace SimplExClient.Presenter
{
    class MainPresenter : Presenter<Client, IMainView>
    {
        ILoadingContextView loadingContextView;
        public MainPresenter(IMainView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Disconnected += ViewDisconnected;
            view.ViewLeaved += ViewViewLeaved;
            loadingContextView = ApplicationController.Run<LoadingContextPresenter, object>(null).View;
        }

        private void ViewViewLeaved(IMainView sender)
        {
            if (Argument.ViolationsLimit >= 0 && Argument.ClientStatus == ClientStatus.Executing)
            {
                Argument.AddViolation("Клиент покинул форму выполнения.");
            }
        }

        private void ViewDisconnected(IMainView sender)
        {
            ClientService.GetInstance().Client = null;
            ClientStatus temp = Argument.ClientStatus;
            Argument.Disconnect();
            if (temp == ClientStatus.Connected)
            {
                View.Invoke(() =>
                {
                    loadingContextView.Hide();
                    bool executed = Argument.ClientStatus == ClientStatus.Executed;
                    ResultArgument resultArgument = new ResultArgument("Клиент отключился.", executed ? Argument.Points.ToString() : "-", executed ? Argument.Mark.ToString() : "-");
                    View.Hide();
                    ApplicationController.Run<ResultPresenter, ResultArgument>(resultArgument);
                    View.Close();
                });
            }
        }

        public override void Run(Client argument)
        {
            Argument = argument;

            Argument.Disconnected += ArgumentDisconnected;
            Argument.Reconnecting += ArgumentReconnecting;
            Argument.Reconnected += ArgumentReconnected;
            Argument.SessionStarted += ArgumentSessionStarted;
            Argument.StatusChanged += ArgumentStatusChanged;

            ClientArgument clientArgument = new ClientArgument(Argument, View);

            View.SessionInformationView = ApplicationController.Run<SessionInformationPresenter, ClientArgument>(clientArgument).View;
            View.QuestionView = ApplicationController.Run<QuestionPresenter, ClientArgument>(clientArgument).View;
            View.ChatView = ApplicationController.Run<ChatPresenter, ClientArgument>(clientArgument).View;

            View.FirstQuestionNumber = Argument.Exam.FirstQuestionNumber;
            View.Time = Argument.Exam.Time;
            View.Themes = Argument.Exam.Themes;
            View.GroupName = Argument.GroupName;
            View.ClientStatus = Argument.ClientStatus;
            View.Ticket = Argument.Exam.Tickets[Argument.TicketNumber];
            View.Show();
        }

        private void ArgumentStatusChanged(object sender, EventArgs e)
        {
            View.Invoke(() => View.ClientStatus = Argument.ClientStatus);
        }

        private void ArgumentSessionStarted(object sender, EventArgs e)
        {
            View.Invoke(View.WarnAboutStart);
        }

        private void ArgumentReconnected(object sender, EventArgs e)
        {
            View.Invoke(loadingContextView.Hide);
        }

        private void ArgumentReconnecting(object sender, EventArgs e)
        {
            View.Invoke(loadingContextView.Show);
        }

        private void ArgumentDisconnected(object sender, DisconnectedEventArgs e)
        {
            ClientService.GetInstance().Client = null;
            View.Invoke(() =>
            {
                loadingContextView.Hide();
                bool executed = Argument.ClientStatus == ClientStatus.Executed;
                ResultArgument resultArgument = new ResultArgument(e.Reason, executed ? Argument.Points.ToString() : "Нет значения", executed ? Argument.Mark.ToString() : "Нет значения");
                View.Hide();
                ApplicationController.Run<ResultPresenter, ResultArgument>(resultArgument);
                View.Close();
            });
        }
    }
}
