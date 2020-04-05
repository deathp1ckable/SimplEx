using Microsoft.Practices.Unity;

namespace SimplExClient.Common
{
    class UnityAdapter : IIoCContainer
    {
        UnityContainer unityContainer = new UnityContainer();
        public bool IsRegistered<TType>()
        {
            return unityContainer.IsRegistered<TType>();
        }
        public void Register<TType>()
        {
            unityContainer.RegisterType<TType>();
        }
        public void Register<TType, TImplementation>() where TImplementation : TType
        {
            unityContainer.RegisterType<TType, TImplementation>();
        }
        public void RegisterInstance<TInstance>(TInstance instance)
        {
            unityContainer.RegisterInstance(instance);
        }
        public TType Resolve<TType>()
        {
            return unityContainer.Resolve<TType>();
        }
    }
}