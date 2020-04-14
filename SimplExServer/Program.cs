using SimplExServer.Common;
using SimplExServer.Controls;
using SimplExServer.Forms;
using SimplExServer.Presenter;
using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer
{
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationContext context = new ApplicationContext();
            ApplicationController controller = (ApplicationController)new ApplicationController(new UnityAdapter())
                .RegisterView<IEditPropertiesView, EditExamControl>()
                .RegisterView<IEditMainView, EditorForm>()
                .RegisterView<IEditTreeView, EditTreeControl>()
                .RegisterView<IEditMarkSystemPropertiesView, EditMarkSystemControl>()
                .RegisterView<IEditFiveStepMarkSystemView, EditFiveStepMarkSystemControl>()
                .RegisterView<IEditThemesView, EditThemesControl>()
                .RegisterView<IEditTicketsView, EditTicketsControl>()
                .RegisterView<IEditThemeView, EditThemeControl>()
                .RegisterView<IEditTicketView, EditTicketControl>()
                .RegisterView<IEditQuestionGroupView, EditQuestionGroupControl>()
                .RegisterView<IEditQuestionView, EditQuestionControl>()
                .RegisterView<IEditOneAnswerQuestionView, EditOneAnswerQuestionControl>()
                .RegisterView<IEditSavingView, EditSaveControl>()
                .RegisterView<ILoadingView, LoadingForm>()
                .RegisterView<ILogInDbView, LogInDbForm>()
                .RegisterView<IStartView, StartForm>()
                .RegisterView<IPasswordEnterView, PasswordEnterForm>()
                .RegisterView<ILoadingContextView, LoadingContextForm>()
                .RegisterView<IImportView, ImportForm>()
                .RegisterView<IStartSessionView, StartSessionForm>()
                .RegisterView<ISessionView, SessionForm>()
                .RegisterView<ISessionInformationView, SessionInformationControl>()
                .RegisterView<IConnectionStatusView, ConnectionStatusControl>()
                .RegisterView<IChatView, ChatControl>()
                .RegisterIntstance(context);
            controller.Run<LoadingPresenter, object>(null);
            Application.Run(context);
        }
    }
}
