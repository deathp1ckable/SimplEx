namespace SimplExServer.View
{
    public interface IEditThemeView : IHideableView
    {
        string ThemeName { get; set; }
        int QuestionsCount { set; }

        event ViewActionHandler<IEditThemeView> Deleted;
        event ViewActionHandler<IEditThemeView> Saved;
        event ViewActionHandler<IEditThemeView> Changed;
        event ViewActionHandler<IEditThemeView> Shown;
        event ViewActionHandler<IEditThemeView> Hiden;
        void AskForSaving();
    }
}
