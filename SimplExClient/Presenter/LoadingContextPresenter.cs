using SimplExClient.Common;
using SimplExClient.View;

namespace SimplExClient.Presenter
{
    class LoadingContextPresenter : IntegrablePresenter<object, ILoadingContextView>
    {
        public LoadingContextPresenter(ILoadingContextView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(object argument)
        {
        }
    }
}