using System;

namespace SimplExServer.Builders
{
    public interface IBuilder<T>
    {
        T Instance { get; }
        T GetBuildedInstance();
        void Reset(); 
        void Load(T instance);
    }
}