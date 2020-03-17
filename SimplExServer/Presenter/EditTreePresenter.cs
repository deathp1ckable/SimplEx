using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.View;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditTreePresenter : IntegrablePresenter<Exam, IEditTreeView>
    {
        public EditTreePresenter(IEditTreeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.StructureChanged += StructureChanged;
            view.Searched += Searched;
        }
        private void Searched(IEditTreeView sender)
        {
            List<object> result = new List<object>();
            result.AddRange(sender.Themes.Where(a => a.ToString().Contains(sender.SearchText)));
            result.AddRange(sender.Tickets.Where(a => a.ToString().Contains(sender.SearchText)));
            for (int i = 0; i < sender.Tickets.Count; i++)
            {
                result.AddRange(sender.Tickets[i].GetQuestionGroups().Where(a => a.ToString().Contains(sender.SearchText)));
                result.AddRange(sender.Tickets[i].GetQuestions().Where(a => a.ToString().Contains(sender.SearchText)));
            }
            sender.SearchResult = result.ToArray();
        }

        private void StructureChanged(IEditTreeView sender, StructChangedArgs e)
        {
            e.Group.ParentQuestionGroup?.ChildQuestionGroups.Remove(e.Group);
            e.Group.ParentTicket?.QuestionGroups.Remove(e.Group);
            e.Group.ParentTicket = null;
            e.Group.ParentQuestionGroup = null;
            if (e.NewParentGroup != null)
            {
                e.Group.ParentQuestionGroup = e.NewParentGroup;
                e.NewParentGroup.ChildQuestionGroups.Add(e.Group);
            }
            else
            {
                e.Group.ParentTicket = e.Ticket;
                e.Ticket.QuestionGroups.Add(e.Group);
            }
            Argumnet.Themes = sender.Themes;
            Argumnet.Tickets = sender.Tickets;
        }
        public override void Run(Exam argument)
        {
            Argumnet = argument;
            View.Themes = Argumnet.Themes;
            View.Tickets = Argumnet.Tickets;
        }
    }
}
