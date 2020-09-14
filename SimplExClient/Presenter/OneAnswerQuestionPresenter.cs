using SimplExClient.Common;
using SimplExClient.View;
using SimplExModel.Model.Inherited;
using System;
using System.Collections.Generic;

namespace SimplExClient.Presenter
{
    class OneAnswerQuestionPresenter : QuestionControlPresenter<IOneAnswerQuestionView>
    {
        private OneAnswerQuestion currentOneAnswerQuestion;
        public OneAnswerQuestionPresenter(IOneAnswerQuestionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
        }

        private void ViewShown(IQuestionControlView sender)
        {
            currentOneAnswerQuestion = Argument.MainView.CurrentQuestion as OneAnswerQuestion;
            if (currentOneAnswerQuestion == null)
            {
                View.Hide();
                return;
            }
            if (Argument.Client.Mixing)
                MixAnswers(currentOneAnswerQuestion.QuestionContent.Answers);
            View.Answers = currentOneAnswerQuestion.QuestionContent.Answers;
            View.Answer = currentOneAnswerQuestion.Answer;
            View.Devider = currentOneAnswerQuestion.QuestionContent.Devider;
            View.Letters = currentOneAnswerQuestion.QuestionContent.Letters;
            View.QuestionText = currentOneAnswerQuestion.QuestionContent.Text;
        }
        private void MixAnswers(IList<string> answers)
        {
            string temp;
            Random random = new Random();
            int replaces = random.Next(0, answers.Count);
            for (int i = 0; i < replaces; i++)
            {
                temp = answers[i];
                answers[i] = answers[answers.Count - i - 1];
                answers[answers.Count - i - 1] = temp;
            }
        }
    }
}
