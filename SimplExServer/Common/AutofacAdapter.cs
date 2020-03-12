using Autofac;

namespace SimplExServer.Common
{
    class AutofacAdapter : IIoCContainer
    {
        private IContainer container;
        public bool IsRegistered<TType>()
        {
            if (container != null)
                return container.IsRegistered<TType>();
            else return false;
        }
        public void Register<TType>()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<TType>().AsSelf();
            Update(containerBuilder);
        }

        public void Register<TType, TImplementation>() where TImplementation : TType
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<TImplementation>().As<TType>();
            Update(containerBuilder);
        }
        public void RegisterInstance<TInstance>(TInstance instance)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Register((a) => instance).AsSelf();
            Update(containerBuilder);
        }
        public TType Resolve<TType>()
        {
            return container.Resolve<TType>();
        }
        private void Update(ContainerBuilder builder)
        {
            if (container != null)
                builder.Update(container);
            else
                container = builder.Build();
        }
    }
}