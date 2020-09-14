using SimplExClient.Common;
using SimplExClient.View;
using SimplExModel.Model;

namespace SimplExClient.Presenter
{
    class QuestionControlPresenter<TView> : IntegrablePresenter<ClientArgument, TView> where TView : class, IQuestionControlView
    {
        private Question currentQuestion;
        private bool isSaved = true;
        private bool isHiding;
        public QuestionControlPresenter(TView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.Answered += ViewAnswered;
            view.AnswerCanceled += ViewAnswerCanceled;
            view.AnswerChanged += ViewAnswerChanged;
        }

        private void ViewAnswerCanceled(IQuestionControlView sender)
        {
            if (currentQuestion != null)
            {
                Argument.Client.RemoveAnswer(currentQuestion.Answer);
                Argument.MainView.ExexutedQuestions = Argument.Client.Answers.Count;
                currentQuestion.Answer = null;
            }
            isSaved = true;
        }

        private void ViewAnswered(IQuestionControlView sender)
        {
            Argument.Client.RemoveAnswer(currentQuestion.Answer);
            sender.Answer.Question = currentQuestion;
            currentQuestion.Answer = sender.Answer;
            Argument.Client.AddAnswer(currentQuestion.Answer);
            Argument.MainView.ExexutedQuestions = Argument.Client.Answers.Count;
            isSaved = true;
        }

        private void ViewHiden(IQuestionControlView sender)
        {
            if (!isHiding)
            {
                if (!isSaved)
                {
                    isHiding = true;
                    Answer answerTemp = sender.Answer;
                    View.Show();
                    View.Answer = answerTemp;
                    sender.AskForSaving();
                    View.Hide();
                    isHiding = false;
                }
                currentQuestion = null;
                isSaved = true;
            }
        }

        private void ViewAnswerChanged(IQuestionControlView sender) => isSaved = false;
        private void ViewShown(IQuestionControlView sender)
        {
            if (!isHiding)
            {
                currentQuestion = Argument.MainView.CurrentQuestion;
                isSaved = true;
                if (currentQuestion == null)
                    View.Hide();
            }
        }
    }
}
