using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class TicketMap : ClassMap<Ticket>
    {
        protected override void MapClass()
        {
            MapId("TicketID");
            Map("TicketNumber", () => Instance.TicketNumber, (a) => Instance.TicketNumber = a);
            Map("TicketName", () => Instance.TicketName, (a) => Instance.TicketName = a);
            Foreign<ExamMap>("ExamID");
            Table("tickets");
        }
    }
}
