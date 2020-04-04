using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class LoadingPresenter : Presenter<object, ILoadingView>
    {
        public LoadingPresenter(ILoadingView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Loaded += ViewLoaded;
        }
        private void ViewLoaded(ILoadingView sender)
        {
            ApplicationController.Run<StartPresenter, object>(null);
            View.Close();
        }
    }
}
