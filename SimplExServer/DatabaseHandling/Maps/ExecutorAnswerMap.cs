using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class ExecutorAnswerMap : ClassMap<ExecutorAnswer>
    {
        protected override void MapClass()
        {
            MapId("ExecutionAnswerID");
            Map("Content", () => Instance.Content, (a) => Instance.Content = a);
            Foreign<ExecutionResult>("ExecutionResultID");
            Foreign<Question>("QuestionID");
            Table("executoranswers");
        }
    }
}
