using SimplExModel.Model;
using System;

namespace SimplExModel.NetworkData
{
    public class ServerConnectionData
    {
        public Exam Exam { get; private set; }

        public string GroupName { get; private set; }

        public string TeacherName { get; private set; }
        public string TeacherSurname { get; private set; }
        public string TeacherPatronymic { get; private set; }

        public bool EnableChat { get; private set; }
        public bool TrackStatus { get; private set; }
        public bool Mixing { get; private set; }
        public int ViolationLimit { get; private set; }
        public double ReconnectionTime { get; private set; }

        public ServerConnectionData(Exam exam, string groupName, string teacherName, string teacherSurname, string teacherPatronymic, bool enableChat, bool trackStatus, bool mixing, int violationLimit, double reconnectionTime)
        {
            Exam = exam ?? throw new ArgumentNullException(nameof(exam));
            GroupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            TeacherName = teacherName ?? throw new ArgumentNullException(nameof(teacherName));
            TeacherSurname = teacherSurname ?? throw new ArgumentNullException(nameof(teacherSurname));
            TeacherPatronymic = teacherPatronymic ?? throw new ArgumentNullException(nameof(teacherPatronymic));
            EnableChat = enableChat;
            TrackStatus = trackStatus;
            Mixing = mixing;
            ViolationLimit = violationLimit;
            ReconnectionTime = reconnectionTime;
        }
    }
}
