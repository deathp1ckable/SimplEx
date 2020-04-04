using SimplExDb.Database;
using SimplExServer.Model;
using System;
namespace SimplExServer.Services.DatabaseHandling.Maps
{
    class ExamMap : ClassMap<Exam>
    {
        protected override void MapClass()
        {
            MapId("ExamID");
            Map("Name", () => Instance.Name, (a) => Instance.Name = a);
            Map("Password", () => Instance.Password, (a) => Instance.Password = a);
            Map("Discipline", () => Instance.Discipline, (a) => Instance.Discipline = a);
            Map("CreatorName", () => Instance.CreatorName, (a) => Instance.CreatorName = a);
            Map("CreatorSurname", () => Instance.CreatorSurname, (a) => Instance.CreatorSurname = a);
            Map("CreatorPatronimyc", () => Instance.CreatorPatronimyc, (a) => Instance.CreatorPatronimyc = a);
            Map("CreationDate", () => (DateTime)Instance.CreationDate, (a) => Instance.CreationDate = a);
            Map("LastChangeDate", () => (DateTime)Instance.LastChangeDate, (a) => Instance.LastChangeDate = a);
            Map("Time", () => Instance.Time, (a) => Instance.Time = a);
            Map("FirstNumber", () => Instance.FirstNumber, (a) => Instance.FirstNumber = a);
            Map("Description", () => Instance.Description, (a) => Instance.Description = a);
            Table("exams");
        }
    }
}
