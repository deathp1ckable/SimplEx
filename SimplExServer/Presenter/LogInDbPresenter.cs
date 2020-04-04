using SimplExServer.Common;
using SimplExServer.Services;
using SimplExServer.View;
using System.Threading.Tasks;

namespace SimplExServer.Presenter
{
    class LogInDbPresenter : Presenter<object, ILogInDbView>
    {
        public LogInDbPresenter(ILogInDbView view, IApplicationController applicationController) : base(view, applicationController)
        {
            view.LoggedIn += ViewLoggedIn;
            view.Skipped += ViewSkipped;
            view.Host = "127.0.0.1";
            view.Port = 3306;
            view.Username = "root";
        }
        private void ViewSkipped(ILogInDbView sender)
        {
            View.Close();
        }
        private async void ViewLoggedIn(ILogInDbView sender)
        {
            DatabaseService databaseService = DatabaseService.GetInstance();
            await Task.Run(() => databaseService.Connect(sender.Host, sender.Port, sender.Username, sender.Password));
            if (databaseService.ExamDatabaseWorker != null)
                View.Close();
            else
                sender.ShowError("Не удалось подключится к базе данных.");
        }
    }
}
