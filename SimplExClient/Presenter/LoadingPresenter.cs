using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
{
    class LoadingPresenter : Presenter<object, ILoadingView>
    {
        public LoadingPresenter(ILoadingView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Loaded += ViewLoaded;
        }
        private void ViewLoaded(ILoadingView sender)
        {
            ApplicationController.Run<LogInPresenter, object>(null);
            View.Close();
        }
    }
}
