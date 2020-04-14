using SimplExDb.Database;
using SimplExModel.Model;
using SimplExModel.Model.Data;

namespace SimplExServer.Service.DatabaseHandling.Maps
{
    class AnswerMap : ClassMap<Answer>
    {
        protected override void MapClass()
        {
            MapId("AnswerID");
            Map("Content", () => Instance.Content, (a) => Instance.Content = a);
            Foreign<QuestionData>("QuestionID");
            Table("answers");
        }
    }
}
