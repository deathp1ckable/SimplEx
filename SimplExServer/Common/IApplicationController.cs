using SimplExServer.Presenter;
using SimplExServer.View;
using System.Threading.Tasks;

namespace SimplExServer.Common
{
    interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>() where TImplementation : class, TView where TView : IView;
        IApplicationController RegisterModel<TModel, TImplementation>() where TImplementation : TModel;
        IApplicationController RegisterIntstance<T>(T instance);
        TPresenter Run<TPresenter, TArgumnent>(TArgumnent argumnent) where TPresenter : AbstractPresenter<TArgumnent>;
    }
}