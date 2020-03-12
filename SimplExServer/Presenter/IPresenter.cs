namespace SimplExServer.Presenter
{
    interface IPresenter<in TArgument>
    {
        void Run(TArgument argument);
    }
}