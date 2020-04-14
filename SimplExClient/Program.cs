using SimplExClient.Common;
using SimplExClient.View;
using SimplExClient.Presenter;
using System;
using System.Windows.Forms;
using SimplExClient.Forms;
using SimplExClient.Controls;

namespace SimplExClient
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationContext context = new ApplicationContext();
            ApplicationController controller = (ApplicationController)new ApplicationController(new UnityAdapter())
                .RegisterView<ILoadingView, LoadingForm>()
                .RegisterView<ILogInView, LogInForm>()
                .RegisterView<IMainView, MainForm>()
                .RegisterView<ILoadingContextView, LoadingContextForm>()
                .RegisterView<ISessionInformationView, SessionInformationControl>()
                .RegisterView<IResultView, ResultForm>()
                .RegisterView<IChatView, ChatControl>()
                .RegisterIntstance(context);
            controller.Run<LoadingPresenter, object>(null);
            Application.Run(context);
        }
    }
    public delegate void Action();
}
