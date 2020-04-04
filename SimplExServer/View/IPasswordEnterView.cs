namespace SimplExServer.View
{
    public interface IPasswordEnterView : IHideableView
    {
        string Password { get; set; }

        event ViewActionHandler<IPasswordEnterView> Entered;
        event ViewActionHandler<IPasswordEnterView> Canceled;
    }
}
