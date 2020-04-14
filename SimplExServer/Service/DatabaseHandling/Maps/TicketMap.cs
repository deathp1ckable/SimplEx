using SimplExDb.Database;
using SimplExModel.Model;
namespace SimplExServer.Service.DatabaseHandling.Maps
{
    class TicketMap : ClassMap<Ticket>
    {
        protected override void MapClass()
        {
            MapId("TicketID");
            Map("TicketNumber", () => Instance.TicketNumber, (a) => Instance.TicketNumber = a);
            Map("TicketName", () => Instance.TicketName, (a) => Instance.TicketName = a);
            Foreign<Exam>("ExamID");
            Table("tickets");
        }
    }
}
