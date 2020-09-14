using SimplExModel.Model;
using System.Collections.Generic;

namespace SimplExServer.Service
{
    public interface IExamSaver
    {
        string LastExceptionMessage { get; }
        string SaverName { get; }
        Exam GetExam();
        IList<Question> GetQuestions();
        bool Save(Exam exam);
        bool SaveResult(ExecutionResult executionResult);
        bool DeleteResult(ExecutionResult executionResult);
        bool Delete();
    }
}
