using System;

namespace SimplExServer.View
{
    public interface IStartSessionView : IHideableView
    {
        string GroupName { get; set; }

        string TeacherName { get; set; }
        string TeacherSurname { get; set; }
        string TeacherPatronymic { get; set; }

        bool TrackStatusCheck { get; set; }
        bool SaveResults { get; set; }
        bool Mixing { get; set; }
        bool EnableChat { get; set; }

        int ReconnectionTime { get; set; }
        int ViolationsLimit { get; set; }

        event ViewActionHandler<IStartSessionView> Started;
        event ViewActionHandler<IStartSessionView> Canceled;

        void ShowError(string message);
        void Invoke(Action action);
    }
}
