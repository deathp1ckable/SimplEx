using SimplExServer.Common;
using SimplExServer.View;
using System;

namespace SimplExServer.Presenter
{
    abstract class IntegrablePresenter<TArgument, TView> : Presenter<TArgument, TView> where TView : class, IView
    {
        protected IntegrablePresenter(TView view, IApplicationController applicationController) : base(view, applicationController) { }
        public void Integrate(Action<TView> integrator) => integrator(View);
    }
}
