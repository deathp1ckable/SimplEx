using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
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
}
