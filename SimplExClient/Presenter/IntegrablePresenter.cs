using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
{
    abstract class IntegrablePresenter<TArgument, TView> : Presenter<TArgument, TView> where TView : class, IHideableView
    {
        public new TView View => base.View;
        protected IntegrablePresenter(TView view, IApplicationController applicationController) : base(view, applicationController) { }
    }
}
