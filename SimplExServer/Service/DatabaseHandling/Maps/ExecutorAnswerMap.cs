using SimplExDb.Database;
using SimplExModel.Model;
using SimplExModel.Model.Data;

namespace SimplExServer.Service.DatabaseHandling.Maps
{
    class ExecutorAnswerMap : ClassMap<ExecutorAnswer>
    {
        protected override void MapClass()
        {
            MapId("ExecutorAnswerID");
            Map("Content", () => Instance.Content, (a) => Instance.Content = a);
            Foreign<ExecutionResult>("ExecutionResultID");
            Foreign<QuestionData>("QuestionID");
            Table("executoranswers");
        }
    }
}
