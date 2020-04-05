namespace SimplExClient.Presenter
{
    interface IPresenter<in TArgument>
    {
        void Run(TArgument argument);
    }
}