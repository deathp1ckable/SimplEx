namespace SimplExClient.Common
{
    interface IIoCContainer
    {
        void Register<TType>();
        void Register<TType, TImplementation>() where TImplementation : TType;
        void RegisterInstance<TInstance>(TInstance instance);
        TType Resolve<TType>();
        bool IsRegistered<TType>();
    }
}