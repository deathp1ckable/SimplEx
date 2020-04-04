namespace SimplExServer.View
{
    public interface ILogInDbView : IView
    {
        string Host { get; set; }
        uint Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        event ViewActionHandler<ILogInDbView> LoggedIn;
        event ViewActionHandler<ILogInDbView> Skipped;
        void ShowError(string message);
    }
}
