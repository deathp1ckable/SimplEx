using SimplExDb.Database;
using SimplExServer.Model;
using System;
namespace SimplExServer.DatabaseHandling.Maps
{
    class ExecutionResultMap : ClassMap<ExecutionResult>
    {
        protected override void MapClass()
        {
            MapId("ExecutionResultID");
            Map("ExecutorName", () => Instance.ExecutorName, (a) => Instance.ExecutorName = (string)a);
            Map("ExecutorSurname", () => Instance.ExecutorSurname, (a) => Instance.ExecutorSurname = (string)a);
            Map("ExecutorPatronimyc", () => Instance.ExecutorPatronimyc, (a) => Instance.ExecutorPatronimyc = (string)a);
            Map("ExecutorGroup", () => Instance.ExecutorGroup, (a) => Instance.ExecutorGroup = (string)a);
            Map("ExecutionDate", () => Instance.ExecutionDate.ToString(), (a) => Instance.ExecutionDate = DateTime.Parse(a.ToString()));
            Map("ExecutionTime", () => Instance.ExecutionTime, (a) => Instance.ExecutionTime = (double)a);
            Map("Mark", () => Instance.Mark, (a) => Instance.Mark = (double)a);
            Foreign<ExamMap>("ExamID");
            Table("executionresults");
        }
    }
}
