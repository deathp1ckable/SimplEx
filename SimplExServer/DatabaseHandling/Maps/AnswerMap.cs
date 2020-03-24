using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
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
