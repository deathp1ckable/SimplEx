using SimplExDb.Database;
using SimplExServer.Model;
using SimplExServer.DatabaseHandling.Maps;
using System;
using System.Collections.Generic;

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
            for (int i = 0; i < exam.Themes.Count; i++)
                controller.Insert(exam.Themes[i], exam);
            for (int i = 0, j; i < exam.Tickets.Count; i++)
            {
                controller.Insert(exam.Tickets[i], exam);
                for (j = 0; j < exam.Tickets[i].QuestionGroups.Count; j++)
                {
                    AddGroup(exam.Tickets[i].QuestionGroups[j], exam.Tickets[i]);
                }
            }
            for (int i = 0, j; i < exam.ExecutionResults.Count; i++)
            {
                controller.Insert(exam.ExecutionResults[i], exam);
                for (j = 0; j < exam.ExecutionResults[i].Answers.Count; j++)
                    controller.Insert(exam.ExecutionResults[i].Answers[j], exam.ExecutionResults[i]);
            }
            controller.Commit();
        }
        private void AddGroup(QuestionGroup questionGroup, Ticket owner)
        {
            int i;
            controller.Insert(questionGroup, owner);
            for (i = 0; i < questionGroup.Questions.Count; i++)
            {
                controller.Insert(
                   questionGroup.Questions[i],
                   questionGroup,
                   questionGroup.Questions[i].QuestionTheme);
                controller.Insert(questionGroup.Questions[i].RightAnswer, questionGroup.Questions[i]);
            }
            if (questionGroup.ChildQuestionGroups != null && questionGroup.ChildQuestionGroups.Count > 0)
                for (i = 0; i < questionGroup.ChildQuestionGroups.Count; i++)
                    AddGroup(questionGroup.ChildQuestionGroups[i], owner);
        }
        private void GetGroup(QuestionGroup group, QuestionGroup parentGroup)
        {
            int i;
            group.ParentQuestionGroup = parentGroup;
            group.Questions = new List<Question>(controller.SelectChild<QuestionGroup, Question>(group));
            for (i = 0; i < group.Questions.Count; i++)
                group.Questions[i].RightAnswer = controller.SelectChild<Question, Answer>(group.Questions[i])[0];
            group.ChildQuestionGroups = new List<QuestionGroup>(controller.SelectChild<QuestionGroup, QuestionGroup>(group));
            if (group.ChildQuestionGroups.Count > 0)
                for (i = 0; i < group.ChildQuestionGroups.Count; i++)
                    GetGroup(group.ChildQuestionGroups[i], group);
        }
        public Exam GetExam(string filter = "true")
        {
            Exam result = controller.Select<Exam>(filter)[0];
            result.MarkSystem = controller.SelectChild<Exam, MarkSystem>(result)[0];
            result.Themes = new List<Theme>(controller.SelectChild<Exam, Theme>(result));
            result.Tickets = new List<Ticket>(controller.SelectChild<Exam, Ticket>(result));
            for (int i = 0, j; i < result.Tickets.Count; i++)
            {
                result.Tickets[i].QuestionGroups = new List<QuestionGroup>(controller.SelectChild<Ticket, QuestionGroup>(result.Tickets[i], "ParentQuestionGroupID IS NULL"));
                for (j = 0; j < result.Tickets[i].QuestionGroups.Count; j++)
                    GetGroup(result.Tickets[i].QuestionGroups[j], result.Tickets[i].QuestionGroups[j].ParentQuestionGroup);
            }
            result.ExecutionResults = new List<ExecutionResult>(controller.SelectChild<Exam, ExecutionResult>(result));
            for (int i = 0; i < result.ExecutionResults.Count; i++)
                result.ExecutionResults[i].Answers = new List<ExecutorAnswer>(controller.SelectChild<ExecutionResult, ExecutorAnswer>(result.ExecutionResults[i]));
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
