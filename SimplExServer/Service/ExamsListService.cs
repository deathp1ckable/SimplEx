using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimplExServer.Service
{
    class ExamsListService
    {
        private static ExamsListService instance;
        private List<IExamSaver> examSavers = new List<IExamSaver>();
        private IExamSaver[] DbExamSavers;
        public event EventHandler ListRefreshed;
        public ReadOnlyCollection<IExamSaver> ExamSavers { get; private set; }
        private ExamsListService()
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            databaseService.ConnctionEstablished += DatabaseServiceConnctionEstablished;
            databaseService.ConnctionLosted += DatabaseServiceConnctionLosted;
            ExamSavers = new ReadOnlyCollection<IExamSaver>(examSavers);
        }
        public static ExamsListService GetInstance()
        {
            if (instance == null)
                instance = new ExamsListService();
            return instance;
        }
        public bool Remove(IExamSaver item)
        {
            bool result = examSavers.Remove(item);
            ListRefreshed?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public void Add(IExamSaver item)
        {
            examSavers.Add(item);
            ListRefreshed?.Invoke(this, EventArgs.Empty);
        }

        public bool Contains(IExamSaver item)
        {
            bool result = examSavers.Contains(item);
            ListRefreshed?.Invoke(this, EventArgs.Empty);
            return result;
        }

        public int IndexOf(IExamSaver item)
        {
            int result = examSavers.IndexOf(item);
            ListRefreshed?.Invoke(this, EventArgs.Empty);
            return result;
        }
        private void DatabaseServiceConnctionEstablished(object sender, EventArgs e)
        {
            IExamSaver[] examSavers = (sender as DatabaseService).GetExamSavers();
            DbExamSavers = examSavers;
            this.examSavers.AddRange(DbExamSavers);
            ListRefreshed?.Invoke(this, EventArgs.Empty);
        }
        private void DatabaseServiceConnctionLosted(object sender, EventArgs e)
        {
            for (int i = 0; i < DbExamSavers.Length; i++)
                examSavers.Remove(DbExamSavers[i]);
            ListRefreshed?.Invoke(this, EventArgs.Empty);
        }
    }
}
