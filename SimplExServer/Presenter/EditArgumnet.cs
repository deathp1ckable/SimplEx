using SimplExServer.Builders;
using SimplExServer.Service;

namespace SimplExServer.Presenter
{
    class EditArgumnet
    {
        public IExamSaver ExamSaver { get; set; }
        public ExamBuilder ExamBuilder { get; private set; }
        public EditArgumnet(IExamSaver examSaver, ExamBuilder examBuilder)
        {
            ExamBuilder = examBuilder;
            ExamSaver = examSaver;
        }
    }
}
