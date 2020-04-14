using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditQuestionPresenter : IntegrablePresenter<EditContentArgumnet, IEditQuestionView>
    {
        private QuestionBuilder currentQuestionBuilder; 
        private bool isHiding;
        public EditQuestionPresenter(IEditQuestionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.ThemeChanged += ViewThemeChanged;
            view.Deleted += ViewDeleted;
        }
        public override void Run(EditContentArgumnet argument)
        {
            Argument = argument;
            View.EditOneAnswerQuestionView = ApplicationController.Run<EditOneAnswerQuestionPresenter, EditContentArgumnet>(Argument).View;
        }
        private void ViewDeleted(IEditQuestionView sender)
        {
            if (currentQuestionBuilder != null)
            {
                currentQuestionBuilder.ParentQuestionGroupBuilder.RemoveQuestion(currentQuestionBuilder);
                Argument.EditTreeView.RefreshObject(currentQuestionBuilder.ParentQuestionGroupBuilder);
                Argument.EditTreeView.SelectObject(currentQuestionBuilder.ParentQuestionGroupBuilder);
            }
            currentQuestionBuilder = null;
            sender.Hide();
        }
        private void ViewThemeChanged(IEditQuestionView sender) => currentQuestionBuilder.ThemeBuilder = sender.Theme;
        private void ViewHiden(IEditQuestionView sender)
        {
            if (!isHiding)
            {
                isHiding = true;
                View.Show();
                currentQuestionBuilder = null;
                HideViews();
                View.Hide();
                isHiding = false;
            }
        }

        private void ViewShown(IEditQuestionView sender)
        {
            if (!isHiding)
            {
                currentQuestionBuilder = Argument.EditTreeView.CurrentObject as QuestionBuilder;
                if (currentQuestionBuilder != null)
                {
                    sender.Themes = Argument.ExamBuilder.ThemeBuilders.ToArray();
                    sender.Theme = currentQuestionBuilder.ThemeBuilder;
                    sender.QuestionType = currentQuestionBuilder.GetType();
                    sender.QuestionNumber = currentQuestionBuilder.QuestionNumber + 1;
                    HideViews();
                    if (currentQuestionBuilder is OneAnswerQuestionBuilder)
                    {
                        View.EditOneAnswerQuestionView.Show();
                    }
                }
            }
        }
        private void HideViews()
        {
            View.EditOneAnswerQuestionView.Hide();
        }
    }
}
