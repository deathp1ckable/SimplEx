using SimplExModel.NetworkData;
using System;

namespace SimplExServer.View
{
    public interface IConnectionStatusView : IHideableView
    {
        string ConnectionName { set; }
        string ConnectionSurname { set; }
        string ConnectionPatronimyc { set; }
        string TicketName { set; }

        bool TrackStatus { get; set; }

        ClientStatus ClientStatus { set; }

        void AddStatus(int currentQuestion, int executedAnswers, double offset);
        void ClearStatuses();

        bool TrackViolations { get; set; }
        string ViolationContent { get; set; }

        void AddViolation(string content, double offset);
        void ClearViolations();

        double Points { set; }
        double Mark { set; }

        void Invoke(Action action);

        event ViewActionHandler<IConnectionStatusView> ViolationAdded;
        event ViewActionHandler<IConnectionStatusView> Disconnected;
        event ViewActionHandler<IConnectionStatusView> ResultOpened;
        event ViewActionHandler<IConnectionStatusView> Shown;
        event ViewActionHandler<IConnectionStatusView> Hiden;

    }
}
