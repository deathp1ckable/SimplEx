using SimplExServer.Common;
using SimplExServer.Service;
using SimplExServer.View;

namespace SimplExServer.Presenter
{
    class SessionInformationPresenter : IntegrablePresenter<Session, ISessionInformationView>
    {
        public SessionInformationPresenter(ISessionInformationView view, IApplicationController applicationController) : base(view, applicationController)
        {
        }
        public override void Run(Session argument)
        {
            Argument = argument;
            View.ExamName = Argument.Exam.Name;
            View.Discipline = Argument.Exam.Discipline;
            View.Description = Argument.Exam.Description;
            View.CreatorName = Argument.Exam.CreatorName;
            View.CreatorSurname = Argument.Exam.CreatorSurname;
            View.CreatorPatronymic = Argument.Exam.CreatorPatronymic;
            View.ExaminationTime = Argument.Exam.Time;
            View.FirstQuestionNumber = Argument.Exam.FirstNumber;
            View.MarkSystemType = Argument.Exam.MarkSystem.GetType();
            View.MarkSystemDescription = Argument.Exam.Description;
            View.TeacherName = Argument.TeacherName;
            View.TeacherSurname = Argument.TeacherSurname;
            View.TeacherPatronymic = Argument.TeacherPatronymic;
            View.GroupName = Argument.GroupName;
            View.ReconnectionTime = Argument.ReconnectionTime;
            View.ViolationsLimit = Argument.ViolationsLimit;
            View.EnableChat = Argument.EnableChat;
            View.Mixing = Argument.Mixing;
            View.SaveResults = !(Argument.ExamSaver is null);
            View.TrackStatus = Argument.TrackStatus;
        }
    }
}
