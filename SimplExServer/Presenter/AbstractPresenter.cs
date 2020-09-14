using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    abstract class AbstractPresenter<TArgument> : IPresenter<TArgument>
    {
        protected TArgument Argument { get; set; }
        protected IView View { get; set; }
        protected IApplicationController ApplicationController { get; set; }
        protected AbstractPresenter(IView view, IApplicationController applicationController)
        {
            View = view;
            ApplicationController = applicationController;
        }
        public virtual void Run(TArgument argument)
        {
            Argument = argument;
            View.Show();
        }
    }
}
