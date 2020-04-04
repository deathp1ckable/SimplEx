using SimplExServer.Model;
using SimplExServer.Services.DatabaseHandling;

namespace SimplExServer.Services
{
    class DatabaseExamSaver : IExamSaver
    {
        private int? id;
        private DatabaseService databaseService;

        public string SaverName { get; set; }

        public DatabaseExamSaver(int? id, DatabaseService databaseService, string name)
        {
            this.id = id;
            this.databaseService = databaseService;
            SaverName = name;
        }
        public Exam GetExam()
        {
            ExamDatabaseWorker databaseWorker = databaseService.ExamDatabaseWorker;        
            try
            {
                if (id == null)
                    return null;
                if (databaseWorker != null)
                    return databaseWorker.OpenExam(id.Value);
                else return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Save(Exam exam)
        {
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
