namespace SimplExServer.Service
{
    class DocXService
    {
        private static DocXService instance;
        public IExamDocXWorker ExamDocXWorker { get; private set; }
        private DocXService()  {    }
        public static DocXService GetInstance()
        {
            if (instance == null)
                instance = new DocXService();
            return instance;
        }
        public static void SetExamDocXWorker(IExamDocXWorker examDocXWorker)
        {
            if (instance == null)
                instance = new DocXService();
            if (instance.ExamDocXWorker == null)
                instance.ExamDocXWorker = examDocXWorker;
        }
    }
}
