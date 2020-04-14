using SimplExModel.Model;

namespace SimplExServer.Service
{
    public interface IExamSaver
    {
        string SaverName { get;}
        Exam GetExam();
        bool Save(Exam exam);
        bool Delete();
    }
}
