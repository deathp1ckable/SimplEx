using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.Services.DatabaseHandling.Maps
{
    class QuestionGroupMap : ClassMap<QuestionGroup>
    {
        protected override void MapClass()
        {
            MapId("QuestionGroupID");
            Map("QuestionGroupName", () => Instance.QuestionGroupName, (a) => Instance.QuestionGroupName = a);
            Foreign<Ticket>("TicketID", true);
            Foreign<QuestionGroup>("ParentQuestionGroupID", true);
            Table("questiongroups");
        }
    }
}
