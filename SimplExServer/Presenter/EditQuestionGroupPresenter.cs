using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExModel.Model;
using SimplExModel.Model.Inherited;
using SimplExServer.View;
using System;

namespace SimplExServer.Presenter
{
    class EditQuestionGroupPresenter : IntegrablePresenter<EditContentArgumnet, IEditQuestionGroupView>
    {
        private QuestionGroupBuilder currentQuestionGroupBuider;
        private bool isSaved = true;
        private bool isHiding;
        public EditQuestionGroupPresenter(IEditQuestionGroupView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Changed += ViewChanged;
            view.Deleted += ViewDeleted;
            view.Shown += ViewShown;
            view.Hiden += ViewHiden;
            view.QuestionAdded += ViewQuestionAdded;
            view.GroupAdded += ViewGroupAdded;
            view.Saved += ViewSaved;
            view.Import += ViewImport;
        }

        private void ViewImport(IEditQuestionGroupView sender)
        {
            Question result = null;
            ApplicationController.Run<ImportPresenter, Action<Question>>((a) => result = a);
            if (result != null)
            {
                QuestionBuilder builder = currentQuestionGroupBuider.AddQuestion(result);
                Argument.EditTreeView.RefreshObject(currentQuestionGroupBuider);
                Argument.EditTreeView.SelectObject(builder);
            }
        }

        private void ViewSaved(IEditQuestionGroupView sender)
        {
            isSaved = true;
            if (currentQuestionGroupBuider != null)
            {
                currentQuestionGroupBuider.QuestionGroupName = sender.GroupName;
                Argument.EditTreeView.RefreshObject(currentQuestionGroupBuider);
                if (!isHiding)
                    Argument.EditTreeView.SelectObject(currentQuestionGroupBuider);
            }
        }

        private void ViewGroupAdded(IEditQuestionGroupView sender)
        {
            QuestionGroupBuilder builder = currentQuestionGroupBuider.AddQuestionGroup("Новая группа вопросов");
            Argument.EditTreeView.RefreshObject(currentQuestionGroupBuider);
            Argument.EditTreeView.SelectObject(builder);
        }

        private void ViewQuestionAdded(IEditQuestionGroupView sender)
        {
            if (sender.QuestionType == typeof(OneAnswerQuestionBuilder))
            {
                QuestionBuilder builder = currentQuestionGroupBuider.AddQuestion(new OneAnswerQuestion());
                Argument.EditTreeView.RefreshObject(currentQuestionGroupBuider);
                Argument.EditTreeView.SelectObject(builder);
            }
        }
        private void ViewHiden(IEditQuestionGroupView sender)
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
                currentQuestionGroupBuider = null;
                isSaved = true;
            }
        }

        private void ViewChanged(IEditQuestionGroupView sender) => isSaved = false;
        public override void Run(EditContentArgumnet argument)
        {
            Argument = argument;
            View.QuestionTypes = new[] { typeof(OneAnswerQuestionBuilder) };
            View.QuestionType = typeof(OneAnswerQuestionBuilder);
        }
        private void ViewDeleted(IEditQuestionGroupView sender)
        {
            isSaved = true;
            if (currentQuestionGroupBuider != null)
            {
                currentQuestionGroupBuider.ParentQuestionGroupBuilder?.RemoveQuestionGroup(currentQuestionGroupBuider);
                currentQuestionGroupBuider.ParentTicketBuilder?.RemoveQuestionGroup(currentQuestionGroupBuider);
                Argument.EditTreeView.RefreshObject(currentQuestionGroupBuider.ParentQuestionGroupBuilder as object ?? currentQuestionGroupBuider.ParentTicketBuilder as object);
                Argument.EditTreeView.SelectObject(currentQuestionGroupBuider.ParentQuestionGroupBuilder as object ?? currentQuestionGroupBuider.ParentTicketBuilder as object);
            }
            currentQuestionGroupBuider = null;
            sender.Hide();
        }
        private void ViewShown(IEditQuestionGroupView sender)
        {
            if (!isHiding)
            {
                currentQuestionGroupBuider = Argument.EditTreeView.CurrentObject as QuestionGroupBuilder;
                if (currentQuestionGroupBuider != null)
                {
                    sender.GroupName = currentQuestionGroupBuider.QuestionGroupName;
                    sender.QuestionsCount = currentQuestionGroupBuider.GetQuestionBuilders().Length;
                    sender.GroupsCount = currentQuestionGroupBuider.GetQuestionGroupBuilders().Length;
                }
                isSaved = true;
            }
        }
    }
}
