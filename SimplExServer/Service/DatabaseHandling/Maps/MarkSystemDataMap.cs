using SimplExDb.Database;
using SimplExModel.Model;
using SimplExModel.Model.Data;

namespace SimplExServer.Service.DatabaseHandling.Maps
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
