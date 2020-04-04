using SimplExServer.Common;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    internal class EditDetachedWindowPresnter : Presenter<IIntegrableView, IEditDetachedView>
    {
        public EditDetachedWindowPresnter(IEditDetachedView view, IApplicationController applicationController) : base(view, applicationController)
        {
        }
        public override void Run(IIntegrableView argument)
        {
            Argument = argument;
            View.SetView(Argument);
            View.Show();
        }
    }
}