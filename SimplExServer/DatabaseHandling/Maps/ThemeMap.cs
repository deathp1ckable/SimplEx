using SimplExDb.Database;
using SimplExServer.Model;
namespace SimplExServer.DatabaseHandling.Maps
{
    class ThemeMap : ClassMap<Theme>
    {
        protected override void MapClass()
        {
            MapId("ThemeID");
            Map("ThemeName", () => Instance.ThemeName, (a) => Instance.ThemeName = (string)a);
            Foreign<ExamMap>("ExamID");
            Table("themes");
        }
    }
}
