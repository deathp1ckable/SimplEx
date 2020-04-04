namespace SimplExServer.View
{
    public interface IEditThemesView : IHideableView
    {
        int ThemesCount { set; }

        event ViewActionHandler<IEditThemesView> Shown;
        event ViewActionHandler<IEditThemesView> ThemeAdded;
    }
}
