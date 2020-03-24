using System;
namespace SimplExServer.Builders
{
    public abstract class Builder<T> : IBuilder<T>
    {
        public T Instance { get; protected set; }
        public abstract void Reset();
        public virtual T GetBuildedInstance()
        {
            T result = Instance;
            Reset();
            return result;
        }
        public virtual void Load(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException();
            Reset();
            Instance = instance;
        }
    }
}
