using SimplExClient.Forms;

namespace SimplExClient.View
{
    public interface ILoadingContextView : IHideableView
    {
        void Invoke(Action action);
    }
}
