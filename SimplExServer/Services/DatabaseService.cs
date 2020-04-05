using SimplExServer.Model;
using SimplExServer.Services.DatabaseHandling;
using System;

namespace SimplExServer.Services
{
    class DatabaseService
    {
        private static DatabaseService instance;
        private ExamDatabaseService examDatabaseWorker;
        public ExamDatabaseService ExamDatabaseWorker
        {
            get
            {
                if (examDatabaseWorker != null && examDatabaseWorker.IsConnected())
                    return examDatabaseWorker;
                else
                {
                    if (examDatabaseWorker != null)
                    {
                        examDatabaseWorker.Dispose();
                        ConnctionLosted?.Invoke(this, new EventArgs());
                    }
                    examDatabaseWorker = null;
                    return examDatabaseWorker;
                }
            }
        }

        public event EventHandler ConnctionLosted;
        public event EventHandler ConnctionEstablished;

        public string Host { get; private set; }
        public uint Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        private DatabaseService() { }
        public void Connect(string host, uint port, string username, string password)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            if (examDatabaseWorker != null)
                examDatabaseWorker.Dispose();
            examDatabaseWorker = new ExamDatabaseService();
            try
            {
                examDatabaseWorker.Connect(host, port, username, password);
                ConnctionEstablished?.Invoke(this, new EventArgs());
            }
            catch
            {
                examDatabaseWorker = null;
            }
        }
        public IExamSaver[] GetExamSavers()
        {
            if (examDatabaseWorker == null)
                return new IExamSaver[0];
            try
            {
                Exam[] exams = examDatabaseWorker.GetUnfilledExams();
                IExamSaver[] examSavers = new IExamSaver[exams.Length];
                for (int i = 0; i < exams.Length; i++)
                    examSavers[i] = new DatabaseExamSaver(examDatabaseWorker.GetIdentifier(exams[i]).Value, this, exams[i].Name);
                return examSavers;
            }
            catch
            {
                examDatabaseWorker.Dispose();
                return new IExamSaver[0];
            }
        }
        public static DatabaseService GetInstance()
        {
            if (instance == null)
                instance = new DatabaseService();
            return instance;
        }
    }
}
