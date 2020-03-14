using SimplExServer.Common;
using SimplExServer.Controls;
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
                .RegisterView<IEditMarkSystemPropertiesView, EditMarkSystemPropertiesControl>()
                .RegisterView<IEditFiveStepMarkSystemView, EditFiveStepMarkSystemControl>()
                .RegisterIntstance(context);
            QuestionGroup group = new QuestionGroup()
            {
                QuestionGroupName = "This group",
                Questions = new List<Question>
                {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                }
            };
            QuestionGroup secondGroup = new QuestionGroup()
            {
                QuestionGroupName = "This two group",
                Questions = new List<Question>
                {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                }
            };
            QuestionGroup threeGroup = new QuestionGroup()
            {
                QuestionGroupName = "This 3 two group",
                Questions = new List<Question>
                {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                }
            };
            QuestionGroup anotherGroup = new QuestionGroup()
            {
                QuestionGroupName = "This another",
                Questions = new List<Question>
                {
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion(),
                    new OneAnswerQuestion()
                }
            };
            group.ChildQuestionGroups = new List<QuestionGroup> { anotherGroup, threeGroup };
            threeGroup.ParentQuestionGroup = group;
            anotherGroup.ParentQuestionGroup = group;
            controller.Run<EditMainPresenter, Exam>(new Exam()
            {
                MarkSystem = new FiveStepMarkSystem(),
                Themes = new List<Theme>
                {
                    new Theme() { ThemeName = "Theme one" }, new Theme() { ThemeName = "Theme two" } },
                Tickets = new List<Ticket>() { new Ticket() {TicketNumber =1, QuestionGroups = new List<QuestionGroup>()
                    {
                        group,secondGroup
                    }

                },                     new Ticket()
                 }
            });
            Application.Run(context);
        }
    }
}
