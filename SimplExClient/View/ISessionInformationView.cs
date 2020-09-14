using SimplExModel.Model;
using SimplExModel.NetworkData;
using System;
using System.Collections.Generic;

namespace SimplExClient.View
{
    public interface ISessionInformationView : IHideableView
    {
        string ExamName { set; }
        string Discipline { set; }
        string Description { set; }
        string CreatorName { set; }
        string CreatorSurname { set; }
        string CreatorPatronymic { set; }
        double ExaminationTime { set; }
        int FirstQuestionNumber { set; }

        double MinPoints { set; }
        double MaxPoints { set; }

        double MinMark { set; }
        double MaxMark { set; }

        Type MarkSystemType { set; }
        string MarkSystemDescription { set; }

        string TeacherName { set; }
        string TeacherSurname { set; }
        string TeacherPatronymic { set; }

        string GroupName { set; }
        double ReconnectionTime { set; }
        int ViolationsLimit { set; }
        bool EnableChat { set; }
        bool Mixing { set; }
        bool TrackStatus { set; }

        IList<Ticket> Tickets { set; }

        string ConnectionName { get; set; }
        string ConnectionSurname { get; set; }
        string ConnectionPatronymic { get; set; }
        Ticket CurrentTicket { get; set; }

        ClientStatus ClientStatus { set; }
        int CurrentQuestionNumber { set; }
        int ExecutedQuestions { set; }

        IList<string> Violations { set; }
        void Invoke(Action action);

        event ViewActionHandler<ISessionInformationView> Shown;
        event ViewActionHandler<ISessionInformationView> ClientDataChanged;
    }
}

