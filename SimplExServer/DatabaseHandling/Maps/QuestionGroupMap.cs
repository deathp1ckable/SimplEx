using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class QuestionGroupMap : ClassMap<QuestionGroup>
    {
        protected override void MapClass()
        {
            MapId("QuestionGroupID");
            Map("QuestionGroupName", () => Instance.QuestionGroupName, (a) => Instance.QuestionGroupName = a);
            Foreign<Ticket>("TicketID");
            Foreign<QuestionGroup>("ParentQuestionGroupID", true);
            Table("questiongroups");
        }
    }
}
