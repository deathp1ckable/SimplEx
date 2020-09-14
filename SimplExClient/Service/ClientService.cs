namespace SimplExClient.Service
{
    class ClientService
    {
        private static ClientService instance;
        public Client Client { get; set; }
        private ClientService()
        { }
        public static ClientService GetInstance()
        {
            if (instance == null)
                instance = new ClientService();
            return instance;
        }
    }
}
