using SimplExDb.Database;
using SimplExServer.Model;
using SimplExServer.Model.Data;

namespace SimplExServer.Services.DatabaseHandling.Maps
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
