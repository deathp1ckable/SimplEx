using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class StartSessionPresenter : Presenter<StartSessionArgument, IStartSessionView>
    {
        public StartSessionPresenter(IStartSessionView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.Canceled += ViewCanceled;
        }

        private void ViewCanceled(IStartSessionView sender)
        {
            sender.Close();
        }
    }
}
