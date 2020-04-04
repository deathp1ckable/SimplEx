namespace SimplExServer.View
{
    public interface IStartSessionView : IView
    {
        string GroupName { get; set; }
        bool TrackStatusCheck { get; set; }
        bool SaveResults { get; set; }
        bool MixAnswers { get; set; }
        bool EnableChat { get; set; }
        bool WaitForReconnection { get; set; }
        int ReconnectionTime { get; set; }
        bool TrackViolations { get; set; }
        int ViolationsLimit { get; set; }

        event ViewActionHandler<IStartSessionView> Started;
        event ViewActionHandler<IStartSessionView> Canceled;
    }
}
