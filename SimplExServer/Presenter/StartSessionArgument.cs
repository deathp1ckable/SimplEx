using SimplExServer.Model;
using SimplExServer.Services;

namespace SimplExServer.Presenter
{
    class StartSessionArgument
    {
        public Exam Exam { get; private set; }
        public IExamSaver ExamSaver { get; private set; }
        public StartSessionArgument(Exam exam, IExamSaver examSaver)
        {
            Exam = exam;
            ExamSaver = examSaver;
        }
    }
}
