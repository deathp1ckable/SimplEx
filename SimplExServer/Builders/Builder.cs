using System;
namespace SimplExServer.Builders
{
    public abstract class Builder<T> : IBuilder<T>
    {
        public T Instance { get; protected set; }
        public abstract void Reset();
        public abstract T GetBuildedInstance();
        public virtual void Load(T instance)
        {
            if (instance == null)
                throw new ArgumentNullException();
            Reset();
            Instance = instance;
        }
    }
}
