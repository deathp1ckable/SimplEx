using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.View;
namespace SimplExServer.Presenter
{
    class EditTicketsPresenter : IntegrablePresenter<EditContentArgumnet, IEditTicketsView>
    {
        public EditTicketsPresenter(IEditTicketsView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.TicketAdded += ViewTicketAdded;
            view.Shown += ViewShown;       
        }
        private void ViewShown(IEditTicketsView sender) => sender.TicketsCount = Argument.ExamBuilder.TicketBuilders.Count;
        private void ViewTicketAdded(IEditTicketsView sender)
        {
            TicketBuilder builder = Argument.ExamBuilder.AddTicket("Новый билет");
            Argument.EditTreeView.RefreshTickets();
            Argument.EditTreeView.SelectObject(builder);
        }
    }
}
