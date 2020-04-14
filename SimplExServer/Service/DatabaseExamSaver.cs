using SimplExModel.Model;
using SimplExServer.Service.DatabaseHandling;
using System;

namespace SimplExServer.Service
{
    class DatabaseExamSaver : IExamSaver
    {
        private int? id;

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
                    Exam result = databaseWorker.OpenExam(id.Value);
                    SaverName = result.Name;
                    return result;
                }
                else return null;
            }
            catch
            {
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
                    return false;
            }
            catch
            {
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
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public override bool Equals(object obj) => obj is DatabaseExamSaver saver && id == saver.id;
        public override int GetHashCode() => 1877310944 + id.GetHashCode();
    }
}
