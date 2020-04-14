using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditOneAnswerQuestionPresenter : IntegrablePresenter<EditContentArgumnet, IEditOneAnswerQuestionView>
    {
        private OneAnswerQuestionBuilder currentOneAnswerQuestionBuilder;
        private bool isSaved = true; 
        private bool isHiding;
        public EditOneAnswerQuestionPresenter(IEditOneAnswerQuestionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.Changed += ViewChanged;
            view.Saved += ViewSaved;
        }

        private void ViewSaved(IEditOneAnswerQuestionView sender)
        {
            isSaved = true;
            if (currentOneAnswerQuestionBuilder != null)
            {
                currentOneAnswerQuestionBuilder.Text = sender.QuestionText;
                currentOneAnswerQuestionBuilder.Points = sender.Points;
                currentOneAnswerQuestionBuilder.Devider = sender.Devider;
                currentOneAnswerQuestionBuilder.Answers = sender.Answers.ToList();
                currentOneAnswerQuestionBuilder.Letters = sender.Letters;
                currentOneAnswerQuestionBuilder.RightAnswerIndex = sender.RightAnswerIndex;
                Argument.EditTreeView.RefreshObject(currentOneAnswerQuestionBuilder);
                if (!isHiding)
                    Argument.EditTreeView.SelectObject(currentOneAnswerQuestionBuilder);
            }
        }

        private void ViewChanged(IEditOneAnswerQuestionView sender) => isSaved = false;
        private void ViewHiden(IEditOneAnswerQuestionView sender)
        {
            if (!isHiding)
            {
                if (!isSaved)
                {
                    isHiding = true;
                    View.Show();
                    sender.AskForSaving();
                    View.Hide();
                    isHiding = false;
                }
                currentOneAnswerQuestionBuilder = null;
                isSaved = true;
            }
        }
        private void ViewShown(IEditOneAnswerQuestionView sender)
        {
            if (!isHiding)
            {
                currentOneAnswerQuestionBuilder = Argument.EditTreeView.CurrentObject as OneAnswerQuestionBuilder;
                if (currentOneAnswerQuestionBuilder != null)
                {
                    sender.QuestionText = currentOneAnswerQuestionBuilder.Text;
                    sender.Points = currentOneAnswerQuestionBuilder.Points;
                    sender.Devider = currentOneAnswerQuestionBuilder.Devider;
                    sender.Answers = currentOneAnswerQuestionBuilder.Answers;
                    sender.Letters = currentOneAnswerQuestionBuilder.Letters;
                    sender.RightAnswerIndex = currentOneAnswerQuestionBuilder.RightAnswerIndex;
                }
                isSaved = true;
            }
        }
    }
}
