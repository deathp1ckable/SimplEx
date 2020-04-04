using SimplExDb.Database;
using SimplExServer.Model;
using System;
namespace SimplExServer.Services.DatabaseHandling.Maps
{
    class ExecutionResultMap : ClassMap<ExecutionResult>
    {
        protected override void MapClass()
        {
            MapId("ExecutionResultID");
            Map("ExecutorName", () => Instance.ExecutorName, (a) => Instance.ExecutorName = a);
            Map("ExecutorSurname", () => Instance.ExecutorSurname, (a) => Instance.ExecutorSurname = a);
            Map("ExecutorPatronimyc", () => Instance.ExecutorPatronimyc, (a) => Instance.ExecutorPatronimyc = a);
            Map("ExecutorGroup", () => Instance.ExecutorGroup, (a) => Instance.ExecutorGroup = a);
            Map("ExecutionDate", () => (DateTime)Instance.ExecutionDate, (a) => Instance.ExecutionDate = a);
            Map("ExecutionTime", () => Instance.ExecutionTime, (a) => Instance.ExecutionTime =a);
            Map("Mark", () => Instance.Mark, (a) => Instance.Mark = a);
            Foreign<Exam>("ExamID");
            Foreign<Ticket>("TicketID");
            Table("executionresults");
        }
    }
}
