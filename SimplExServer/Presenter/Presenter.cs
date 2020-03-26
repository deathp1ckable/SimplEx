using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    abstract class Presenter<TArgumnet, TView> : AbstractPresenter<TArgumnet> where TView : class, IView
    {
        protected new TView View { get; set; }
        protected new IApplicationController ApplicationController { get; set; }
        protected Presenter(TView view, IApplicationController applicationController) : base(view, applicationController)
        {
            View = view;
            ApplicationController = applicationController;
        }
    }
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
