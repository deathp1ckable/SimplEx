namespace SimplExServer.View
{
    public interface IEditThemesView : IIntegrableView
    {
        event ViewActionHandler<IEditThemesView> ThemeAdded;
    }
}
