using SimplExModel.Model;

namespace SimplExServer.Service
{
    interface IExamDocXWorker
    {
        void OpenBlank(Exam exam, Ticket ticket, bool markAnswers);
        void OpenTask(Exam exam, Ticket ticket, bool markAnswers);
        void OpenResult(Exam exam, ExecutionResult executionResult);
    }
}