using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditTicketPresenter : IntegrablePresenter<EditContentArgumnet, IEditTicketView>
    {
        private TicketBuilder currentTicketBuilder;
        private bool isSaved = true;
        private bool isHiding;
        public EditTicketPresenter(IEditTicketView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Shown += ViewShown;
            view.Deleted += ViewThemeDeleted;
            view.Hiden += ViewHiden;
            view.Saved += ViewSaved;
            view.Changed += ViewChanged;
            view.GroupAdded += ViewGroupAdded;
            view.QuestionWatched += ViewQuestionWatched;
        }
        private void ViewQuestionWatched(IEditTicketView sender) => Argument.EditTreeView.SelectObject(sender.CurrentQuestion);
        private void ViewGroupAdded(IEditTicketView sender)
        {
            QuestionGroupBuilder builder = currentTicketBuilder.AddQuestionGroup("Новая группа вопросов");
            Argument.EditTreeView.RefreshObject(currentTicketBuilder);
            Argument.EditTreeView.SelectObject(builder);
        }
        private void ViewChanged(IEditTicketView sender) => isSaved = false;
        private void ViewSaved(IEditTicketView sender)
        {
            isSaved = true;
            if (currentTicketBuilder != null)
            {
                currentTicketBuilder.TicketName = sender.TicketName;
                currentTicketBuilder.SetNumeration(sender.Questions.ToArray());
                sender.Questions = new List<QuestionBuilder>(currentTicketBuilder.SortedQuestionBuilders);
                Argument.EditTreeView.RefreshObject(currentTicketBuilder);
                if (!isHiding)
                    Argument.EditTreeView.SelectObject(currentTicketBuilder);
            }
        }
        private void ViewHiden(IEditTicketView sender)
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
                currentTicketBuilder = null;
                isSaved = true;
            }
        }
        private void ViewThemeDeleted(IEditTicketView sender)
        {
            isSaved = true;
            if (currentTicketBuilder != null)
            {
                currentTicketBuilder.ParentExamBuilder.RemoveTicket(currentTicketBuilder);
                Argument.EditTreeView.RefreshTickets();
                Argument.EditTreeView.SelectObject(Section.Tickets);
            }
            currentTicketBuilder = null;
            sender.Hide();
        }
        private void ViewShown(IEditTicketView sender)
        {
            if (!isHiding)
            {
                currentTicketBuilder = Argument.EditTreeView.CurrentObject as TicketBuilder;
                if (currentTicketBuilder != null)
                {
                    sender.TicketName = currentTicketBuilder.TicketName;
                    sender.Questions = new List<QuestionBuilder>(currentTicketBuilder.SortedQuestionBuilders);
                    sender.QuestionsCount = currentTicketBuilder.SortedQuestionBuilders.Count;
                    sender.GroupsCount = currentTicketBuilder.GetQuestionGroupBuilders().Length;
                }
                isSaved = true;
            }
        }
    }
}
