using SimplExClient.View;
using SimplExClient.Service;

namespace SimplExClient.Presenter
{
    class ClientArgument
    {
        public Client Client { get; private set; }
        public IMainView MainView { get; private set; }
        public ClientArgument(Client client, IMainView mainView)
        {
            Client = client;
            MainView = mainView;
        }
    }
}
