using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class QuestionMap : ClassMap<QuestionData>
    {
        protected override void MapClass()
        {
            MapId("QuestionID");
            Map("QuestionNumber", () => Instance.QuestionNumber, (a) => Instance.QuestionNumber = (int)a);
            Map("TicketNumber", () => Instance.TicketNumber, (a) => Instance.TicketNumber = (int)a);
            Map("Content", () => Instance.Content, (a) => Instance.Content = (string)a);
            Map("QuestionType", () => Instance.QuestionTypeName, (a) => Instance.QuestionTypeName = (string)a);
            Map("Points", () => Instance.Points, (a) => Instance.Points = (double)a);
            Foreign<Theme>("ThemeID");
            Foreign<QuestionGroup>("QuestionGroupID");
            Table("questions");
        }
    }
}
