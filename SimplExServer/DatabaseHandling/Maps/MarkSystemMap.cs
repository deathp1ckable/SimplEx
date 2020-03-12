using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class MarkSystemMap : ClassMap<MarkSystemData>
    {
        protected override void MapClass()
        {
            MapId("MarkSystemID");
            Map("MarkSystemType", () => Instance.MarkSystemTypeName, (a) => Instance.MarkSystemTypeName = (string)a);
            Map("Content", () => Instance.Content, (a) => Instance.Content = (string)a);
            Map("Description", () => Instance.Description, (a) => Instance.Description = (string)a);
            Foreign<ExamMap>("ExamID");
            Table("marksystems");
        }
    }
}
