using SimplExClient.Common;
using SimplExClient.View;
using SimplExClient.Presenter;
using System;
using System.Windows.Forms;

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
                .RegisterIntstance(context);
            controller.Run<LoadingPresenter, object>(null);
            Application.Run(context);
        }
    }
}
