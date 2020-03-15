using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.View;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditTreePresenter : IntegrablePresenter<Exam, IEditTreeView>
    {
        private object copiedObject;
        public EditTreePresenter(IEditTreeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.StructureChanged += StructureChanged;
            view.Searched += Searched;
            view.Copied += Copied;
            view.Pasted += Pasted;
        }
        private void Copied(IEditTreeView sender)
        {

        }
        private void Pasted(IEditTreeView sender)
        {

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
            e.Group.Remove();
            if (e.NewParentGroup != null)
                e.Group.ParentQuestionGroup = e.NewParentGroup;
            else
                e.Group.ParentTicket = e.Ticket;
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
