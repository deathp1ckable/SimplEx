using SimplExDb.Database;
using SimplExModel.Model;
namespace SimplExServer.Service.DatabaseHandling.Maps
{
    class ThemeMap : ClassMap<Theme>
    {
        protected override void MapClass()
        {
            MapId("ThemeID");
            Map("ThemeNumber", () => Instance.ThemeNumber, (a) => Instance.ThemeNumber = a);
            Map("ThemeName", () => Instance.ThemeName, (a) => Instance.ThemeName = a);
            Foreign<Exam>("ExamID");
            Table("themes");
        }
    }
}
