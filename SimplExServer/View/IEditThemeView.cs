namespace SimplExServer.View
{
    public interface IEditThemeView : IIntegrableView
    {
        string ThemeName { get; set; }
        int QuestionsCount { set; }
        event ViewActionHandler<IEditThemeView> ThemeDeleted;
        event ViewActionHandler<IEditThemeView> Changed;
        event ViewActionHandler<IEditThemeView> Saved;
        event ViewActionHandler<IEditThemeView> Shown;
        event ViewActionHandler<IEditThemeView> Hiden;
        void AskForSaving();
    }
}
