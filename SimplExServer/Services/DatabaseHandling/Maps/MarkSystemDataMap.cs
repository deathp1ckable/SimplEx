using SimplExDb.Database;
using SimplExServer.Model;
using SimplExServer.Model.Data;

namespace SimplExServer.Services.DatabaseHandling.Maps
{
    class MarkSystemDataMap : ClassMap<MarkSystemData>
    {
        protected override void MapClass()
        {
            MapId("MarkSystemID");
            Map("MarkSystemType", () => Instance.MarkSystemTypeName, (a) => Instance.MarkSystemTypeName = a);
            Map("Content", () => Instance.Content, (a) => Instance.Content = a);
            Map("Description", () => Instance.Description, (a) => Instance.Description = a);
            Foreign<Exam>("ExamID");
            Table("marksystems");
        }
    }
}
