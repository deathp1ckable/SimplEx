namespace SimplExClient.View
{
    public interface ILogInView : IHideableView
    {
        bool AllowConnect { get; set; }
        string ViewName { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }

        event ViewActionHandler<ILogInView> Connected;

        void ShowError(string message);
        void Invoke(Action action);
    }
}
