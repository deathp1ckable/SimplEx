namespace SimplExServer.View
{
    public interface IView
    {
        void Show();
        void Close();
    }
    public delegate void ViewActionHandler<T>(T sender) where T : IView;
}
