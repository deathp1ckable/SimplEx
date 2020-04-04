namespace SimplExServer.View
{
    public interface IEditTicketsView : IHideableView
    {
        int TicketsCount { set; }
        event ViewActionHandler<IEditTicketsView> TicketAdded; 
        event ViewActionHandler<IEditTicketsView> Shown; 
    }
}
