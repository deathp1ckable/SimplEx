using SimplExDb.Database;
using SimplExModel.Model;
namespace SimplExServer.Service.DatabaseHandling.Maps
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
