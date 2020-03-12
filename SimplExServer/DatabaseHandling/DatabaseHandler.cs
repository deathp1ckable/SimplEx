using SimplExDb.Database;
using SimplExServer.Model;
using SimplExServer.DatabaseHandling.Maps;
using System;
using System.Data;

namespace SimplExServer.DatabaseHandling
{
    public class DatabaseHandler : IDisposable
    {
        public DatabaseController controller;
        public void Open()
        {
            controller = new DatabaseController(new SimplExDBMap());
            controller.Open("127.0.0.1", "root", 3306, "123");
        }
        public void AddExam(Exam exam)
        {
            controller.Insert(exam);
            controller.Insert(exam.MarkSystem, exam);
            for (int i = 0; i < exam.Themes.Length; i++)
                controller.Insert(exam.Themes[i], exam);
            for (int i = 0, j; i < exam.Tickets.Length; i++)
            {
                controller.Insert(exam.Tickets[i], exam);
                for (j = 0; j < exam.Tickets[i].QuestionGroups.Length; j++)
                {
                    AddGroup(exam.Tickets[i].QuestionGroups[j], exam.Tickets[i]);
                }
            }
            for (int i = 0, j; i < exam.ExecutionResults.Length; i++)
            {
                controller.Insert(exam.ExecutionResults[i], exam);
                for (j = 0; j < exam.ExecutionResults[i].Answers.Length; j++)
                    controller.Insert(exam.ExecutionResults[i].Answers[j], exam.ExecutionResults[i]);
            }
            controller.Commit();
        }
        private void AddGroup(QuestionGroup questionGroup, Ticket owner)
        {
            int i;
            controller.Insert(questionGroup, owner);
            for (i = 0; i < questionGroup.Questions.Length; i++)
            {
                controller.Insert(
                   questionGroup.Questions[i],
                   questionGroup,
                   questionGroup.Questions[i].QuestionTheme);
                controller.Insert(questionGroup.Questions[i].RightAnswer, questionGroup.Questions[i]);
            }
            if (questionGroup.ChildQuestionGroups != null && questionGroup.ChildQuestionGroups.Length > 0)
                for (i = 0; i < questionGroup.ChildQuestionGroups.Length; i++)
                    AddGroup(questionGroup.ChildQuestionGroups[i], owner);
        }
        private void GetGroup(QuestionGroup group, QuestionGroup parentGroup)
        {
            int i;
            group.ParentQuestionGroup = parentGroup;
            group.Questions = controller.SelectChild<QuestionGroup, Question>(group);
            for (i = 0; i < group.Questions.Length; i++)
                group.Questions[i].RightAnswer = controller.SelectChild<Question, Answer>(group.Questions[i])[0];
            group.ChildQuestionGroups = controller.SelectChild<QuestionGroup, QuestionGroup>(group);
            if (group.ChildQuestionGroups.Length > 0)
                for (i = 0; i < group.ChildQuestionGroups.Length; i++)
                    GetGroup(group.ChildQuestionGroups[i], group);
        }
        public Exam GetExam(string filter = "true")
        {
            Exam result = controller.Select<Exam>(filter)[0];
            result.MarkSystem = controller.SelectChild<Exam, MarkSystem>(result)[0];
            result.Themes = controller.SelectChild<Exam, Theme>(result);
            result.Tickets = controller.SelectChild<Exam, Ticket>(result);
            for (int i = 0, j; i < result.Tickets.Length; i++)
            {
                result.Tickets[i].QuestionGroups = controller.SelectChild<Ticket, QuestionGroup>(result.Tickets[i], "ParentQuestionGroupID IS NULL");
                for (j = 0; j < result.Tickets[i].QuestionGroups.Length; j++)
                    GetGroup(result.Tickets[i].QuestionGroups[j], result.Tickets[i].QuestionGroups[j].ParentQuestionGroup);
            }
            result.ExecutionResults = controller.SelectChild<Exam, ExecutionResult>(result);
            for (int i = 0; i < result.ExecutionResults.Length; i++)
                result.ExecutionResults[i].Answers = controller.SelectChild<ExecutionResult, ExecutorAnswer>(result.ExecutionResults[i]);
            return result;
        }
        public void SaveExam(Exam exam)
        {
        }
        public void RemoveExam(Exam exam)
        {
            controller.Delete(exam);
            controller.Commit();
        }
        public void Dispose()
        {
        }
    }
}
