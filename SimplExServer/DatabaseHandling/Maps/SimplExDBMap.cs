using SimplExDb.Database;
using SimplExServer.Model;
using System.Data;
namespace SimplExServer.DatabaseHandling.Maps
{
    class SimplExDBMap : SchemaMap
    {
        protected override void MapSchema()
        {
            Database("simplexdb");
            MapClass<Exam, ExamMap>();
            MapClass<MarkSystemData, MarkSystemMap>();
            MapClass<Theme, ThemeMap>();
            MapClass<Ticket, TicketMap>();
            MapClass<QuestionGroup, QuestionGroupMap>();
            MapClass<QuestionData, QuestionMap>();
            MapClass<Answer, AnswerMap>();
            MapClass<ExecutionResult, ExecutionResultMap>();
            MapClass<ExecutorAnswer, ExecutorAnswerMap>();

            Relation<ExamMap, MarkSystemData>(Rule.Cascade, Rule.Cascade);
            Relation<ExamMap, Ticket>(Rule.Cascade, Rule.Cascade);
            Relation<ExamMap, Theme>(Rule.Cascade, Rule.Cascade);
            Relation<ExamMap, ExecutionResult>(Rule.Cascade, Rule.Cascade);

            Relation<ExecutionResult, ExecutorAnswer>(Rule.Cascade, Rule.Cascade);

            Relation<Ticket, QuestionGroup>(Rule.Cascade, Rule.Cascade);
            Relation<QuestionGroup, QuestionGroup>(Rule.Cascade, Rule.Cascade);
            Relation<QuestionGroup, QuestionData>(Rule.Cascade, Rule.Cascade);
            Relation<Theme, QuestionData>(Rule.Cascade, Rule.Cascade);

            Relation<QuestionData, Answer>(Rule.Cascade, Rule.Cascade);
            MapDataType<int>("INT");
            MapDataType<double>("DOUBLE");
            MapDataType<string>("LONGTEXT");
        }
    }
}
