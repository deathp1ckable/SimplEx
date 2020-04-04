using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class PasswordEnterPresenter : IntegrablePresenter<object, IPasswordEnterView>
    {
        public PasswordEnterPresenter(IPasswordEnterView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(object argument) { }
    }
}
