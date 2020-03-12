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
                .RegisterView<IEditTreeView, EditTreeControl>()
                .RegisterView<IEditMarkSystemPropertiesView, EditMarkSystemPropertiesControl>()
                .RegisterView<IEditFiveStepMarkSystemView, EditFiveStepMarkSystemControl>()
                .RegisterIntstance(context);
            QuestionGroup group = new QuestionGroup()
            {
                QuestionGroupName = "This group",
                ChildQuestionGroups = new QuestionGroup[0],
                Questions = new[]
                {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                }
            };
            QuestionGroup secondGroup = new QuestionGroup()
            {
                QuestionGroupName = "This two group",
                ChildQuestionGroups = new QuestionGroup[0],
                Questions = new[]
    {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                }
            };
            QuestionGroup anotherGroup = new QuestionGroup()
            {
                QuestionGroupName = "This another",
                ChildQuestionGroups = new QuestionGroup[0],
                Questions = new[]
                {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion()
                }
            };
            group.ChildQuestionGroups = new[] { anotherGroup };
            anotherGroup.ParentQuestionGroup = group;
            controller.Run<EditMainPresenter, Exam>(new Exam()
            {
                MarkSystem = new FiveStepMarkSystem(),
                Themes = new[]
                {
                    new Theme() { ThemeName = "Theme one" }, new Theme() { ThemeName = "Theme two" } },
                Tickets = new[] { new Ticket() {TicketNumber =1, QuestionGroups = new[]
                    {
                        group,secondGroup
                    }
                }
               }
            });
            Application.Run(context);
        }
    }
}
