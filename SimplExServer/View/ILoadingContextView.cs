using System;
using System.Threading.Tasks;

namespace SimplExServer.View
{
    public interface ILoadingContextView : IView
    {
        void AwaitTask(Task task);
        void Invoke(Action action);
    }
}
