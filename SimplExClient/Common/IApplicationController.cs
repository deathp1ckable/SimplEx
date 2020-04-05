using SimplExClient.Presenter;
using SimplExClient.View;
namespace SimplExClient.Common
{
    interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>() where TImplementation : class, TView where TView : IView;
        IApplicationController RegisterModel<TModel, TImplementation>() where TImplementation : TModel;
        IApplicationController RegisterIntstance<T>(T instance);
        TPresenter Run<TPresenter, TArgumnent>(TArgumnent argumnent) where TPresenter : AbstractPresenter<TArgumnent>;
    }
}