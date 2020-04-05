using SimplExClient.Presenter;
using SimplExClient.View;
namespace SimplExClient.Common
{
    class ApplicationController : IApplicationController
    {
        private readonly IIoCContainer container;

        public ApplicationController(IIoCContainer container)
        {
            this.container = container;
            container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterIntstance<T>(T instance)
        {
            container.RegisterInstance(instance);
            return this;
        }

        public IApplicationController RegisterModel<TModel, TImplementation>() where TImplementation : TModel
        {
            container.Register<TModel, TImplementation>();
            return this;
        }

        public TPresenter Run<TPresenter, TArgumnent>(TArgumnent argumnent) where TPresenter : AbstractPresenter<TArgumnent>
        {
            if (!container.IsRegistered<TPresenter>())
                container.Register<TPresenter>();
            TPresenter presenter = container.Resolve<TPresenter>();
            presenter.Run(argumnent);
            return presenter;
        }

        public IApplicationController RegisterView<TView, TImplementation>() where TImplementation : class, TView where TView : IView
        {
            container.Register<TView, TImplementation>();
            return this;
        }
    }
}