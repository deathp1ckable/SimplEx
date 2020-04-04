using SimplExServer.Model;

namespace SimplExServer.Services
{
    public interface IExamSaver
    {
        string SaverName { get; set; }
        Exam GetExam();
        bool Save(Exam exam);
        bool Delete();
    }
}
