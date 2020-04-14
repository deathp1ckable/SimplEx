using System;

namespace SimplExServer.View
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
        bool SaveResults { set; }
        bool TrackStatus { set; }
    }
}
