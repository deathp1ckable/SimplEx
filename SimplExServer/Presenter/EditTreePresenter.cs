using SimplExServer.Common;
using SimplExServer.Model;
using SimplExServer.View;
using System.Linq;

namespace SimplExServer.Presenter
{
    class EditTreePresenter : IntegrablePresenter<Exam, IEditTreeView>
    {
        public EditTreePresenter(IEditTreeView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.StructureChanged += StructureChanged; ;
        }

        private void StructureChanged(IEditTreeView sender, StructChangedArgs e)
        {
            e.Group.ParentQuestionGroup?.ChildQuestionGroups.Remove(e.Group);
            e.Group.ParentQuestionGroup = e.NewParentGroup;
            if (e.NewParentGroup != null)
                e.NewParentGroup.ChildQuestionGroups.Add(e.Group);
            else
                e.Ticket.QuestionGroups.Add(e.Group);
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
