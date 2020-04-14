using SimplExModel.Model;
using SimplExServer.Service;
using SimplExServer.Service.DatabaseHandling;
using System;

namespace SimplExServer.Service
{
    class DatabaseService
    {
        private static DatabaseService instance;
        private ExamDatabaseWorker examDatabaseWorker;
        public ExamDatabaseWorker ExamDatabaseWorker
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
                        ConnctionLosted?.Invoke(this, EventArgs.Empty);
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
            {
                examDatabaseWorker.Dispose();
                ConnctionLosted?.Invoke(this, EventArgs.Empty);
            }
            examDatabaseWorker = new ExamDatabaseWorker();
            try
            {
                examDatabaseWorker.Connect(host, port, username, password);
                ConnctionEstablished?.Invoke(this, EventArgs.Empty);
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
                    examSavers[i] = new DatabaseExamSaver(examDatabaseWorker.GetIdentifier(exams[i]).Value, exams[i].Name);
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
    class SessionService
    {
        private static SessionService instance;
        public Session Session { get; set; }
        private SessionService()
        { }
        public static SessionService GetInstance()
        {
            if (instance == null)
                instance = new SessionService();
            return instance;
        }
    }
}
