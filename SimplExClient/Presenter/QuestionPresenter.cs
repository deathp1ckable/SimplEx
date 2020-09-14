using SimplExClient.Common;
using SimplExClient.View;
using SimplExModel.Model;
using SimplExModel.Model.Inherited;
using SimplExModel.NetworkData;

namespace SimplExClient.Presenter
{
    class QuestionPresenter : IntegrablePresenter<ClientArgument, IQuestionView>
    {
        private Question currentQuestion;
        public QuestionPresenter(IQuestionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.NextQuestion += ViewNextQuestion;
            view.PrevQuestion += ViewPrevQuestion;
        }
        public override void Run(ClientArgument argument)
        {
            Argument = argument;
            Argument.Client.SessionStarted += ClientSessionStarted;
            View.OneAnswerQuestionView = ApplicationController.Run<OneAnswerQuestionPresenter, ClientArgument>(Argument).View;

            Argument.MainView.QuestionChanged += MainViewQuestionChanged;
        }

        private void ClientSessionStarted(object sender, System.EventArgs e)
        {
            View.Invoke(() =>
            {
                OpenQuestion();
            });
        }

        private void MainViewQuestionChanged(IMainView sender)
        {
            OpenWithCheckingStatus();
        }

        private void ViewPrevQuestion(IQuestionView sender)
        {
            if (Argument.MainView.SelectPrevQuestion())
                OpenQuestion();
            else View.PrevExisting = false;
        }

        private void ViewNextQuestion(IQuestionView sender)
        {
            if (Argument.MainView.SelectNextQuestion())
                OpenQuestion();
            else View.NextExisting = false;
        }

        private void ViewShown(IQuestionView sender)
        {
            OpenWithCheckingStatus();
        }

        private void OpenWithCheckingStatus()
        {
            if (Argument.MainView.ClientStatus == ClientStatus.Executing)
                OpenQuestion();
            else
            {
                View.NextExisting = false;
                View.PrevExisting = false;
                View.OneAnswerQuestionView.Hide();
                View.QuestionTitle = $"Ожидание начала сессии...";
            }
        }

        private void OpenQuestion()
        {
            View.OneAnswerQuestionView.Hide();
            currentQuestion = Argument.MainView.CurrentQuestion;
            if (currentQuestion != null)
            {
                View.NextExisting = true;
                View.PrevExisting = true;
                Argument.Client.CurrentQuestionNumber = currentQuestion.QuestionNumber;
                View.QuestionTitle = $"Вопрос №{Argument.Client.Exam.FirstQuestionNumber + currentQuestion.QuestionNumber}:";
                View.ThemeName = currentQuestion.Theme.ThemeName;
                View.Points = currentQuestion.Points;
                if (currentQuestion is OneAnswerQuestion)
                    View.OneAnswerQuestionView.Show();
            }
            else
            {
                View.QuestionTitle = $"Выберете вопрос...";
                View.NextExisting = false;
                View.PrevExisting = false;
            }
        }
    }
}
