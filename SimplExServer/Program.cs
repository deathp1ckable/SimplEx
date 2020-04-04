using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.Controls;
using SimplExServer.Forms;
using SimplExServer.Model;
using SimplExServer.Presenter;
using SimplExServer.View;
using System;
using System.Windows.Forms;

namespace SimplExServer
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
            ApplicationController controller = (ApplicationController)new ApplicationController(new AutofacAdapter())
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
                .RegisterIntstance(context);
            controller.Run<LoadingPresenter, object>(null);
            Application.Run(context);
        }
    }
}
