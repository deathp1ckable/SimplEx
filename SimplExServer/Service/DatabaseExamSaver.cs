using SimplExModel.Model;
using SimplExServer.Service.DatabaseHandling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimplExServer.Service
{
    class DatabaseExamSaver : IExamSaver
    {
        private int? id;

        public string LastExceptionMessage { get; private set; }
        public string SaverName { get; private set; }

        public DatabaseExamSaver(int? id, string name)
        {
            this.id = id;
            SaverName = name;
        }
        public Exam GetExam()
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;
            try
            {
                if (id == null)
                    return null;
                if (databaseWorker != null)
                {
                    databaseWorker.Unload();
                    Exam result = databaseWorker.GetExam(id.Value);
                    SaverName = result.Name;
                    return result;
                }
                else
                {
                    LastExceptionMessage = "Подкючение к базе данных не установлено.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return null;
            }
        }
        public IList<Question> GetQuestions()
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;
            try
            {
                if (id == null)
                    return null;
                if (databaseWorker != null)
                {
                    databaseWorker.Unload();
                    Question[] result = databaseWorker.GetQuestions(id.Value);
                    return result.ToList();
                }
                else
                {
                    LastExceptionMessage = "Подкючение к базе данных не установлено.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return null;
            }
        }
        public bool Save(Exam exam)
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;
            try
            {
                if (databaseWorker != null)
                {
                    if (id == null)
                        databaseWorker.Unload();
                    if (id != null)
                        databaseWorker.DeleteExam(id.Value);
                    id = databaseWorker.SaveExam(exam);
                    SaverName = exam.Name;
                    return true;
                }
                else
                {
                    LastExceptionMessage = "Подкючение к базе данных не установлено.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public bool SaveResult(ExecutionResult executionResult)
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;
            try
            {
                if (id == null)
                    return false;
                if (databaseWorker != null)
                {
                    databaseWorker.SaveResult(id.Value, executionResult);
                    return true;
                }
                else
                {
                    LastExceptionMessage = "Подкючение к базе данных не установлено.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public bool DeleteResult(ExecutionResult executionResult)
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;
            try
            {
                if (id == null)
                    return false;
                if (databaseWorker != null)
                {
                    databaseWorker.DeleteResult(id.Value, executionResult);
                    return true;
                }
                else
                {
                    LastExceptionMessage = "Подкючение к базе данных не установлено.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public bool Delete()
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;
            try
            {
                if (id == null)
                    return false;
                if (databaseWorker != null)
                {
                    databaseWorker.DeleteExam(id.Value);
                    databaseWorker.Unload();
                    return true;
                }
                else
                {
                    LastExceptionMessage = "Подкючение к базе данных не установлено.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                LastExceptionMessage = ex.Message;
                return false;
            }
        }
        public override bool Equals(object obj) => obj is DatabaseExamSaver saver && id == saver.id;
        public override int GetHashCode() => 1877310944 + id.GetHashCode();
    }
}
