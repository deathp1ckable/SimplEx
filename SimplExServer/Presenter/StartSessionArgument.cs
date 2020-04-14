using SimplExModel.Model;
using SimplExServer.Service;

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
