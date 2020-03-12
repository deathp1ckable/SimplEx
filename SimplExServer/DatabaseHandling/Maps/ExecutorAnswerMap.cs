using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class ExecutorAnswerMap : ClassMap<ExecutorAnswer>
    {
        protected override void MapClass()
        {
            MapId("ExecutionAnswerID");
            Map("QuestionNumber", () => Instance.QuestionNumber, (a) => Instance.QuestionNumber = (int)a);
            Map("TicketNumber", () => Instance.TicketNumber, (a) => Instance.TicketNumber = (int)a);
            Map("Content", () => Instance.Content, (a) => Instance.Content = (string)a);
            Foreign<ExecutionResult>("ExecutionResultID");
            Table("executoranswers");
        }
    }
}
