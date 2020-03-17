namespace SimplExServer.Model.Builders
{
    interface IBuilder<T>
    {
        void Reset();
        T GetBuildedInstance();
    }
}
