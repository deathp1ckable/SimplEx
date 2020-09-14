namespace SimplExServer.Service
{
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
