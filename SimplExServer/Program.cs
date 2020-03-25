using SimplExServer.Builders;
using SimplExServer.Common;
using SimplExServer.Controls;
using SimplExServer.Forms;
using SimplExServer.Model;
using SimplExServer.Model.Inherited;
using SimplExServer.Presenter;
using SimplExServer.View;
using System;
using System.Collections.Generic;
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
                .RegisterView<IEditTreeView, EditTreeControl>()
                .RegisterView<IEditMarkSystemPropertiesView, EditMarkSystemControl>()
                .RegisterView<IEditFiveStepMarkSystemView, EditFiveStepMarkSystemControl>()
                .RegisterView<IEditThemesView, EditThemesControl>()
                .RegisterView<IEditTicketsView, EditTicketsControl>()
                .RegisterView<IEditThemeView, EditThemeControl>()
                .RegisterIntstance(context);
            ExamBuilder examBuilder = new ExamBuilder();
            controller.Run<EditMainPresenter, ExamBuilder>(examBuilder);
            Application.Run(context);
        }
    }
}
