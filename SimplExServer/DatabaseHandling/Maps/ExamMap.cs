using SimplExDb.Database;
using SimplExServer.Model;
using System;
namespace SimplExServer.DatabaseHandling.Maps
{
    class ExamMap : ClassMap<Exam>
    {
        protected override void MapClass()
        {
            MapId("ExamID");
            Map("Name", () => Instance.ExamName, (a) => Instance.ExamName = a);
            Map("Password", () => Instance.Password, (a) => Instance.Password = a);
            Map("Discipline", () => Instance.Discipline, (a) => Instance.Discipline = a);
            Map("CreatorName", () => Instance.CreatorName, (a) => Instance.CreatorName = a);
            Map("CreatorSurname", () => Instance.CreatorSurname, (a) => Instance.CreatorSurname = a);
            Map("CreatorPatronimyc", () => Instance.CreatorPatronimyc, (a) => Instance.CreatorPatronimyc = a);
            Map("CreationDate", () => Instance.CreationDate.ToString(), (a) => Instance.CreationDate = DateTime.Parse(a.ToString()));
            Map("LastChangeDate", () => Instance.LastChangeDate.ToString(), (a) => Instance.LastChangeDate = DateTime.Parse(a.ToString()));
            Map("Time", () => Instance.ExaminationTime, (a) => Instance.ExaminationTime = a);
            Map("FirstNumber", () => Instance.FirstNumber, (a) => Instance.FirstNumber = a);
            Map("Description", () => Instance.Description, (a) => Instance.Description = a);
            Table("exams");
        }
    }
}
