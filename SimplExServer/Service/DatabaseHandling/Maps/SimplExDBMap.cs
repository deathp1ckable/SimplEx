using SimplExDb.Database;
using SimplExModel.Model;
using SimplExModel.Model.Data;
using System;
using System.Data;
namespace SimplExServer.Service.DatabaseHandling.Maps
{
    class SimplExDBMap : SchemaMap
    {
        protected override void MapSchema()
        {
            Database("simplexdb");

            MapClass<Exam, ExamMap>();
            MapClass<MarkSystemData, MarkSystemDataMap>();
            MapClass<Theme, ThemeMap>();
            MapClass<Ticket, TicketMap>();
            MapClass<QuestionGroup, QuestionGroupMap>();
            MapClass<QuestionData, QuestionMap>();
            MapClass<Answer, AnswerMap>();
            MapClass<ExecutionResult, ExecutionResultMap>();
            MapClass<ExecutorAnswer, ExecutorAnswerMap>();

            Relation<Exam, MarkSystemData>(Rule.Cascade, Rule.Cascade);
            Relation<Exam, Ticket>(Rule.Cascade, Rule.Cascade);
            Relation<Exam, Theme>(Rule.Cascade, Rule.Cascade);
            Relation<Exam, ExecutionResult>(Rule.Cascade, Rule.Cascade);

            Relation<ExecutionResult, ExecutorAnswer>(Rule.Cascade, Rule.Cascade);
            Relation<Ticket, ExecutionResult>(Rule.Cascade, Rule.Cascade);
            Relation<QuestionData, ExecutorAnswer>(Rule.Cascade, Rule.Cascade);

            Relation<Ticket, QuestionGroup>(Rule.Cascade, Rule.Cascade);
            Relation<QuestionGroup, QuestionGroup>(Rule.Cascade, Rule.Cascade);
            Relation<QuestionGroup, QuestionData>(Rule.Cascade, Rule.Cascade);
            Relation<Theme, QuestionData>(Rule.Cascade, Rule.Cascade);

            Relation<QuestionData, Answer>(Rule.Cascade, Rule.Cascade);

            MapDataType<int>("INT");
            MapDataType<string>("INT");
            MapDataType<double>("DOUBLE");
            MapDataType<DateTime>("DATETIME");
        }
    }
}
