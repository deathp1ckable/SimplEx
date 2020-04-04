using SimplExServer.Common;
using SimplExServer.View;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class LoadingContextPresnter<TResult> : Presenter<Task<TResult>, ILoadingContextView>
    {
        public LoadingContextPresnter(ILoadingContextView view, IApplicationController applicationController) : base(view, applicationController) { }
        public override void Run(Task<TResult> argument)
        {
            Argument = argument;
            View.AwaitTask(argument);
            View.Show();
        }
        public Task<TResult> GetTask() => Argument;
    }
}