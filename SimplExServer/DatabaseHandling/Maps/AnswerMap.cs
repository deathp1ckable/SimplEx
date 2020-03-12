using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class AnswerMap : ClassMap<Answer>
    {
        protected override void MapClass()
        {
            MapId("AnswerID");
            Map("QuestionNumber", () => Instance.QuestionNumber, (a) => Instance.QuestionNumber = (int)a);
            Map("TicketNumber", () => Instance.TicketNumber, (a) => Instance.TicketNumber = (int)a);
            Map("Content", () => Instance.Content, (a) => Instance.Content = (string)a);
            Foreign<QuestionData>("QuestionID");
            Table("answers");
        }
    }
}
