using SimplExServer.Common;
using SimplExServer.Controls;
using SimplExServer.Model;
using SimplExServer.Model.Inherited;
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
                .RegisterView<IEditPropertiesView, EditPropertiesControl>()
                .RegisterView<IEditMainView, EditorForm>()
                .RegisterView<IEditMarkSystemPropertiesView, EditMarkSystemPropertiesControl>()
                .RegisterView<IEditFiveStepMarkSystemView, EditFiveStepMarkSystemControl>()
                .RegisterIntstance(context);
            controller.Run<EditMainPresenter, Exam>(new Exam() { MarkSystem = new FiveStepMarkSystem()});
            Application.Run(context);
        }
    }
}
