using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
{
    abstract class AbstractPresenter<TArgumnet> : IPresenter<TArgumnet>
    {
        protected TArgumnet Argument { get; set; }
        protected IView View { get; set; }
        protected IApplicationController ApplicationController { get; set; }
        protected AbstractPresenter(IView view, IApplicationController applicationController)
        {
            View = view;
            ApplicationController = applicationController;
        }
        public virtual void Run(TArgumnet argument)
        {
            Argument = argument;
            View.Show();
        }
    }
}
