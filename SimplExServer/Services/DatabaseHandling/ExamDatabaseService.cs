using SimplExDb.Database;
using SimplExServer.Model;
using SimplExServer.Model.Data;
using SimplExServer.Services.DatabaseHandling.Maps;
using System;
using System.Collections.Generic;

namespace SimplExServer.Services.DatabaseHandling
{
    class ExamDatabaseService : IDisposable
    {
        private readonly DatabaseController databaseController = new DatabaseController(new SimplExDBMap());
        public bool IsOpened { get; private set; }
        public int SaveExam(Exam exam)
        {
            databaseController.Insert(exam);
            databaseController.Insert(new MarkSystemData(exam.MarkSystem), exam);
            int i, j;
            for (i = 0; i < exam.Themes.Count; i++)
                databaseController.Insert(exam.Themes[i], exam);
            for (i = 0; i < exam.Tickets.Count; i++)
            {
                databaseController.Insert(exam.Tickets[i], exam);
                for (j = 0; j < exam.Tickets[i].QuestionGroups.Count; j++)
                    SaveQuestionGroup(exam.Tickets[i].QuestionGroups[j]);
            }
            for (i = 0; i < exam.ExecutionResults.Count; i++)
            {
                databaseController.Insert(exam.ExecutionResults[i], exam, exam.ExecutionResults[i].Ticket);
                for (j = 0; j < exam.ExecutionResults[i].Answers.Count; i++)
                    databaseController.Insert(exam.ExecutionResults[i].Answers[j], exam.ExecutionResults[i], exam.ExecutionResults[i].Answers[j].Question);
            }
            databaseController.Commit();
            return databaseController.GetIdentifier(exam).Value;
        }
        public Exam OpenExam(int id)
        {
            Exam result = databaseController.Select<Exam>("ExamID = " + id)[0];
            result.MarkSystem = databaseController.SelectChild<Exam, MarkSystemData>(result)[0].CreateMarkSystem();
            result.Themes = new List<Theme>(databaseController.SelectChild<Exam, Theme>(result));
            result.Tickets = new List<Ticket>(databaseController.SelectChild<Exam, Ticket>(result));
            int i, j;
            for (i = 0; i < result.Tickets.Count; i++)
            {
                result.Tickets[i].QuestionGroups = new List<QuestionGroup>(databaseController.SelectChild<Ticket, QuestionGroup>(result.Tickets[i]));
                for (j = 0; j < result.Tickets[i].QuestionGroups.Count; j++)
                {
                    result.Tickets[i].QuestionGroups[j].ParentTicket = result.Tickets[i];
                    OpenQuestionGroup(result.Tickets[i].QuestionGroups[j]);
                }
            }
            result.ExecutionResults = new List<ExecutionResult>(databaseController.SelectChild<Exam, ExecutionResult>(result));
            for (i = 0; i < result.ExecutionResults.Count; i++)
            {
                result.ExecutionResults[i].Ticket = databaseController.SelectParent<Ticket, ExecutionResult>(result.ExecutionResults[i])[0];
                result.ExecutionResults[i].Answers = new List<ExecutorAnswer>(databaseController.SelectChild<ExecutionResult, ExecutorAnswer>(result.ExecutionResults[i]));
                for (j = 0; j < result.ExecutionResults[i].Answers.Count; j++)
                    result.ExecutionResults[i].Answers[j].Question = databaseController.SelectParent<Question, ExecutorAnswer>(result.ExecutionResults[i].Answers[j])[0];
            }
            return result;
        }
        public int UpdateExam(Exam oldExam, Exam newExam)
        {
            if (!databaseController.IsLoaded(oldExam))
                throw new Exception("Attempting to update unloaded Exam");
            databaseController.Delete(oldExam);
            databaseController.Commit();
            SaveExam(newExam);
            databaseController.Commit();
            return databaseController.GetIdentifier(newExam).Value;
        }
        public void DeleteExam(Exam exam)
        {
            if (!databaseController.IsLoaded(exam))
                throw new Exception("Attempting to delete unloaded Exam");
            databaseController.Delete(exam);
            databaseController.Commit();
        }
        public void DeleteExam(int id)
        {
            Exam exam = databaseController.Select<Exam>("ExamId = " + id)[0];
            databaseController.Delete(exam);
            databaseController.Commit();
        }
        public Question[] GetQuestions(int id)
        {
            Exam loaded = databaseController.Select<Exam>("ExamID = " + id)[0];
            loaded.MarkSystem = databaseController.SelectChild<Exam, MarkSystemData>(loaded)[0].CreateMarkSystem();
            loaded.Themes = new List<Theme>(databaseController.SelectChild<Exam, Theme>(loaded));
            loaded.Tickets = new List<Ticket>(databaseController.SelectChild<Exam, Ticket>(loaded));
            int i, j;
            for (i = 0; i < loaded.Tickets.Count; i++)
            {
                loaded.Tickets[i].QuestionGroups = new List<QuestionGroup>(databaseController.SelectChild<Ticket, QuestionGroup>(loaded.Tickets[i]));
                for (j = 0; j < loaded.Tickets[i].QuestionGroups.Count; j++)
                {
                    loaded.Tickets[i].QuestionGroups[j].ParentTicket = loaded.Tickets[i];
                    OpenQuestionGroup(loaded.Tickets[i].QuestionGroups[j]);
                }
            }
            List<Question> result = new List<Question>();
            for (i = 0; i < loaded.Tickets.Count; i++)
                result.AddRange(loaded.Tickets[i].GetQuestions());
            return result.ToArray();
        }
        public Exam[] GetUnfilledExams() => databaseController.Select<Exam>();
        public void Unload() => databaseController.Unload();
        public int? GetIdentifier(Exam exam) => databaseController.GetIdentifier(exam);
        public bool IsConnected() => databaseController.IsConnected();
        public void Connect(string host, uint port, string user, string password)
        {
            databaseController.Open(host, user, port, password);
            databaseController.OpenSchema();
            IsOpened = true;
        }
        private void SaveQuestionGroup(QuestionGroup group)
        {
            object parent = group.ParentQuestionGroup as object ?? group.ParentTicket as object;
            databaseController.Insert(group, parent);
            int i;
            for (i = 0; i < group.ChildQuestionGroups.Count; i++)
                SaveQuestionGroup(group.ChildQuestionGroups[i]);
            for (i = 0; i < group.Questions.Count; i++)
            {
                QuestionData questionData = new QuestionData(group.Questions[i]);
                databaseController.Insert(questionData, group, group.Questions[i].Theme);
                if (questionData.RightAnswer != null)
                    databaseController.Insert(questionData.RightAnswer, questionData);
            }
        }
        private void OpenQuestionGroup(QuestionGroup parentGroup)
        {
            int i;
            parentGroup.ChildQuestionGroups = new List<QuestionGroup>(databaseController.Select<QuestionGroup>("ParentQuestionGroupId = " + databaseController.GetIdentifier(parentGroup)));
            for (i = 0; i < parentGroup.ChildQuestionGroups.Count; i++)
            {
                parentGroup.ChildQuestionGroups[i].ParentQuestionGroup = parentGroup;
                OpenQuestionGroup(parentGroup.ChildQuestionGroups[i]);
            }
            parentGroup.Questions.Clear();
            QuestionData[] datas = databaseController.Select<QuestionData>("QuestionGroupId = " + databaseController.GetIdentifier(parentGroup));
            for (i = 0; i < datas.Length; i++)
            {
                parentGroup.Questions.Add(datas[i].CreateQuestion());
                parentGroup.Questions[i].ParentQuestionGroup = parentGroup;
                parentGroup.Questions[i].Theme = databaseController.SelectParent<Theme, QuestionData>(datas[i])[0];
                Answer[] answers = databaseController.SelectChild<QuestionData, Answer>(datas[i]);
                if (answers.Length == 1)
                    parentGroup.Questions[i].RightAnswer = answers[0];
            }
        }
        public void Dispose() => databaseController.Dispose();
    }
}
