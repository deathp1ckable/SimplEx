namespace SimplExServer.View
{
    public interface IEditTicketsView : IIntegrableView
    {
        event ViewActionHandler<IEditTicketsView> TicketAdded; 
    }
}
