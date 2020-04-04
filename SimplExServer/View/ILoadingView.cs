namespace SimplExServer.View
{
    public interface ILoadingView : IView
    {
        event ViewActionHandler<ILoadingView> Loaded;
    }
}
