using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
{
    class LogInPresenter : Presenter<object, ILogInView>
    {
        public LogInPresenter(ILogInView view, IApplicationController applicationController) : base(view, applicationController)
        {
        }
    }
}
